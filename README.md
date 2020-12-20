# YouTubeLinkParser
Parses virtually any YouTube link that, when clicked, goes to a video, channel, or user. Even the messy ones.

## How to use

Just run `YoutubeUri.TryCreate("<YouTube URL>", out var youtubeUri)`, then `youtubeUri` will be `null` if it couldn't be found or it will contain the relavent info if it could be found. Also, the method will return `true`/`false` depending on if it could be found, just like the other `TryCreate` methods.

## FAQ

Q: There's already a bunch of YouTube link parsers, why is this one any different?

A: The ones that currently exist do not parse many types of links because they are too restrictive or do not know all of the formats that a link can be in. YouTube also applies some server-side trickery to fix the hyper-damaged links (try adding a few letters after a YouTube video URL; you'll see that it still goes to the video!)

This project aims to parse any valid YouTube link that goes to a video, channel, or user. This project has 149 test cases for many types of URLs, including ones without the HTTP prefix, some with, some that are on different TLDs like `youtube.co.uk`, `jp.youtube.com`, `www.be.youtube.com` and ~40 more, URL fragments like `youtube.com/#/channel/...`, some with video IDs doubly encoded, video IDs with slashes, URLs with commas (yes, those are valid, but only the last half!), channel names with diacritics (e.g, `É` which is a valid letter, I checked), `/feed/`, `attribution_link`s, the `/v/` and `/c/` shorter URLs, mobile URLs, and many more. The tests cases are selected from ~167,000 YouTube Twitter URLs from `archiveteam-twitter-stream-2018-05`; the ones that failed to parse and were valid were reviewed, parser fixed, and added to this repository's test cases, and then the process was repeated.
