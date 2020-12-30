using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using UriTemplate.Core;

namespace YouTubeLinkParser
{
    public class ParameterizedUriTemplate
    {
        public UriTemplate.Core.UriTemplate? UriTemplate;
        public List<string> Parameters = new List<string>();
        public bool SearchKeys { get; set; } = false;
    }
    public class YoutubeUri
    {
        /// <summary>
        /// Parses a YouTube URI, and throws a FormatException if the URL is invalid or does not contain any information.
        /// </summary>
        /// <param name="url">The URL to parse</param>
        /// <param name="shouldIgnoreDomain">Whether the domain should be ignored while parsing. This is useful if YouTube adds more domains after
        /// this has been published or when using services which mimic YouTube's URL pattern for compatibility.</param>
        public YoutubeUri(string url, bool shouldIgnoreDomain = false)
        {
            if (!TryCreate(url, out var uri, shouldIgnoreDomain))
                throw new FormatException("The channel id, user, playlist id, search results, or video id were not found.");

            ChannelId = uri?.ChannelId;
            VideoId = uri?.VideoId;
            UserId = uri?.UserId;
            PlaylistId = uri?.PlaylistId;
            SearchResults = uri?.SearchResults;
        }

        private YoutubeUri()
        {
        }

        public string? ChannelId { get; private set; }
        public string? UserId { get; private set; }
        public string? VideoId { get; private set; }
        public string? PlaylistId { get; private set; }
        public string? SearchResults { get; private set; }

        /// <summary>
        /// Returns the normalized Uri of the YouTube link but only supports a single attribute in this order:
        /// channel id, video id, search result, playlist id, or user id. If none are set this returns null.
        /// </summary>
        public Uri? Uri
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ChannelId)) return new Uri($"https://youtube.com/c/{HttpUtility.UrlEncode(ChannelId)}");

                if (!string.IsNullOrWhiteSpace(VideoId)) return new Uri($"https://youtube.com/v/{VideoId}");

                if (!string.IsNullOrWhiteSpace(PlaylistId))
                    return new Uri($"https://youtube.com/playlist?list={PlaylistId}");

                if (!string.IsNullOrWhiteSpace(SearchResults))
                    return new Uri($"https://youtube.com/results?search_query={HttpUtility.UrlEncode(SearchResults)}");

                return !string.IsNullOrWhiteSpace(UserId) ? new Uri(
                    $"https://youtube.com/u/{HttpUtility.UrlEncode(UserId)}") : null;
            }
        }

        private static HashSet<string> ValidHosts
        {
            get
            {
                var validHosts = new List<string>
                {
                    "gaming.youtube.com",
                    "music.youtube.com",
                    "studio.youtube.com",
                    "tv.youtube.com",
                    "youtu.be",
                    "yt.be",
                    "youtube",
                    "m.youtube",
                    "youtube-nocookie.com",
                    "youtube.googleapis.com",
                    "youtubekids.com"
                };
                var tlds = new List<string>
                {
                    "ae",
                    "at",
                    "az",
                    "ba",
                    "be",
                    "bg",
                    "bh",
                    "bo",
                    "by",
                    "ca",
                    "cat",
                    "ch",
                    "cl",
                    "co",
                    "co.ae",
                    "co.at",
                    "co.cr",
                    "co.hu",
                    "co.id",
                    "co.il",
                    "co.in",
                    "co.jp",
                    "co.ke",
                    "co.kr",
                    "co.ma",
                    "co.nz",
                    "co.th",
                    "co.tz",
                    "co.ug",
                    "co.uk",
                    "co.ve",
                    "co.za",
                    "co.zw",
                    "com",
                    "com.ar",
                    "com.au",
                    "com.az",
                    "com.bd",
                    "com.bh",
                    "com.bo",
                    "com.br",
                    "com.by",
                    "com.co",
                    "com.do",
                    "com.ec",
                    "com.ee",
                    "com.eg",
                    "com.es",
                    "com.gh",
                    "com.gr",
                    "com.gt",
                    "com.hk",
                    "com.hn",
                    "com.hr",
                    "com.jm",
                    "com.jo",
                    "com.kw",
                    "com.lb",
                    "com.lv",
                    "com.ly",
                    "com.mk",
                    "com.mt",
                    "com.mx",
                    "com.my",
                    "com.ng",
                    "com.ni",
                    "com.om",
                    "com.pa",
                    "com.pe",
                    "com.ph",
                    "com.pk",
                    "com.pt",
                    "com.py",
                    "com.qa",
                    "com.ro",
                    "com.sa",
                    "com.sg",
                    "com.sv",
                    "com.tn",
                    "com.tr",
                    "com.tw",
                    "com.ua",
                    "com.uy",
                    "com.ve",
                    "cr",
                    "cz",
                    "de",
                    "dk",
                    "ee",
                    "es",
                    "fi",
                    "fr",
                    "ge",
                    "gr",
                    "gt",
                    "hk",
                    "hr",
                    "hu",
                    "ie",
                    "in",
                    "iq",
                    "is",
                    "it",
                    "jo",
                    "jp",
                    "kr",
                    "kz",
                    "lk",
                    "lt",
                    "lu",
                    "lv",
                    "ly",
                    "ma",
                    "me",
                    "mk",
                    "mx",
                    "my",
                    "net.in",
                    "ng",
                    "ni",
                    "nl",
                    "no",
                    "pa",
                    "pe",
                    "ph",
                    "pk",
                    "pl",
                    "pr",
                    "pt",
                    "qa",
                    "ro",
                    "rs",
                    "ru",
                    "sa",
                    "se",
                    "sg",
                    "si",
                    "sk",
                    "sn",
                    "sv",
                    "tn",
                    "tv",
                    "ua",
                    "ug",
                    "uy",
                    "vn",
                    "voto"
                };

                validHosts.AddRange(validHosts.ToList().Select(host => $"{host}."));
                
                validHosts.AddRange(tlds.Select(tld => $"youtube.{tld}"));
                validHosts.AddRange(tlds.Select(tld => $"youtube.{tld}."));
                validHosts.AddRange(tlds.Where(tld => !tld.Contains(".")).Select(tld => $"{tld}.youtube.com"));
                validHosts.AddRange(tlds.Select(tld => $"m.youtube.{tld}"));
                validHosts.AddRange(tlds.Select(tld => $"www.youtube.{tld}"));

                return new HashSet<string>(validHosts, StringComparer.OrdinalIgnoreCase);
            }
        }

        static Uri ReplaceHost(string original, string newHostName)
        {
            var builder = new UriBuilder(original);
            builder.Host = newHostName;
            builder.Scheme = "https://";
            return builder.Uri;
        }

        /// <summary>
        ///     Try to parse a given YouTube URL. Accepts any unparsed YouTube URL which can be opened using any modern desktop
        ///     web-browser,
        ///     assuming that there are no HTTP-level redirects from a different domain.
        ///     If a link shortener or a redirection domain is used, it has to be resolved and redirected to the final location
        ///     before
        ///     using this parser.
        /// </summary>
        /// <param name="unparsedYouTubeUri">The unparsed YouTube URL.</param>
        /// <param name="youtubeUri">The parsed YouTube URL, otherwise null if it could not be parsed.</param>
        /// <returns>Whether the URL could be parsed.</returns>
        public static bool TryCreate(string unparsedYouTubeUri, out YoutubeUri? youtubeUri, bool shouldIgnoreDomain = false)
        {
            youtubeUri = new YoutubeUri();

            unparsedYouTubeUri = unparsedYouTubeUri.Trim('\'', '\"');
            unparsedYouTubeUri = new string(unparsedYouTubeUri.Where(c => !char.IsControl(c) || c == ' ').ToArray());

            var validProtocols = new List<string> {"https://", "http://", "//"};

            // Uri.TryCreate requires that the URL has a protocol
            var httpPrefixedUnparsedYouTubeUri = unparsedYouTubeUri;
            if (validProtocols.TrueForAll(protocol =>
                !unparsedYouTubeUri.StartsWith(protocol, StringComparison.InvariantCultureIgnoreCase)))
                httpPrefixedUnparsedYouTubeUri = $"https://{unparsedYouTubeUri}";

            // if it's not a URL there's nothing we can do
            if (!Uri.TryCreate(httpPrefixedUnparsedYouTubeUri, UriKind.Absolute, out var parsedYouTubeUri))
            {
                youtubeUri = null;
                return false;
            }

            // remove port (if it exists)
            if (!UriIsValidYouTubeDomain(parsedYouTubeUri) && !shouldIgnoreDomain) return false;
            var domain = Services.GetDomainPart(parsedYouTubeUri.ToString());
            var isShortUrl = domain == "youtu.be" || domain == "www.youtu.be" || domain == "www.yt.be" || domain == "yt.be";

            // TODO: check URLs with commas in them to make sure this doesn't throw any exceptions
            // YouTube ignores everything before the comma in a URL, sometimes...
            if (isShortUrl && unparsedYouTubeUri.Contains(","))
            {
                // if both are valid YouTube domains, choose the last one otherwise choose the first
                var splitUris = unparsedYouTubeUri.Split(",");
                
                // I don't know the behavior for more than two comas in a URI yet
                if (splitUris.Length > 2)
                {
                    youtubeUri = null;
                    return false;
                }

                var chosenUri = "";
                Uri.TryCreate(splitUris.First(), UriKind.Absolute, out var firstUri);
                Uri.TryCreate(splitUris.Last(), UriKind.Absolute, out var lastUri);

                if (firstUri != null && UriIsValidYouTubeDomain(firstUri))
                {
                    chosenUri = (lastUri != null && UriIsValidYouTubeDomain(lastUri)) ? splitUris.Last() : splitUris.First();
                }

                if (!Uri.TryCreate(chosenUri, UriKind.Absolute, out var newUrl))
                {
                    youtubeUri = null;
                    return false;
                }

                parsedYouTubeUri = newUrl;
            }


            var replaceHost = isShortUrl ? ReplaceHost(parsedYouTubeUri.ToString(), "youtu.be") : ReplaceHost(parsedYouTubeUri.ToString(), "youtube.com");


            var templates = new List<ParameterizedUriTemplate>
            {
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/subscription_center?add_user={u}"), Parameters = new List<string>{"u"}},

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?/watch{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?u=/watch?v={v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link{?keys*}"), Parameters = new List<string>{"u"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?u=/watch?v={v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?u=/watch?v={v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?a={var}&u=/watch?v={v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?a={var}&u=/watch?v={v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/attribution_link?u=/watch?v={v}{&keys*}"), Parameters = new List<string>{"v"}},

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/profile{?user}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/profile{?keys*}"), Parameters = new List<string>{"user"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/playlist{?list}"), Parameters = new List<string>{"list"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/playlist{?p}"), Parameters = new List<string>{"p"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/playlist{?keys*}"), Parameters = new List<string>{"list"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/playlist{?keys*}"), Parameters = new List<string>{"p"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtu.be/{v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtu.be/{v}{/path}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtu.be/{v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?keys*}#/channel/{c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/?#/channel/{c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/?#/user/{user}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/#/user/{user}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/#/user/{user}{?keys*}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?keys*}#/user/{u}"), Parameters = new List<string>{"u"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?keys*}#/watch?v={v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}{/path}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}#"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}#{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch?v={+v}"), Parameters = new List<string>{"v"}},

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch_popup{?v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch_popup{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch_popup{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch_popup{?v}#"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch_popup{?v}#{+var}"), Parameters = new List<string>{"v"}},

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?vi}{&keys*}"), Parameters = new List<string>{"vi"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?keys*}"), Parameters = new List<string>{"vi"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?vi}#"), Parameters = new List<string>{"vi"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?vi}#{+var}"), Parameters = new List<string>{"vi"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch/{v}"), Parameters = new List<string>{"v"}},

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/ytscreeningroom{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/ytscreeningroom{?v}&{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}/"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}/{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?vi}"), Parameters = new List<string>{"vi"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?vi}{&keys*}"), Parameters = new List<string>{"vi"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                

                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}/"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/watch{?v}&{+var}"), Parameters = new List<string>{"v"}},
                
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/e/{v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/watch{?v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/watch{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/v={v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/{v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/{v}?{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/{v}/{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/embed/watch{?keys*}"), Parameters = new List<string>{"v"}, SearchKeys = true},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/v/{v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/v/{v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/vi/{v}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/vi/{v}{&keys*}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/v/{v}?{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/vi/{v}?{+var}"), Parameters = new List<string>{"v"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/channel{/c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{?keys*}#/channel/{c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/channel{/c}{+var}"), Parameters = new List<string>{"c"}},


                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}#p/a/u/1/{v}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}#p/u/1/{v}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}#{+var}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}/"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}{+path}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}?{+var}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/user/{user}{?keys*}"), Parameters = new List<string>{"user"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/feed/{+c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/c{/c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/+{+c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com{/c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com{/c}{/path}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{/c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/#!/{c}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{c}{?keys*}"), Parameters = new List<string>{"c"}},
                new ParameterizedUriTemplate {UriTemplate = new UriTemplate.Core.UriTemplate("https://youtube.com/{+c}"), Parameters = new List<string>{"c"}},


            };

            foreach (var template in templates)
            {
                if (template.UriTemplate == null) continue;
                UriBuilder u1 = new UriBuilder(replaceHost.AbsoluteUri);
                u1.Port = -1;
                Uri clean = new Uri(u1.Uri.ToString());
                var doesTemplateMatch = template.UriTemplate.Match(clean);

                template.Parameters
                    .Select(parameter => GetBindingValueByName(doesTemplateMatch, parameter, template.SearchKeys))
                    .TrueForAll(x => !string.IsNullOrWhiteSpace(x));



                switch (template.Parameter)
                {
                    case "v":
                    case "vi":
                        youtubeUri.VideoId = extracted.Split("|").FirstOrDefault();
                        break;
                    case "c":
                        youtubeUri.ChannelId = extracted.Split("|").FirstOrDefault();
                        break;
                    case "user":
                        youtubeUri.UserId = extracted.Split("|").FirstOrDefault();
                        break;
                    case "u":
                        youtubeUri.VideoId = extracted.Split("watch?v=").LastOrDefault();
                        break;
                    case "list":
                    case "p":
                        youtubeUri.PlaylistId = extracted;
                        break;
                }

                return true;
            }

            /*var queryString = HttpUtility.ParseQueryString(parsedYouTubeUri.Query);

            var channelId = Parsers.GetChannelId(pathComponents, queryString,
                isShortUrl, parsedYouTubeUri.Fragment);
            var userId = Parsers.GetUserId(pathComponents, queryString, parsedYouTubeUri.Fragment);
            var videoId = Parsers.GetVideoId(pathComponents, queryString,
                isShortUrl, parsedYouTubeUri.Fragment);
            var playlistId = Parsers.GetPlaylistId(queryString, parsedYouTubeUri.Fragment);
            var searchResults = Parsers.GetSearchResults(queryString, parsedYouTubeUri.Fragment);

            if (!string.IsNullOrWhiteSpace(channelId) || !string.IsNullOrWhiteSpace(videoId) ||
                !string.IsNullOrWhiteSpace(userId) || !string.IsNullOrWhiteSpace(playlistId) ||
                !string.IsNullOrWhiteSpace(searchResults))
            {
                youtubeUri.ChannelId = channelId;
                youtubeUri.VideoId = videoId;
                youtubeUri.UserId = userId;
                youtubeUri.PlaylistId = playlistId;
                youtubeUri.SearchResults = searchResults;
                return true;
            }*/

            youtubeUri = null;
            return false;
        }

        private static string? GetBindingValueByName(UriTemplateMatch output2, string param, bool searchKeys = false)
        {
            if (output2 == null || param == null) return null;
            var test = output2.Bindings;
            if (searchKeys)
            {
                test.TryGetValue("keys", out var test4);
                test4.Deconstruct(out var key, out object val1);
                if (val1 == null) return null;
                if (!(val1 is Dictionary<string, string>))
                {
                    return val1.ToString();
                }

                return ((Dictionary<string, string>)val1).TryGetValue(param, out var var2) ? var2 : null;
            }
            else
            {
                test.TryGetValue(param, out var test4);
                test4.Deconstruct(out _, out var val1);
                if (val1 == null) return null;
                if (!(val1 is Dictionary<string, string>))
                {
                    return val1.ToString();
                }

                return ((Dictionary<string, string>) val1).TryGetValue(param, out var var2) ? var2 : null;
            }
        }

        private static bool UriIsValidYouTubeDomain(Uri parsedYouTubeLink)
        {
            parsedYouTubeLink =
                new Uri(parsedYouTubeLink.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.UriEscaped));
            var domain = Services.GetDomainPart(parsedYouTubeLink.ToString());

            return ValidHosts.Contains(domain);
        }


        public override bool Equals(object? obj)
        {
            return obj != null && ((YoutubeUri) obj).VideoId == VideoId &&
                   ((YoutubeUri) obj).ChannelId == ChannelId && ((YoutubeUri) obj).VideoId == VideoId;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return $"{VideoId ?? "<none>"}-{ChannelId ?? "<none>"}-{UserId ?? "<none>"}".GetHashCode();
        }

        public override string ToString()
        {
            return
                $"[VideoID] = {VideoId ?? "<none>"}, [ChannelID] = {ChannelId ?? "<none>"}, [UserID] = {UserId ?? "<none>"}";
        }
    }
}