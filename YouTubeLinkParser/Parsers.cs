using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace YouTubeLinkParser
{
    internal class Parsers
    {
        internal static string? GetChannelId(IReadOnlyList<string> pathComponents, NameValueCollection queryString,
            bool isShortUrl, string fragment)
        {
            string? channelId = null;
            switch (pathComponents.FirstOrDefault())
            {
                case "c":
                case "channel":
                case "feed":
                {
                    if (pathComponents.Count >= 2) channelId = pathComponents[1];
                    break;
                }

                case "comment":
                case "get_video":
                case "get_video_info":
                case "live_chat":
                case "login":
                case "results":
                case "signup":
                case "t":
                case "e":
                case "timedtext_video":
                case "verify_age":
                case "watch_ajax":
                case "watch_fragments_ajax":
                case "watch_popup":
                case "watch_queue_ajax":
                case "ads":
                case "sitemaps":
                case "kids":
                case "trends":
                case "about":
                case "jobs":
                case "creators":
                case "creators-for-change":
                case "csai-match":
                case "creatorresearch":
                case "originals":
                case "nextup":
                case "goldenpass":
                case "giftcards":
                case "space":
                case "measurementprogram":
                case "yt":
                case "howyoutubeworks":
                case "profile":
                case "user":
                case "watch":
                case "embed":
                case "subscription_center":
                case "v":
                case "vi":
                case "my_account":
                case "playlist":
                case "ytscreeningroom":
                case "intl":
                {
                    break;
                }
                case "attribution_link":
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("u")))
                    {
                        channelId = queryString.Get("u").Split("/channel/").LastOrDefault() ?? string.Empty;
                        if (channelId.StartsWith("/watch?v=") || channelId.StartsWith("/v/")) channelId = string.Empty;
                    }

                    break;
                }
                default:
                {
                    if (!isShortUrl && pathComponents.Count >= 1 && !string.IsNullOrWhiteSpace(pathComponents[0]))
                        channelId = pathComponents[0];
                    else if (Regex.IsMatch(fragment, @"#/channel/([a-zA-Z0-9])"))
                        channelId = fragment.Split(@"#/channel/").LastOrDefault()?.Split("?").FirstOrDefault()
                            ?.Split("&").FirstOrDefault();
                    else if (Regex.IsMatch(fragment, @"#!/([a-zA-Z0-9])"))
                        channelId = fragment.Split(@"#!/").LastOrDefault()?.Split("?").FirstOrDefault()?.Split("&")
                            .FirstOrDefault();

                    break;
                }
            }

            channelId = HttpUtility.UrlDecode(channelId ?? string.Empty);
            channelId = channelId.Split("?").FirstOrDefault() ?? string.Empty;

            channelId = channelId.Split("http://").FirstOrDefault() ?? string.Empty;
            channelId = channelId.Split("https://").FirstOrDefault() ?? string.Empty;

            return Regex.IsMatch(HttpUtility.UrlEncode(Services.RemoveDiacritics(channelId)), @"[a-zA-Z0-9\-_\%\+]{1,}")
                ? channelId
                : null;
        }

        internal static string? GetUserId(IReadOnlyList<string> pathComponents, NameValueCollection queryString,
            string fragment)
        {
            string username = string.Empty;
            switch (pathComponents.FirstOrDefault())
            {
                case "u":
                case "user":
                case "addme":
                {
                    if (pathComponents.Count >= 2) username = HttpUtility.UrlDecode(pathComponents[1]);

                    break;
                }

                case "profile":
                {
                    if (pathComponents.Count >= 1)
                        if (pathComponents[0] == "profile" && !string.IsNullOrWhiteSpace(queryString.Get("user")))
                            username = queryString.Get("user");

                    break;
                }

                case "subscription_center":
                {
                    if (pathComponents.Count >= 1) username = queryString.Get("add_user");
                    break;
                }

                default:
                {
                    if (!Regex.IsMatch(fragment, @"#/user/([a-zA-Z0-9])")) return null;
                    username = fragment.Split(@"#/user/").LastOrDefault()?.Split("?").FirstOrDefault()?.Split("&")
                        .FirstOrDefault() ?? string.Empty;
                    break;
                }
            }

            if (username.Contains(":") && !username.Contains("http:") && !username.Contains("https:"))
                return null;

            username = username.Split("http://").FirstOrDefault() ?? string.Empty;
            username = username.Split("http:").FirstOrDefault() ?? string.Empty;

            username = username.Split("https://").FirstOrDefault() ?? string.Empty;
            username = username.Split("https:").FirstOrDefault() ?? string.Empty;
            return username;
        }

        internal static string? GetPlaylistId(NameValueCollection queryString, string fragment)
        {
            if (string.IsNullOrWhiteSpace(queryString.Get("list")))
            {
                if (!fragment.StartsWith("#")) return null;

                fragment = fragment.Substring(1, fragment.Length - 1);
                var fragmentParsed = HttpUtility.ParseQueryString(fragment);
                if (!string.IsNullOrWhiteSpace(fragmentParsed.Get("list"))) return fragmentParsed.Get("list");
                if (!string.IsNullOrWhiteSpace(fragmentParsed.Get("/watch?list")))
                    return fragmentParsed.Get("/watch?list");
            }
            else
            {
                return queryString.Get("list");
            }

            return null;
        }

        internal static string? GetSearchResults(NameValueCollection queryString, string fragment)
        {
            if (!string.IsNullOrWhiteSpace(queryString.Get("search_query")))
            {
                return queryString.Get("search_query");
            }
            
            if (!string.IsNullOrWhiteSpace(queryString.Get("q")))
            {
                return queryString.Get("q");
            }

            return null;
        }

        internal static string? GetVideoId(IReadOnlyList<string> pathComponents, NameValueCollection queryString,
            bool isShortUrl, string fragment)
        {
            string? videoId = null;
            switch (pathComponents.FirstOrDefault())
            {
                case "watch":
                case "watch_popup":
                case "ytscreeningroom":
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("v")))
                        videoId = queryString.Get("v");
                    else if (!string.IsNullOrWhiteSpace(queryString.Get("vi")))
                        videoId = queryString.Get("vi");
                    else if (!string.IsNullOrWhiteSpace(queryString.Get("video_src")))
                        videoId = queryString.Get("video_src");
                    else if (!string.IsNullOrWhiteSpace(queryString.Get("src_vid")))
                        videoId = queryString.Get("src_vid");
                    else if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                        videoId = pathComponents[1];

                    break;
                }
                case "v":
                case "vi":
                case "e":
                {
                    if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                        videoId = pathComponents[1].Split("&").FirstOrDefault() ?? string.Empty;

                    break;
                }

                case "embed":
                {
                    if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                    {
                        if (pathComponents[1] != "watch")
                        {
                            videoId = HttpUtility.UrlDecode(pathComponents[1]);

                            if (videoId.Contains("?")) videoId = videoId.Split("?").First();
                        }
                        else
                        {
                            videoId = queryString.Get("v");
                        }
                    }

                    break;
                }

                case "attribution_link":
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("u")))
                    {
                        var user = queryString.Get("u");

                        videoId = HttpUtility.ParseQueryString(user.Split("?").LastOrDefault() ?? string.Empty).Get("v");
                    }
                    else if (Regex.IsMatch(queryString.ToString() ?? string.Empty, @"\/watch\?v=[a-zA-Z0-9_-]{8,14}$"))
                    {
                        videoId = queryString.ToString()?.Split("v=").LastOrDefault();
                    }

                    break;
                }

                case null:
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("v")))
                    {
                        videoId = queryString.Get("v");
                    }
                    else if (!string.IsNullOrWhiteSpace(queryString.Get("vi")))
                    {
                        videoId = queryString.Get("vi");
                    }
                    else
                    {
                        if (fragment.StartsWith("#"))
                        {
                            fragment = fragment.Substring(1, fragment.Length - 1);
                            var fragmentParsed = HttpUtility.ParseQueryString(fragment);
                            if (!string.IsNullOrWhiteSpace(fragmentParsed.Get("v")))
                                videoId = fragmentParsed.Get("v");
                            else if (!string.IsNullOrWhiteSpace(fragmentParsed.Get("/watch?v")))
                                videoId = fragmentParsed.Get("/watch?v");
                        }
                    }

                    break;
                }

                default:
                {
                    if (isShortUrl && pathComponents.Count >= 1 && !string.IsNullOrWhiteSpace(pathComponents[0]))
                        videoId = pathComponents[0].Split("&").FirstOrDefault();
                    else if (Regex.IsMatch(fragment, @"#/watch\?v=([a-zA-Z0-9\:\/\/]{8,})"))
                        videoId = fragment.Split(@"#/watch?v=").LastOrDefault();

                    break;
                }
            }


            if (videoId == null)
            {
                if (!fragment.StartsWith("#p/a/u/") && !fragment.StartsWith("#p/u/")) return videoId;

                var fragmentVideoId = fragment.Split(@"/").LastOrDefault();
                fragmentVideoId = fragmentVideoId?.Split("?").FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(fragmentVideoId)) videoId = fragmentVideoId;
            }

            return CleanVideoId(videoId);
        }

        private static string? CleanVideoId(string? videoId)
        {
            // if the video ID contains a URL-encoded slash (or a regular slash) YouTube will just parse the first part
            videoId = HttpUtility.UrlDecode(videoId);

            videoId = videoId.Split("http://").FirstOrDefault() ?? string.Empty;
            videoId = videoId.Split("https://").FirstOrDefault() ?? string.Empty;

            videoId = videoId.Split("?").FirstOrDefault() ?? string.Empty;

            if (videoId.Contains("/")) videoId = videoId.Split("/").First();

            // YouTube will remove all characters after a video id until it matches one in its database. This is a crude approximation because
            // it is impossible to match exactly as we'd need to know every video in YouTube's database.
            videoId = Regex.Split(videoId ?? string.Empty,
                    "[^a-zA-Z0-9_-]")
                .FirstOrDefault() ?? string.Empty;

            return !Regex.IsMatch(videoId,
                @"^[a-zA-Z0-9_-]{8,}$")
                ? null
                : videoId;
        }
    }
}