using System;

namespace YouTubeLinkParser.Demo
{
    class Program
    {
        static void Main()
        {
            // Works with youtube.co.uk and many other TLDs. You can even use the youtu.be short URL, and don't have to prefix it with
            // http, or you can if you want. It'll accept (hopefully) anything you put into it, including music.youtube.com URLs. Give it a shot.
            if (YoutubeUri.TryCreate("youtube.com/watch?v=fZHVo6ZOzSc", out var youtubeUri))
            {
                Console.WriteLine(youtubeUri);
            }
        }
    }
}
