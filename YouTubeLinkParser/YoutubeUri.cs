using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTubeLinkParser
{
    public class YoutubeUri
    {
        public string? ChannelId;
        public string? UserId;
        public string? VideoId;

        // ReSharper disable once MemberCanBePrivate.Global
        public YoutubeUri()
        {
        }

        public YoutubeUri(string url)
        {
            if (!TryCreate(url, out var uri))
                throw new FormatException("The channel id, user, or video id were not found.");

            ChannelId = uri?.ChannelId;
            VideoId = uri?.VideoId;
            UserId = uri?.UserId;
        }

        public Uri? Uri
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ChannelId)) return new Uri($"https://youtube.com/c/{ChannelId}");

                if (!string.IsNullOrWhiteSpace(VideoId)) return new Uri($"https://youtube.com/v/{VideoId}");

                return !string.IsNullOrWhiteSpace(UserId) ? new Uri($"https://youtube.com/u/{UserId}") : null;
            }
        }

        /// <summary>
        /// Try to parse a given YouTube URL. Accepts any unparsed YouTube URL which can be opened using any modern desktop web-browser,
        /// assuming that there are no HTTP-level redirects from a different domain.
        ///
        /// If a link shortener or a redirection domain is used, it has to be resolved and redirected to the final location before
        /// using this parser.
        /// </summary>
        /// <param name="unparsedYouTubeUri">The unparsed YouTube URL.</param>
        /// <param name="youtubeUri">The parsed YouTube URL, otherwise null if it could not be parsed.</param>
        /// <returns>Whether the URL could be parsed.</returns>
        public static bool TryCreate(string unparsedYouTubeUri, out YoutubeUri? youtubeUri)
        {
            youtubeUri = new YoutubeUri();

            unparsedYouTubeUri = unparsedYouTubeUri.Trim();

            // Uri.TryCreate requires that the URL has a protocol
            var httpPrefixedUnparsedYouTubeLink = unparsedYouTubeUri;
            if (!unparsedYouTubeUri.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) &&
                !unparsedYouTubeUri.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) &&
                !unparsedYouTubeUri.StartsWith("//"))
                httpPrefixedUnparsedYouTubeLink = $"https://{unparsedYouTubeUri}";

            // if it's not a URL there's nothing we can do
            if (!Uri.TryCreate(httpPrefixedUnparsedYouTubeLink, UriKind.Absolute, out var parsedYouTubeLink))
            {
                youtubeUri = null;
                return false;
            }

            var domain = Services.GetDomainPart(parsedYouTubeLink.ToString());

            if (!ValidHosts.Contains(domain, StringComparer.InvariantCultureIgnoreCase))
            {
                youtubeUri = null;
                return false;
            }

            // TODO: check URLs with commas in them to make sure this doesn't throw any exceptions
            // YouTube ignores everything before the comma in a URL, sometimes...
            if (domain == "youtu.be" && unparsedYouTubeUri.Contains(","))
                parsedYouTubeLink = new Uri(unparsedYouTubeUri.Split(",").Last());

            List<string> pathComponents;

            // TODO: some carefully crafted URLs might cause this to throw an exception when the URL is re-parsed
            // URLs like https://youtube.com/#/...
            if (parsedYouTubeLink.Fragment.StartsWith("#") || parsedYouTubeLink.Fragment.StartsWith("?#"))
            {
                var parsedYouTubeLinkWithoutFragment =
                    new Uri(parsedYouTubeLink.ToString().Replace("/#/", "/").Replace("/?#/", "/"));
                pathComponents = parsedYouTubeLinkWithoutFragment.AbsolutePath
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                parsedYouTubeLink = parsedYouTubeLinkWithoutFragment;
            }
            else
            {
                pathComponents = parsedYouTubeLink.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }

            var queryString = HttpUtility.ParseQueryString(parsedYouTubeLink.Query);

            var channelId = Parsers.GetChannelId(pathComponents, domain == "youtu.be" || domain == "www.youtu.be");
            var userId = Parsers.GetUserId(pathComponents, queryString);
            var videoId = Parsers.GetVideoId(pathComponents, queryString, domain == "youtu.be" || domain == "www.youtu.be");

            if (!string.IsNullOrWhiteSpace(channelId) || !string.IsNullOrWhiteSpace(videoId) ||
                !string.IsNullOrWhiteSpace(userId))
            {
                youtubeUri.ChannelId = channelId;
                youtubeUri.VideoId = videoId;
                youtubeUri.UserId = userId;
                return true;
            }

            youtubeUri = null;
            return false;
        }

        private static List<string> ValidHosts
        {
            get
            {
                var validHosts = new List<string>
                    {"youtu.be", "gaming.youtube.com", "tv.youtube.com", "youtubekids.com", "music.youtube.com"};
                var tlds =
                    ("co.nz com.pk co.in net.in co.il co.jp co.za com.es co.th co.uk com ae" +
                     " at az ba be bg bh bo by ca ch cl co cr cz de dk ee es fi fr ge gr gt hk" +
                     " hr hu ie in iq is it jo jp kr kz lk lt lu lv ly ma me mk mx my ng ni nl" +
                     " no pa pe ph pk pl pr pt qa ro rs ru sa se sg si sk sn sv tn ua ug uy vn"
                    ).Split(" ").ToList();

                validHosts.AddRange(tlds.Select(tld => $"youtube.{tld}"));
                validHosts.AddRange(tlds.Where(tld => !tld.Contains(".")).Select(tld => $"{tld}.youtube.com"));
                validHosts.AddRange(tlds.Select(tld => $"m.youtube.{tld}"));
                validHosts.AddRange(tlds.Select(tld => $"www.youtube.{tld}"));
                return validHosts;
            }
        }

        public override bool Equals(object? obj) =>
            obj != null && ((YoutubeUri) obj).VideoId == VideoId &&
            ((YoutubeUri) obj).ChannelId == ChannelId && (((YoutubeUri) obj).VideoId) == VideoId;

        public override int GetHashCode()
        {
            return $"{VideoId ?? "<none>"}-{ChannelId ?? "<none>"}-{UserId ?? "<none>"}".GetHashCode();
        }

        public override string ToString()
        {
            return
                $"[VideoID] = {VideoId ?? "<none>"}, [ChannelID] = {ChannelId ?? "<none>"}, [UserID] = {UserId ?? "<none>"}";
        }
    }
}