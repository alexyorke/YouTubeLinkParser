using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace YouTubeLinkParser
{
    internal class Parsers
    {
        internal static string? GetChannelId(IReadOnlyList<string> pathComponents, bool isShortUrl)
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
                case "attribution_link":
                case "embed":
                case "subscription_center":
                case "v":
                case "vi":
                case "my_account":
                case "playlist":
                case "ytscreeningroom":
                {
                    break;
                }
                default:
                {
                    if (!isShortUrl && pathComponents.Count >= 1 && !string.IsNullOrWhiteSpace(pathComponents[0]))
                        channelId = pathComponents[0];

                    break;
                }
            }

            channelId = HttpUtility.UrlDecode(channelId ?? "");

            return Regex.IsMatch(HttpUtility.UrlEncode(Services.RemoveDiacritics(channelId)), @"[a-zA-Z0-9\-_\%\+]{1,}")
                ? channelId
                : null;
        }

        internal static string? GetUserId(IReadOnlyList<string> pathComponents, NameValueCollection queryString)
        {
            string username = "";
            switch (pathComponents.FirstOrDefault())
            {
                case "u":
                case "user":
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
                    return null;
            }

            return username.Contains(":") ? null : username;
        }

        internal static string? GetVideoId(IReadOnlyList<string> pathComponents, NameValueCollection queryString,
            bool isShortUrl)
        {
            string? videoId = null;
            switch (pathComponents.FirstOrDefault())
            {
                case "watch":
                case "ytscreeningroom":
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("v")))
                        videoId = queryString.Get("v");
                    else if (!string.IsNullOrWhiteSpace(queryString.Get("vi")))
                        videoId = queryString.Get("vi");
                    else if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                        videoId = pathComponents[1];

                    break;
                }
                case "v":
                case "vi":
                case "e":
                {
                    if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                        videoId = pathComponents[1].Split("&").FirstOrDefault() ?? "";

                    break;
                }

                case "embed":
                {
                    if (pathComponents.Count >= 2 && !string.IsNullOrWhiteSpace(pathComponents[1]))
                    {
                            if (pathComponents[1] != "watch")
                            {
                                videoId = HttpUtility.UrlDecode(pathComponents[1]);

                                if (videoId.Contains("?"))
                                {
                                    videoId = videoId.Split("?").First();
                                }
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

                        videoId = HttpUtility.ParseQueryString(user.Split("?").LastOrDefault() ?? "").Get("v");
                    } else if (pathComponents.Count >= 2 && pathComponents[1] == "watch")
                    {
                        //    
                    }

                    break;
                }

                case null:
                {
                    if (!string.IsNullOrWhiteSpace(queryString.Get("v")))
                        videoId = queryString.Get("v");
                    if (!string.IsNullOrWhiteSpace(queryString.Get("vi")))
                        videoId = queryString.Get("vi");
                    break;
                }

                default:
                {
                    if (isShortUrl && pathComponents.Count == 1 && !string.IsNullOrWhiteSpace(pathComponents[0]))
                        videoId = pathComponents[0];

                    break;
                }
            }


            if (videoId == null) return videoId;

            // if the video ID contains a URL-encoded slash (or a regular slash) YouTube will just parse the first part
            videoId = HttpUtility.UrlDecode(videoId);

            if (videoId.Contains("/")) videoId = videoId.Split("/").First();

            if (!Regex.IsMatch(videoId ?? string.Empty, @"^[a-zA-Z0-9_-]{8,14}$")) videoId = null;

            return videoId;
        }
    }
}