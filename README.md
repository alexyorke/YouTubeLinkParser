# YouTubeLinkParser
Parses virtually any YouTube link that, when clicked, goes to a video, channel, or user. Even the messy ones.

## How to use

Just run `YoutubeUri.TryCreate("<YouTube URL>", out var youtubeUri)`, then `youtubeUri` will be `null` if it couldn't be found or it will contain the relavent info if it could be found. Also, the method will return `true`/`false` depending on if it could be found, just like the other `TryCreate` methods.

## Goals

- Be exceedingly well-tested by using real-world data (e.g. from Twitter's archive stream) and potentially cross-tested using other libraries. The test data of ~10 million unique links is being prepared.
- Be able to parse any YouTube URL for any region whose information is contained within the URL and does not require the Internet or Intranet to retrieve any additional information or to resolve ambiguities; for example, this excludes URL shorteners which remove critical information.
- The URL can be contained in the top 25 websites's redirect URLs (e.g. `https://facebook.com/l.php?u=https://...`.)
- The URL must be owned by one of the top 25 websites or owned by Google.
- The URL must be able to be entered in a web-browser, official mobile app, or mobile web-browser and it should go to the video, channel, and/or playlist id that `YouTubeLinkParser` identifies; this excludes image URLs as they do not go to videos, and excludes normalized URLs which are not valid URLs.
- Be flexible with the format, length, allowed characters, and character encoding of the video ids, channel ids, and playlist ids to allow for newly introduced URLs to still work and to assume that the user is correct.
- Be able to support legacy URL formats if they were in use, were available to the public, and used by a non-trivial amount of people.
- Make the test cases easy to copy so that other developers can port this library to other languages or to test their own libraries.
- Stay up-to-date with new link formats.

## Roadmap

- Migrate to a URL-routing table where the URL components are parameterized, defaulting to manual parsing logic if the URL is too complicated to be parsed using the routing rules. This is tracked in #1.
- Programmatically check every link in the 10M dataset, determine if it is owned by Google (via SSL certs) or another top 25 ranked website, and then remove if it is not. Parse the links and ensure that no unexpected exceptions are thrown.
- Create a distilled dataset which contains only the links which go through different code paths from the 10M dataset.
- Do fuzz testing or ensure that it is impossible for the `TryCreate` method to throw an exception due to parsing or user code.
- Periodically check YouTube's `sitemap.xml` file to keep up-to-date with reserved keywords.
- Create a periodic CI job which automatically creates a new issue if a new URL format is being used frequently (e.g. check Twitter.)

## FAQ

Q: There's already a bunch of YouTube link parsers, why is this one any different?

A: The ones that currently exist do not parse many types of links because they are too restrictive or do not know all of the formats that a link can be in. YouTube also applies some server-side trickery to fix the hyper-damaged links (try adding a few letters after a YouTube video URL; you'll see that it still goes to the video!)

This project aims to parse any valid YouTube link that goes to a video, channel, or user. This project has 149 test cases for many types of URLs, including ones without the HTTP prefix, some with, some that are on different TLDs like `youtube.co.uk`, `jp.youtube.com`, `www.be.youtube.com` and ~40 more, URL fragments like `youtube.com/#/channel/...`, some with video IDs doubly encoded, video IDs with slashes, URLs with commas (yes, those are valid, but only the last half!), channel names with diacritics (e.g, `É` which is a valid letter, I checked), `/feed/`, `attribution_link`s, the `/v/` and `/c/` shorter URLs, mobile URLs, and many more. The tests cases are selected from ~167,000 YouTube Twitter URLs from `archiveteam-twitter-stream-2018-05`; the ones that failed to parse and were valid were reviewed, parser fixed, and added to this repository's test cases, and then the process was repeated.
