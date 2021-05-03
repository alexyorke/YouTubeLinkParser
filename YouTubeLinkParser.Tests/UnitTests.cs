using System;
using Xunit;

namespace YouTubeLinkParser.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("", "", "", "", "")]
        [InlineData("http://youtu.be", "", "", "", "")]
        [InlineData("https://youtu.be", "", "", "", "")]
        [InlineData("http://youtube.es", "", "", "", "")]
        [InlineData("http://youtube.fr", "", "", "", "")]
        [InlineData("https://youtu.be/", "", "", "", "")]
        [InlineData("http://youtube.com", "", "", "", "")]
        [InlineData("http://www.youtu.be", "", "", "", "")]
        [InlineData("http://youtube.com/", "", "", "", "")]
        [InlineData("http://youtuber.com", "", "", "", "")]
        [InlineData("https://youtu.be/o1", "", "", "", "")]
        [InlineData("https://youtu.be/wf", "", "", "", "")]
        [InlineData("https://youtube.com", "", "", "", "")]
        [InlineData("http://m.youtube.com", "", "", "", "")]
        [InlineData("http://youtube.co.uk", "", "", "", "")]
        [InlineData("http://youtubetm.com", "", "", "", "")]
        [InlineData("http://m.youtube.com/", "", "", "", "")]
        [InlineData("http://tv.youtube.com", "", "", "", "")]
        [InlineData("http://www.youtube.be", "", "", "", "")]
        [InlineData("http://www.youtube.ca", "", "", "", "")]
        [InlineData("http://www.youtube.de", "", "", "", "")]
        [InlineData("http://www.youtube.es", "", "", "", "")]
        [InlineData("http://www.youtube.fr", "", "", "", "")]
        [InlineData("http://www.youtube.nl", "", "", "", "")]
        [InlineData("http://www.youturn.in", "", "", "", "")]
        [InlineData("http://wwwyoutube.com", "", "", "", "")]
        [InlineData("http://youtu.com/chel", "", "", "", "")]
        [InlineData("http://youtube.com.br", "", "", "", "")]
        [InlineData("http://youtube.con.mx", "", "", "", "")]
        [InlineData("http://youtube.jp.com", "", "", "", "")]
        [InlineData("https://m.youtube.com", "", "", "", "")]
        [InlineData("http://WWW.youtube.com", "", "", "", "")]
        [InlineData("http://Www.youtube.com", "", "", "", "")]
        [InlineData("http://www.youtube.com", "", "", "", "")]
        [InlineData("http://youtube.com/FBE", "FBE", "", "", "")]
        [InlineData("http://youtube.com/yua", "yua", "", "", "")]
        [InlineData("http://youtube.com/zeo", "zeo", "", "", "")]
        [InlineData("https://m.youtube.com/", "", "", "", "")]
        [InlineData("https://www.youtube.de", "", "", "", "")]
        [InlineData("http://youtube.com/2NE1", "2NE1", "", "", "")]
        [InlineData("http://youtube.com/2qwe", "2qwe", "", "", "")]
        [InlineData("http://youtube.com/ImD7", "ImD7", "", "", "")]
        [InlineData("http://youtu.be/ZnAOXV77zY", "", "", "ZnAOXV77zY", "")]
        [InlineData("http://youtube.com/c/EnTonicClan", "EnTonicClan", "", "", "")]
        [InlineData("http://youtube.com/c/GOLFVLOGSUK", "GOLFVLOGSUK", "", "", "")]
        [InlineData("http://youtube.com/c/GamermaisTV", "GamermaisTV", "", "", "")]
        [InlineData("http://youtube.com/c/GrapeCollie", "GrapeCollie", "", "", "")]
        [InlineData("http://youtube.com/oafonsomanuel", "oafonsomanuel", "", "", "")]
        [InlineData("http://youtube.com/obsoletecomic", "obsoletecomic", "", "", "")]
        [InlineData("http://youtube.com/oficialavioes", "oficialavioes", "", "", "")]
        [InlineData("http://youtube.com/omarcostorres", "omarcostorres", "", "", "")]
        [InlineData("http://youtube.com/onedreamqueen", "onedreamqueen", "", "", "")]
        [InlineData("http://youtube.com/paulinajeanne", "paulinajeanne", "", "", "")]
        [InlineData("http://youtube.de/paulshardware", "paulshardware", "", "", "")]
        [InlineData("http://youtube.com/xsilentharmony", "xsilentharmony", "", "", "")]
        [InlineData("http://youtube.com/youfreakinnerd", "youfreakinnerd", "", "", "")]
        [InlineData("http://youtube.com/zurgrinosports", "zurgrinosports", "", "", "")]
        [InlineData("https://gaming.youtube.com/ragefu", "ragefu", "", "", "")]
        [InlineData("https://m.youtube.com/+louieslife", " louieslife", "", "", "")]
        [InlineData("https://m.youtube.com/DobbsterGuy", "DobbsterGuy", "", "", "")]
        [InlineData("https://m.youtube.com/EmpressAshx", "EmpressAshx", "", "", "")]
        [InlineData("https://m.youtube.com/MrSinaloa83", "MrSinaloa83", "", "", "")]
        [InlineData("https://m.youtube.com/RaeHardesty", "RaeHardesty", "", "", "")]
        [InlineData("https://m.youtube.com/user/MyChiragh", "", "MyChiragh", "", "")]
        [InlineData("https://m.youtube.com/user/Myles6541", "", "Myles6541", "", "")]
        [InlineData("https://m.youtube.com/user/Nandethoo", "", "Nandethoo", "", "")]
        [InlineData("https://m.youtube.com/user/OhhBraazy", "", "OhhBraazy", "", "")]
        [InlineData("http://Www.youtube.com/Theguardiansyt", "Theguardiansyt", "", "", "")]
        [InlineData("http://WWw.youtube.com/user/Fripolter", "", "Fripolter", "", "")]
        [InlineData(
            "https://www.youtube.com/channel/UCs6yrV5tyhML5AdU7CBtrjg/featured?view_as=subscriberhttps://www.inst",
            "UCs6yrV5tyhML5AdU7CBtrjg", "", "", "")]
        [InlineData(
            "https://www.youtube.com/sharmsbarchannel.com/gh-3jel1/sharmsbar.blogspot.com/twitter.com/sharmsbar11",
            "sharmsbarchannel.com", "", "", "")]
        [InlineData(
            "https://www.youtube.com/user/DavizinhGamer?annotation_id=annotation_2496399845&feature=iv&src_vid=lt", "",
            "DavizinhGamer", "", "")]
        [InlineData(
            "https://www.youtube.com/user/LMCBK?sub_confirmation=1&feature=iv&src_vid=V0OS39-SraI&annotation_id=a", "",
            "LMCBK", "", "")]
        [InlineData(
            "https://www.youtube.com/user/MurciaFinest?sub_confirmation=1&src_vid=5k9J-Zc9oyQ&feature=iv&annotati", "",
            "MurciaFinest", "", "")]
        [InlineData(
            "https://www.youtube.com/user/Pyreable?annotation_id=annotation_2706611237&feature=iv&src_vid=cZY00Dg", "",
            "Pyreable", "", "")]
        [InlineData(
            "https://www.youtube.com/user/RYTSUKA?feature=iv&src_vid=yVWT6vAoVuE&annotation_id=571b74b6-0000-2a8e", "",
            "RYTSUKA", "", "")]
        [InlineData(
            "https://www.youtube.com/user/ad999ad1?ab_channel=%D0%92%D1%81%D0%B5%D0%B3%D0%B5%D0%BD%D0%B8%D0%B0%D0", "",
            "ad999ad1", "", "")]
        [InlineData(
            "https://www.youtube.com/user/koirusuker?ytsession=iM4t72zj8HhsRWo_KpTR1KKHabFxPBBvi2wIAd_iuslMGYXyrI", "",
            "koirusuker", "", "")]
        [InlineData(
            "https://www.youtube.com/user/patb71210https://www.youtube.com/user/patb71210https://www.youtube.com/", "",
            "patb71210", "", "")]
        [InlineData(
            "https://www.youtube.com/watch?v=8A-330Woido&lc=z23bi3oyjyfrcnrz004t1aokgkfgocgndnrykcwole2ebk0h00410", "",
            "", "8A-330Woido", "")]
        [InlineData(
            "https://www.youtube.com/watch?v=HHd97fvqByQ&feature=youtu.be&list=PL83H9RtLbsKel5quxs7SPZCtuEfBGpux-", "",
            "", "HHd97fvqByQ", "PL83H9RtLbsKel5quxs7SPZCtuEfBGpux-")]
        [InlineData(
            "https://www.youtube.com/watch?v=R9SQl0cSfI8&lc=z22ocf4qjuvvtrqnlacdp431jyew04jv04szzkrhq3dw03c010c.1", "",
            "", "R9SQl0cSfI8", "")]
        [InlineData(
            "https://youtube.com/watch?v=TKD03uPVD-Q&ebc=ANyPxKrI8x8GTrDKTOWZwqCcyNaL92Yt7G5KW36qoLx36iZnu_hp", "",
            "", "TKD03uPVD-Q", "")]
        [InlineData(
            "WWw.youtube.com/watch?v=VahPtB2GORc&list=RDMM_hdxEEB1EBQ&index=2https://www.youtube.com/watc", "",
            "", "VahPtB2GORc", "RDMM_hdxEEB1EBQ")]
        [InlineData(
            "https://www.Youtube.com/watch?v=YQ6GA2ZW88Y&lc=z23rgp2h2niifzqqu04t1aokgb4iyqzyvxtz1psid3qpbk0h00410", "",
            "", "YQ6GA2ZW88Y", "")]
        [InlineData(
            "https://www.youtube.Com/watch?v=ZzvK5uLu7F0&feature=iv&src_vid=es6U00LMmC4&annotation_id=annotation_", "",
            "", "ZzvK5uLu7F0", "")]
        [InlineData(
            "youtube.cOM/watch?v=fcc484IPwms&lc=z22jwjpb4qatyf2jn04t1aokgnjxnjta5nwc42vgzuo3rk0h00410", "",
            "", "fcc484IPwms", "")]
        [InlineData(
            "https://www.youtube.com/watch?v=ffxKSjUwKdUhttps://open.spotify.com/user/sofh6n1bkas3dhfr06x2u9lie/p", "",
            "", "ffxKSjUwKdU", "")]
        [InlineData(
            "https://www.youtube.com/watch?v=q4-fKQ4C8kY&feature=gp-n-y&google_comment_id=z12syd54wxrijdmeh23syd0", "",
            "", "q4-fKQ4C8kY", "")]
        [InlineData("https://www.youtube.com/playlist?list=PLYfTzYNWWppd5RROHhMs_HEzI5SkO5beZ", "", "", "",
            "PLYfTzYNWWppd5RROHhMs_HEzI5SkO5beZ")]
        [InlineData("https://www.youtube.com/playlist?list=PLYhKAl2FoGzCT_tUt4f_-L7t5KCihIw_w", "", "", "",
            "PLYhKAl2FoGzCT_tUt4f_-L7t5KCihIw_w")]
        [InlineData("https://www.youtube.com/playlist?list=PLYmfaMInSrAUgLlddz7gV8ISxdfC4Gefu", "", "", "",
            "PLYmfaMInSrAUgLlddz7gV8ISxdfC4Gefu")]
        [InlineData("https://www.youtube.com/playlist?list=PLYpYTXam-JvczdUFCS5nnBa3Z1LcVqga3", "", "", "",
            "PLYpYTXam-JvczdUFCS5nnBa3Z1LcVqga3")]
        [InlineData("https://www.youtube.com/playlist?list=PLYuM_5u2VWQjeGp7aannUAuyRMZysFkCq", "", "", "",
            "PLYuM_5u2VWQjeGp7aannUAuyRMZysFkCq")]
        [InlineData("https://www.youtube.com/user/lukasdu21?sub_confirmation=1?sub_confirmation=1", "", "lukasdu21",
            "", "")]
        [InlineData("https://www.youtube.com/user/souljaboy23100/videos?sort=dd&shelf_id=0&view=0", "",
            "souljaboy23100", "", "")]
        [InlineData("https://www.youtube.com/watch?v=qfSulwWRHdQ&start_radio=1&list=RDqfSulwWRHdQ", "", "",
            "qfSulwWRHdQ", "RDqfSulwWRHdQ")]
        [InlineData("https://www.youtube.com/watch?v=s0ECiff4cA4&index=18&list=PLBFF76C4369CACD4D", "", "",
            "s0ECiff4cA4", "PLBFF76C4369CACD4D")]
        [InlineData("https://m.youtube.com/heartbreakkelby?uid=ffWSuoUi9lPsvXppR_2OrA", "heartbreakkelby", "", "", "")]
        [InlineData("https://m.youtube.com/my_account?hl=en-GB&gl=ZA&client=mv-google", "", "", "", "")]
        [InlineData("https://m.youtube.com/results?q=%E7%A0%94%E7%A3%A8%E5%B8%AB&sm=1", "", "", "", "")]
        [InlineData("https://m.youtube.com/#/user/houstonhiphopfix?sub_confirmation=1", "", "houstonhiphopfix", "", "")]
        [InlineData("http://m.youtube.com/?reload=7&rdm=x9zii2sx#/watch?v=6DWquqxi058", "", "",
            "6DWquqxi058", "")]
        [InlineData("http://m.youtube.com/user/MrGameFox?gl=JP&hl=ja&client=mv-google", "", "MrGameFox", "", "")]
        [InlineData("http://m.youtube.com/watch?feature=player_embedded&v=FstzJLi555c", "", "", "FstzJLi555c", "")]
        [InlineData("http://m.youtube.com/watch?list=PL4054DFC93AC75A3A&v=iyBQQ7oQBmo", "", "", "iyBQQ7oQBmo",
            "PL4054DFC93AC75A3A")]
        [InlineData("http://www.youtube.com/subscription_center?add_user=luixtao", "", "luixtao", "", "")]
        [InlineData("http://www.youtube.com//SrPedro", "SrPedro", "", "", "")]
        [InlineData("http://m.youtube.com/user/XxMikexX19961?", "", "XxMikexX19961", "", "")]
        [InlineData("http://m.youtube.com/profile?gl=JP&hl=ja&client=yt_jp&user=098chouji", "", "098chouji", "", "")]
        [InlineData(
            "http://m.youtube.com/channel/UCFH0dDaATlEtN6_raS95CRA?desktop_uri=%2Fchannel%2FUCFH0dDaATlEtN6_raS95",
            "UCFH0dDaATlEtN6_raS95CRA", "", "", "")]
        [InlineData("https://www.youtube.com/\u00c9tienne-senpai", "\u00c9tienne-senpai", "", "", "")]
        [InlineData(
            "https://www.youtube.com/attribution_link?a=tolCzpA7CrY&u=%2Fwatch%3Fv%3DMoBL33GT9S8%26feature%3Dshare", "",
            "", "MoBL33GT9S8", "")]
        [InlineData("https://www.youtube.com/watch?v=MoBL33GT9S8&feature=share", "", "", "MoBL33GT9S8", "")]
        [InlineData("http://www.youtube.com/watch?v=iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("https://www.youtube.com/watch?v=iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/watch?v=iwGFalTRHDA&feature=related ", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://youtu.be/iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/embed/watch?feature=player_embedded&v=iwGFalTRHDA", "", "", "iwGFalTRHDA",
            "")]
        [InlineData("http://www.youtube.co.uk/embed/watch?v=iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/embed/v=iwGFalTRHDA", "", "", "", "")]
        [InlineData("http://www.youtube.com/watch?feature=player_embedded&v=iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/watch?v=iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
        [InlineData("www.youtube.com/watch?v=iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("www.youtu.be/iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("youtu.be/iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("youtube.com/watch?v=iwGFalTRHDA ", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/watch/iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/v/iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
        [InlineData("http://www.youtube.com/v/i_GFalTRHDA", "", "", "i_GFalTRHDA", "")]
        [InlineData("http://www.youtube.com/c/Étienne-senpai", "Étienne-senpai", "", "", "")]
        [InlineData("http://www.youtube.com/watch?v=i-GFalTRHDA&feature=related ", "", "", "i-GFalTRHDA", "")]
        [InlineData(
            "http://www.youtube.com/attribution_link?u=/watch?v=aGmiw_rrNxk&feature=share&a=9QlmP1yvjcllp0h3l0NwuA", "",
            "", "aGmiw_rrNxk", "")]
        [InlineData(
            "http://www.youtube.com/attribution_link?a=fF1CWYwxCQ4&u=/watch?v=qYr8opTPSaQ&feature=em-uploademail", "",
            "", "qYr8opTPSaQ", "")]
        [InlineData(
            "http://www.youtube.com/attribution_link?a=fF1CWYwxCQ4&feature=em-uploademail&u=/watch?v=qYr8opTPSaQ", "",
            "", "qYr8opTPSaQ", "")]
        [InlineData("https://www.youtube.com/watch?v=214DjEBtKlEu", "", "", "214DjEBtKlEu", "")]
        [InlineData("https://m.youtube.com/watch?feature=youtu.be&v=mSDs2PqQSeg%2FDUALSCLOCK", "", "", "mSDs2PqQSeg",
            "")]
        [InlineData("https://m.youtube.com/watch?v=69KKgRy6gno/hd", "", "", "69KKgRy6gno", "")]
        [InlineData("https://m.youtube.com/watch?v=99eU4cP4SOE/", "", "", "99eU4cP4SOE", "")]
        [InlineData("https://m.youtube.com/watch?v=FZ8IHtiotYg//https://m.youtube.com/watch?v=3_gL_H9zAY8", "", "",
            "FZ8IHtiotYg", "")]
        [InlineData("https://music.youtube.com/watch?v=WwjO7RKLMos&feature=share", "", "", "WwjO7RKLMos", "")]
        [InlineData("https://www.youtube.com/feed/UCAJu3Qyn_xK4GLltcCNbsjw", "UCAJu3Qyn_xK4GLltcCNbsjw", "", "", "")]
        [InlineData("https://www.youtube.com/watch?v=TM-gCW45YHcbe", "", "", "TM-gCW45YHcbe", "")]
        [InlineData("https://youtu.be/ZNyiOUPkiLQ,https://m.youtube.com/watch?feature=youtu.be&v=Vbg-F6soMBs", "", "",
            "Vbg-F6soMBs", "")]
        [InlineData("https://www.youtube.com/watch?v=mzVn2jlss", "", "", "mzVn2jlss", "")]
        [InlineData("https://m.youtube.com/?#/channel/UCXLPhUj3SutQwofHWXNL6tw", "UCXLPhUj3SutQwofHWXNL6tw", "", "",
            "")]
        [InlineData("https://m.youtube.com/?#/user/ViLEExtreamZ", "", "ViLEExtreamZ", "", "")]
        [InlineData(
            "https://www.youtube.com/channel/UCJ3wC_LyLPOrwhLpBu6KtnA?&ab_channel=UnsortedGaming-HaloForge,Custom",
            "UCJ3wC_LyLPOrwhLpBu6KtnA", "", "", "")]

        // https://stackoverflow.com/questions/3452546/how-do-i-get-the-youtube-video-id-from-a-url
        [InlineData("http://www.youtube.com/attribution_link?u=/watch?v=1p3vcRhsYGo&", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=/watch?v=1p3vcRhsYGo", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/user/username#p/a/u/2/videoidmaybe", "", "username", "videoidmaybe",
            "")] //?
        [InlineData("http://www.youtube.com/user/username#p/u/1/videoidmaybe?", "", "username", "videoidmaybe", "")] //?
        [InlineData("http://www.youtube.com/user/username#p/u/1/videoidmaybe", "", "username", "videoidmaybe", "")] //?
        [InlineData("www.youtube-nocookie.com/embed/1p3vcRhsYGo?", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=%2Fwatch%3Fv%3D*%26", "", "", "", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=%2Fwatch%3Fv%3D", "", "", "", "")]
        [InlineData("http://www.youtube.com/watch?v=u8nQa1cJyX8&a=GxdCwVVULXctT2lYDEPllDR0LRTutYfW", "", "",
            "u8nQa1cJyX8", "")]
        [InlineData("http://www.youtube.com/watch?v=u8nQa1cJyX8", "", "", "u8nQa1cJyX8", "")]
        [InlineData("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo", "", "Scobleizer", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/user/SilkRoadTheatre#p/a/u/2/6dwqZw0j_jY", "", "SilkRoadTheatre",
            "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/6dwqZw0j_jY", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/6dwqZw0j_jY ", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://www.youtube.com/watch?v=6dwqZw0j_jY&feature=youtu.be", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/afa-5HQHiAs", "", "", "afa-5HQHiAs", "")]
        [InlineData("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo?rel=0", "", "Scobleizer", "1p3vcRhsYGo",
            "")]
        [InlineData("http://www.youtube.com/watch?v=cKZDdG9FTKY&feature=channel", "", "", "cKZDdG9FTKY", "")]
        [InlineData("http://www.youtube.com/watch?v=yZ-K7nCVnBI&playnext_from=TL&videos=osPknwzXEas&feature=sub", "",
            "", "yZ-K7nCVnBI", "")]
        [InlineData("http://www.youtube.com/ytscreeningroom?v=NRHVzbJVx8I", "", "", "NRHVzbJVx8I", "")]
        [InlineData("http://www.youtube.com/embed/nas1rJpm7wY?rel=0", "", "", "nas1rJpm7wY", "")]
        [InlineData("http://www.youtube.com/watch?v=peFZbP64dsU", "", "", "peFZbP64dsU", "")]
        [InlineData("http://youtube.com/v/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/vi/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ",
            "")]
        [InlineData("http://youtube.com/?vi=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/watch?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/watch?vi=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtu.be/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/v/0zM3nApSvMg?fs=1&hl=en_US&rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/a/u/1/KdwsulMb8EQ", "", "IngridMichaelsonVEVO",
            "KdwsulMb8EQ", "")]
        [InlineData("http://youtu.be/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/embed/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/v/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/e/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/?v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?feature=player_embedded&v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/?feature=player_embedded&v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/u/11/KdwsulMb8EQ", "", "IngridMichaelsonVEVO",
            "KdwsulMb8EQ", "")]
        [InlineData("http://www.youtube-nocookie.com/v/6L3ZvIMwZFM?version=3&hl=en_US&rel=0", "", "", "6L3ZvIMwZFM",
            "")]
        [InlineData("http://www.youtube.com/v/0zM3nApSvMg?fs=1&amp;hl=en_US&amp;rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/embed/0zM3nApSvMg?rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=JcjoGn6FLwI&asdasd", "", "", "JcjoGn6FLwI", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg&feature=feedrec_grec_index", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/a/u/1/QdK8U-VIH_o", "", "IngridMichaelsonVEVO",
            "QdK8U-VIH_o", "")]
        [InlineData("http://youtube.googleapis.com/v/0zM3nApSvMg?fs=1&hl=en_US&rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg#t=0m10s", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://youtu.be/0zM3nApSvMg", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg/", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?feature=player_detailpage&v=8UVNT4wvIGY", "", "", "8UVNT4wvIGY", "")]
        [InlineData("https://youtu.be/oTJRivZTMLs?list=PLToa5JuFMsXTNkrLJbRlB--76IAOjRM9b", "", "", "oTJRivZTMLs",
            "PLToa5JuFMsXTNkrLJbRlB--76IAOjRM9b")]
        [InlineData("http://www.youtube.com/watch?v=oTJRivZTMLs&feature=youtu.be", "", "", "oTJRivZTMLs", "")]
        [InlineData("https://youtu.be/oTJRivZTMLs", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtu.be/oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://www.youtube.com/ytscreeningroom?v=oTJRivZTMLs", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://www.youtube.com/embed/oTJRivZTMLs?rel=0", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/v/oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/vi/oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/?v=oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/?feature=channel&v=oTJRivZTMLs", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/?vi=oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/watch?v=oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://youtube.com/watch?vi=oTJRivZTMLs&feature=channel", "", "", "oTJRivZTMLs", "")]
        [InlineData("http://www.youtube.com/user/dreamtheater#p/u/1/oTJRivZTMLs", "", "dreamtheater", "oTJRivZTMLs",
            "")]
        [InlineData("http://www.youtube.com/attribution_link?/watch?v=1p3vcRhsYGo", "", "", "1p3vcRhsYGo", "")]
        [InlineData("https://www.youtube.com.br/watch?v=J6MpBhzbRmI", "", "", "J6MpBhzbRmI", "")]
        [InlineData("https://www.youtube.com.sg/watch?v=J6MpBhzbRmI", "", "", "J6MpBhzbRmI", "")]
        [InlineData("https://www.youtube.com.co/watch?v=J6MpBhzbRmI", "", "", "J6MpBhzbRmI", "")]
        [InlineData("https://www.youtube/watch?v=J6MpBhzbRmI", "", "", "J6MpBhzbRmI", "")]
        [InlineData("http://www.youtube.com/watch?v=n1fhd1EzSikhttp://", "", "", "n1fhd1EzSik", "")]
        [InlineData("https://m.youtube.com/?gl=FI&hl=fi#/channel/UClCyQF7zEc22V19fShOlmEw", "UClCyQF7zEc22V19fShOlmEw",
            "", "", "")]
        [InlineData("https://m.youtube.com/?gl=MX&hl=es-419#/channel/UCKY2C2DEDpfjajrGedD9-Qg",
            "UCKY2C2DEDpfjajrGedD9-Qg", "", "", "")]
        [InlineData("https://m.youtube.com/?noapp=1#/channel/UC2Lqybb1xm9lXBU4QFEuCaw?noapp=1",
            "UC2Lqybb1xm9lXBU4QFEuCaw", "", "", "")]
        [InlineData("https://m.youtube.com/?noapp=1#/channel/UCJSoKroyNMMCxwOiJRNGEUw?noapp=1&app=m&persist_app=1",
            "UCJSoKroyNMMCxwOiJRNGEUw", "", "", "")]
        [InlineData("https://m.youtube.com/?noapp=1#/user/ObliviousAnimeGirl?noapp=1", "", "ObliviousAnimeGirl", "",
            "")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=1l9werhe#/watch?list=PL05E26E091BDF1DFA&v=aYrqwsHHalM", "", "",
            "aYrqwsHHalM", "PL05E26E091BDF1DFA")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=1mapy41ih#/channel/UC1hrmEG9Lgj6s2LbcGQJJ6A",
            "UC1hrmEG9Lgj6s2LbcGQJJ6A", "", "", "")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=2ehouu60s#/watch?v=Xa2_PInngII", "", "", "Xa2_PInngII", "")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=2fk82q2ph#/channel/UCdkjthibw6_8X8aLHb7fzwg",
            "UCdkjthibw6_8X8aLHb7fzwg", "", "", "")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=2fk82q71#/channel/UCa2hwtqYBp-nCfn-dd2bqDw",
            "UCa2hwtqYBp-nCfn-dd2bqDw", "", "", "")]
        [InlineData("https://m.youtube.com/?reload=7&rdm=2gzcg67km#/watch?v=NLiWFUDJ95I", "", "", "NLiWFUDJ95I", "")]
        [InlineData(
            "https://www.youtube.com/attribution_link?a=8d24G6ulBEpASrj5&u=/channel/UC3vBLJ_3rXevCJ_keDOPddA?feat",
            "UC3vBLJ_3rXevCJ_keDOPddA", "", "", "")]
        [InlineData("https://www.youtube.com/attribution_link?a=vGc4r4OsijuPt38V&u=/channel/UCzFlYStVgoieXzwLZ9J7n4w",
            "UCzFlYStVgoieXzwLZ9J7n4w", "", "", "")]
        [InlineData("https://www.youtube.com/watch?v=J6MpBhzbRmI?_confirmation=1", "", "", "J6MpBhzbRmI", "")]
        [InlineData("\"https://www.youtube.com/watch?v=J6MpBhzbRmI\"", "", "", "J6MpBhzbRmI", "")]
        [InlineData("'https://www.youtube.com/watch?v=J6MpBhzbRm'", "", "", "J6MpBhzbRm", "")]
        [InlineData("'https://www.youtube.com./watch?v=J6MpBhzbRm'", "", "", "J6MpBhzbRm", "")]
        [InlineData("'https://www.youtube.com.br./watch?v=J6MpBhzbRm'", "", "", "J6MpBhzbRm", "")]
        [InlineData("https://www.youtube.com/watch?v=J6MpBhzbRmhttps://example.com", "", "", "J6MpBhzbRm", "")]
        [InlineData("https://www.youtube.com/watch?v=J6MpBhzbRm|xyz", "", "", "J6MpBhzbRm", "")]
        [InlineData("http://www.youtube.com/user/ChakalXGamerhttp://", "", "ChakalXGamer", "", "")]
        [InlineData("https://youtu.be/tXT9Uh42dqk/Yo", "", "", "tXT9Uh42dqk", "")]
        [InlineData("https://youtu.be:8080/tXT9Uh42dqk/Yo", "", "", "tXT9Uh42dqk", "")]
        [InlineData("http://www.youtube.com/watch_popup?v=8WATgU5PduE&feature=youtu.be", "", "", "8WATgU5PduE", "")]
        [InlineData("http://www.youtube.com/#!/UCx3hvDAnx0mz452ssiUfV1Q", "UCx3hvDAnx0mz452ssiUfV1Q", "", "", "")]
        [InlineData("https://www.youtube.com/user/berube1297https://www.instagram.com/abcdef/", "", "berube1297", "",
            "")]
        [InlineData("https://youtu.be/addme/cFaHNoUZ3pVsG4MTfBNjKwBmOvzxtw", "", "cFaHNoUZ3pVsG4MTfBNjKwBmOvzxtw", "",
            "")]
        [InlineData("https://www.youtube.com/playlist?p=PLB66D7ED343F8246F", "", "", "",
            "PLB66D7ED343F8246F")]
        [InlineData("https://youtu.be/NXnHB5DMiBs,https://www.facebook.com/abcdefgh", "", "", "NXnHB5DMiBs",
            "")]
        public void TryParseValidUri(string url, string channelId, string userId, string videoId, string playlistId)
        {
            YoutubeUri.TryCreate(url, out var actual);
            Assert.Equal(userId, actual?.UserId ?? "");
            Assert.Equal(videoId, actual?.VideoId ?? "");
            Assert.Equal(channelId, actual?.ChannelId ?? "");
            Assert.Equal(playlistId, actual?.PlaylistId ?? "");
            Assert.NotNull(actual?.Uri?.ToString() ??
                           ""); // TODO: actually test this; this is just checking if it won't throw an exception
        }

        [Fact]
        public void CreateConstructor()
        {
            var expected = "i_GFalTRHDA";
            Assert.Equal(expected, new YoutubeUri("https://youtube.com/watch?v=i_GFalTRHDA").VideoId);
        }

        [Fact]
        public void IgnoreDomain()
        {
            var expected = "i_GFalTRHDA";
            Assert.Equal(expected, new YoutubeUri("https://example.com/watch?v=i_GFalTRHDA", true).VideoId);
        }

        [Fact]
        public void CreateInvalidUrl()
        {
            Assert.Throws<FormatException>(() => new YoutubeUri("https://google.com/"));
        }

        [Theory]
        [InlineData("https://www.youtube.com/results?search_query=jb+production+74", "jb production 74")]
        [InlineData("https://www.youtube.com/results?search_query=john+florence+dela+pena&sp=6gMA", "john florence dela pena")]
        [InlineData("https://www.youtube.com/results?search_query=%E6%B8%A9%E7%9B%B8%E8%AF%B4%E5%85%9A%E5%8F%B2", "温相说党史")]
        [InlineData("https://m.youtube.com/results?q=Bumblebee-3_3", "Bumblebee-3_3")]
        [InlineData("https://m.youtube.com/?#/results?q=minecraft%20gaming%20and%20other%20gaming%2012345&sm=1", "minecraft gaming and other gaming 12345")]
        [InlineData("https://m.youtube.com/#/results?q=thecoffeeclub&search_type=search_users&uploaded=", "thecoffeeclub")]
        [InlineData("http://youtube.com/results?gl=NG&client=mv-google&hl=en-GB&q=ajao+filmhead&submit=Search", "ajao filmhead")]
        public void SearchResults(string url, string result)
        {
            Assert.Equal(result, new YoutubeUri(url).SearchResults);
        }

        [Theory]
        [InlineData("http://www.youtube.com/daveythemack#p/a/u/0/XVtwwy0EzS8/")]
        [InlineData("http://www.youtube.com/subscription_center")]
        [InlineData("http://www.youtube.com/subscription_center/add_user/bbinme2005")]
        [InlineData("http://www.youtube.com/subscription_center/add_user=Digitrax83")]
        [InlineData("http://www.youtube.com/subscription_center/user_add?=Kenibi")]
        [InlineData("http://www.youtube.com/subscription_center?")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=Fausic&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=MeOwPl3aZ")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=MrSweenzo")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=PrettySketchyComedy")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=SlowActionMedia")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=jamie1051")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=l4zybrain")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;add_user=myoelectric")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;amp;add_user=tmz")]
        [InlineData("http://www.youtube.com/subscription_center?&amp;feature=iv&amp;add_user=MusickHD")]
        [InlineData("http://www.youtube.com/subscription_center?...")]
        [InlineData("http://www.youtube.com/subscription_center?/user=YapSap")]
        [InlineData("http://www.youtube.com/subscription_center?AllTimeGaming=SampleUser")]
        [InlineData("http://www.youtube.com/subscription_center?DapperZapperOMG=nalts")]
        [InlineData("http://www.youtube.com/subscription_center?_add_user=AgentXero")]
        [InlineData("http://www.youtube.com/subscription_center?a")]
        [InlineData("http://www.youtube.com/subscription_center?a...")]
        [InlineData("http://www.youtube.com/subscription_center?ad")]
        [InlineData("http://www.youtube.com/subscription_center?add")]
        [InlineData("http://www.youtube.com/subscription_center?add=trickshotfuryclanchannel")]
        [InlineData("http://www.youtube.com/subscription_center?add_")]
        [InlineData("http://www.youtube.com/subscription_center?add_streetfoodcatalog")]
        [InlineData("http://www.youtube.com/subscription_center?add_suer=InsaneBigmac")]
        [InlineData("http://www.youtube.com/subscription_center?add_u")]
        [InlineData("http://www.youtube.com/subscription_center?add_us")]
        [InlineData("http://www.youtube.com/subscription_center?add_user")]
        [InlineData("http://www.youtube.com/subscription_center?add_user+SecretFantasyConsole9000")]
        [InlineData("http://www.youtube.com/subscription_center?add_user/Butters134")]
        [InlineData("http://www.youtube.com/subscription_center?add_user/FusionShortGamer")]
        [InlineData("http://www.youtube.com/subscription_center?add_user?=DattatreyaSivaBaba")]
        [InlineData("http://www.youtube.com/subscription_center?add_user?=PillaiCenter")]
        [InlineData("http://www.youtube.com/subscription_center?add_userSeven7insHD")]
        [InlineData("http://www.youtube.com/subscription_center?add_userTriniSkiller")]
        [InlineData("http://www.youtube.com/subscription_center?add_user_id=TYe0IzGOeN_J8Lu_twNRyQ&feature")]
        [InlineData("http://www.youtube.com/subscription_center?add_user_id=zQAGI26H1wDJz_zQAKGAuA")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=............")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=...............")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_119208&amp;add_user=TheTomCoteShow&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_119208&amp;add_user=ingridgott")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_120459&amp;add_user=thezeostorm")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_16371&amp;amp...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_184247&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_204424&amp;amp;src_vid=p23cjN0_LpI&amp;amp;add_user=fullgrowngaming&amp;amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_211735&amp;feature=iv&amp;src_vid=hTuTbs3gP_k&amp;add_user=EchoesOfAnArtist")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_219787&amp;src_vid=wKHHNzhHd88&amp;add_user=shinytinselworm&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_220316&amp;feature=iv&amp;add_user=angelofdeathist&amp;src_vid=LWT28ezDxts")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_235639&amp;src_vid=IJkuSmKnz9I&amp;feature=iv&amp;add_user=JesusDiedFourDubstep")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_262707&amp;add_user=brooksbarry27&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_293422&amp;add_user=exedgaming&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_325250&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_328208&amp;feature=iv&amp;src_vid=sKPOFg17kc0&amp;add_user=GameBreakingNews")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_341541&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_341541&amp;am......")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_341541&amp;feature=iv&amp;add_user=thetoshpoint&amp;src_vid=GXUphyeOjko")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_377894&amp;add_user=ThastorG&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_394926&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_394926&amp;am......")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_394926&amp;am.........")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_394926&amp;feature=iv&amp;add_user=Soundofhardstylez")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_407898&amp;src_vid=pZdKZSNiRW4&amp;feature=iv&amp;add_user=shinytinselworm")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_461015&amp;am...........")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_471705&amp;feature=")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_471705&amp;feature=iv&amp;add_user=jesusdiedfourdubstep")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_480060&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_480060&amp;feature=iv&amp;add_user=gagewyand")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_496155&amp;feature=iv&amp;src_vid=F7GXKKxAU8I&amp;add_user=isplatz")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_536473&amp;src_vid=ZoMT7ysHhBc&amp;feature=iv&amp;add_user=xoxocodfatherxoxo")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_543511&amp;src_vid=GKU_ya8Op-w&amp;add_user=jinnyboytv&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_561141&amp;add_user=itsjudytime&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_620104&amp;amp;feature=iv&amp;amp;src_vid=eJWiq3yTF48&amp;amp;add_user=thisisj0nny")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_620104&amp;feature=iv&amp;src_vid=eJWiq3yTF48&amp;add_user=thisisj0nny)")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_626715&amp;feature=iv&amp;add_user=MomentumFuelGaming")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_626715&amp;feature=iv&amp;add_user=Whitkidout")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_655342&amp;feature=iv&amp;src_vid=_obuSBcKKDA&amp;add_user=Buderptheminer")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_683495&amp;add_user=Eviltest&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_732456&amp;add_user=NOTWPhoneHacking&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_745623&amp;src_vid=nsixo5vfyVs&amp;add_user=InfamousNooneHD&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_750112&amp;feature=iv&amp;add_user=embrasiverecords")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_795358&amp;feature=iv&amp;add_user=xrsneirx")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_848109&amp;add_user=Forced3strategy&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_861724&amp;feature=iv&amp;add_user=destinws2")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_87173&amp;add_user=TheMinnowFlakes&amp;feature=iv&amp;src_vid=FPqbDXEaSW0")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_884471&amp;add_user=Childrenvids&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_905828&amp;am...")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_905828&amp;am......")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_905828&amp;feature=iv&amp;add_user=thebuttonmasherz")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=AlterKMusic")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=LuffyDaiMaoh")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=MarbleMusicFrance")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=MyCrazyGamingTv")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=RhumelDarwin")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=brice661000")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=desirerecords")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=gw2bane")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=leklubdesloosers")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=leonizerrecords")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=marblemusicfrance")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=naiveplaylist")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_912353&amp;feature=iv&amp;add_user=valeknoraj")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_96082&amp;")]
        [InlineData("http://www.youtube.com/subscription_center?annotation_id=annotation_zW3fSIW963Omq9WJ_rXOJA&amp;feature=iv&amp;add_user=Oguzcan94500")]
        [InlineData("http://www.youtube.com/subscription_center?dumbass3570?sub_confirmation=1")]
        [InlineData("http://www.youtube.com/subscription_center?feature=&amp;add_user=OriginalWake")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Ark223Neww&amp;annotation_id=annotation_572849&amp;src_vid=GuKb2ukn2WQ")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Aviationnation10&amp;src_vid=_KZDha_obn8&amp;annotation_id=annotation_398377")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=DarkXMedia")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Doubleclic...")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Doubleclickgaming&amp;src_vid=SCpx2bhXu9c&amp;annotation_id=annotation_381570")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=LarryBundyJr&amp;annotation_id=annotation_407321&amp;src_vid=xZ3fVEA8lNE")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Nemakian")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=SenseTM")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=Subtokyo")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=TheDeadlyG...")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=TheDeadlyGames")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=YouMinecraftMe&amp;src_vid=ZYPjc9eSOYw&amp;annotation_id=_annotation_326408")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=ZhaikerCO&amp;src_vid=awioG4sFl4E&amp;annotation_id=annotation_569103")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=atalaykro1&amp;src_vid=MvIjEOsHeWs&amp;annotation_id=annotation_489828")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=budgiekens&amp;annotation_id=annotation_871987&amp;src_vid=PEf29fBMzUA")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=corruptcar...◄◄◄")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=corruptcarnage2◄◄◄")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=deadlyslob")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=destinws2&amp;annotation_id=annotation_871932")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=evenmorsuckedoff&amp;src_vid=R5WMbu70Bio&amp;annotation_id=annotation_394418")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=iduel2010")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=leafyishere")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=minecraftdotnet&amp;")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=mvito22")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=myoelectric&amp;annotation_id=annotation_157043")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=nemakian")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=roniada&amp;src_vid=MJKBQ6_GvLo&amp;annotation_id=annotation_683910")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;add_user=warriorNoah1")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;amp;annotation_id=annotation_113962&amp;amp;src_vid=M4_mHNP0pxU&amp;amp;add_user=GameBreakingNews")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;amp;src_vid=sKPOFg17kc0&amp;amp;add_user=GameBreakingNews&amp;amp;annotation_id=annotation_328208")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_113962&amp;src_vid=M4_mHNP0pxU&amp;add_user=GameBreakingNews")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_268445&amp;add_user=letsfifa11")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_366620&amp;add_user=ChimneySwift11&amp;src_vid=TD5YFNwGpA8")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_389571&amp;add_user=jamie1051")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_458834&amp;src_vid=DalL9C98Ixw&amp;add_user=cvg")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_482032&amp;add_user=kingofcod9988")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_550888&amp;add_user=hdrafiki")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_638036&amp;src_vid=UvJQR8igZaA&amp;add_user=Tupacalol")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_638036&amp;src_vid=UvJQR8igZaA&amp;add_user=brannddonnn")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_799586&amp;src_vid=8XdpqQb9tvw&amp;add_user=YouMinecraftMe")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_848298&amp;src_vid=ex33wtqnNz8&amp;add_user=callhercass")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_945287&amp;src_vid=BPTzlHOkOKw&amp;add_user=boredmunkey")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_946065&amp;src_vid=YKwHtJklhwQ&amp;add_user=multijumper1")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;annotation_id=annotation_993346&amp;add_user=MrHardstyleMusic1&amp;src_vid=OVeAO_f3wnk")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=2F0IDhn6P4Q&amp;annotation_id=annotation_239778&amp;add_user=forgeddubstep")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=4ntp6Lc3ziM&amp;annotation_id=annotation_601235&amp;add_user=damnelevator")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=6ORgqgq7KsI&amp;add_user=Fausic&amp;annotation_id=annotation_912855")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=6ORgqgq7KsI&amp;annotation_id=annotation_912855&amp;add_user=Fausic")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=HtQLaxZ4x34&amp;add_user=TheFloRapiShow")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=HtQLaxZ4x34&amp;add_user=teamkleb")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=HtQLaxZ4x34...")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=QbsVHYYaxwE&amp;annotation_id=annotation_221675&amp;add_user=GirlBandicoot")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=QbsVHYYaxwE&amp;annotation_id=annotation_221675&amp;add_user=Tyrannicon")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=R4d6i9CUWtM&amp;add_user=ThatRaGe")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=RQ08vmHUFi0&amp;add_user=YoBoHoMusic&amp;annotation_id=annotation_859526")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=b8MIQtaLl7s&amp;add_user=NateandBlyd&amp;annotation_id=annotation_810808")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=b8MIQtaLl7s...")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=dpLdo3qwgEE&amp;add_user=lockevalor&amp;annotation_id=annotation_440639")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=nre8xLHdw1c&amp;add_user=MaxLittleTV&amp;annotation_id=annotation_201843")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=qldHofVUQ40&amp;annotation_id=annotation_972603&amp;add_user=Caj814")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=sKPOFg17kc0&amp;add_user=GameBreakingNews&amp;annotation_id=annotation_328208")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=vYXOC6cnDOY&amp;add_user=MrHardstyleMusic1&amp;annotation_id=annotation_495378")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=yKjVCQZnVvU&amp;annotation_id=annotation_436513&amp;add_user=lockevalor")]
        [InlineData("http://www.youtube.com/subscription_center?feature=iv&amp;src_vid=yvgkbql-MUM&amp;add_user=battlebunny008&amp;annotation_id=annotation_943297")]
        [InlineData("http://www.youtube.com/subscription_center?gl=AU&amp;add_user=homehandyhints&amp;hl=en-GB")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=1PRICEISRIGHT1&amp;hl=en")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=BroBannix")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=TrioGamingAU")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=darrellnjoeunplugged&amp;hl=en")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=fractureb0x")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=fracturebox")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=mrtouchatwin")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;add_user=rknapton3")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;h1-en&amp;add_user=nuancerec")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=Batibangla")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=CGPMUSICGROUP")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=EmbracingTime")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=Fearlessflourish")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=Gamerkid3D")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=HDGamingChamps")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=HermesPlays")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=HumzaSaleem1")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=JesserPlays")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=JuniorAussie")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=MrPsycoticGamerHD")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=NatharamaGaming")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=OhTyZer")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=RecnoTech")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=RedCarpetNewsTV")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=Sport...")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=SuperSyro1")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=TheTuttiGamer")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=Topnimanga")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=UCBSRng9uP2viupw6sHL1_TQ")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=bunnehrealm")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=chocchipgames")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=dutyfreecritic")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=edxhendy")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=hippyratboy")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=iXioneris")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=im6p")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=m4keshiftmichelle")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=misterchris212")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=mixgods")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=mtgeek92")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=rocksoundmagazine")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=thegamerturnip")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=thethrasherash")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=tootupontheroof")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=videonexus1")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=weareshiningukSpotify")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=yub")]
        [InlineData("http://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;cadd_user=fayrofalcone")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=Auxeum")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=BlankmindTV")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=DIAMETERgaming")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=GenuineFail&amp;hl=en-GB")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=LeagueMiners&amp;hl=en-GB")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=LongCinema")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=MrSneakymode")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=SxGamingHD")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=XCVGames")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=XCVii007r1")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=darkroomlivestream&amp;hl=en-GB")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=magicalkillacow")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=oPhreaKo&amp;hl...")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=rezrift")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=sneakyplays")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=squarefreaks")]
        [InlineData("http://www.youtube.com/subscription_center?gl=GB&amp;add_user=supercatei")]
        [InlineData("http://www.youtube.com/subscription_center?gl=NL&amp;hl=nl&amp;gl=NL&amp;hl=nl&amp;gl=GB&amp;hl=nl-GB&amp;add_user=FunkyMusic09")]
        [InlineData("http://www.youtube.com/subscription_center?gl=UK&amp;hl=en&amp;add_user=webegamers101")]
        [InlineData("http://www.youtube.com/subscription_center?gl=US&amp;hl=en&amp;add_user=yodaproductions")]
        [InlineData("http://www.youtube.com/subscription_center?name_user=tomvlogss")]
        [InlineData("http://www.youtube.com/subscription_center?nataliemanquemilla")]
        [InlineData("http://www.youtube.com/subscription_center?redirected=1&amp;add_user=Fausic")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=-mvcv_7cBBc&amp;add_user_id=RoyXB7m3rOZf5wW8CSE1uw&amp;feature=player_profilepage")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=-thsYPZRoLU&amp;feature=iv&amp;add_user=kuuskeinar")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=5_capZ_hrq4&amp;annotation_id=annotation_550952&amp;add_user=MrOnGamer&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=6ORgqgq7KsI&amp;annotation_id=annotation_912855&amp;add_user=Fausic&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=7x2WQ6XLv_o&amp;annotation...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=MichaelRiveraTV")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=iarcadiahd")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=irawrfilms")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=ithegamermatrix")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=mkicevsfire")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=skatejns)")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;add_user=soupwar01")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=C2vatz0nuLo&amp;amp;add_user=skatejns")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=CQInIHbbE28&amp;feature=iv&amp;annotation_id=annotation_720413&amp;add_user=rapptappnique")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=D2gH3UEaiqQ&amp;annotation_id=annotation_181482&amp;feature=iv&amp;add_user=teampandah")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=D_bDgj7-z3w&amp;add_user=Tyrannicon&amp;feature=iv&amp;annotation_id=annotation_911234")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=EI7Okdx76cg&amp;annotation_id=annotation_465011&amp;feature=iv&amp;add_user=mrmitchelltang")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=IW2XPlgGw84&amp;add_user=Tyrannicon&amp;feature=iv&amp;annotation_id=annotation_225882")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=KEsLUL3A9xw&amp;amp;annotation_id=annotation_327400&amp;amp;add_user=gamebreakingnews&amp;amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=KEsLUL3A9xw&amp;annotation_id=annotation_327400&amp;add_user=gamebreakingnews&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=LV3LGdk9Ros&amp;annotation...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=Lf_ECl-I_YY&amp;add_user=YouMinecraftMe")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=OPksy4MaiL8&amp;add_user=lockevalor&amp;feature=iv&amp;annotation_id=annotation_121531")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=QTvgWa3Fhfo&amp;add_user=nevarky")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=QXg7F559exQ&amp;annotation_id=annotation_114813&amp;feature=iv&amp;add_user=Tyrannicon")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=TA3_omQeN38&amp;add_user=t...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=TIrkqKDZHis&amp;annotation_id=annotation_320227&amp;feature=iv&amp;add_user=rooftopcomedy")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=XiY8USKX75w&amp;add_user=snebzor&amp;annotation_id=annotation_140782&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=XlIoM0YzqNg&amp;feature=player_profilepage&amp;add_user_id=N2H9-raPzUYS9oxsa7NFlA")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=ZdXSgcm3L4Q&amp;add_user=mikd3egz&amp;annotation_id=annotation_150588&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=aBfxbWyHNhw&amp;annotation_id=annotation_513376&amp;feature=iv&amp;add_user=erik0gjoa")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=cTUDMqGVZTQ&amp;add_user=big2000dave&amp;annotation_id=annotation_456191&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=eExAiNMuWa0&amp;annotation_id=annotation_186586&amp;add_user=StrangeAddictionEps&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=eExAiNMuWa0&amp;annotation_id=annotation_186586&amp;add_user=StrangeAddictionEps2&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=eExAiNMuWa0&amp;annotation_id=annotation_186586&amp;add_user=StrangeAddictionEps3&amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=frUO65rWSmU&amp;add_user=gordonramsay&amp;feature=iv&amp;annotation_id=annotation_508980")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=fwPep6JDU5g&amp;annotation_id=annotation_151427&amp;feature=iv&amp;add_user=lockevalor")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=fxxLplH3AlA&amp;add_user=TheCodSewer")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=h4bvKzRbr8I&amp;add_user=T...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=i8zQj-oe2ME&amp;add_user=labo3tbl&amp;feature=iv&amp;annotation_id=annotation_584876")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=k4ssybltwks&amp;annotation_id=annotation_203163&amp;add_user=Carckass9292&amp;feature=iv.")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=kL6cNXJOcF8&amp;add_user=M...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=kL6cNXJOcF8&amp;add_user=Mikeylambinicio")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=kcbDw4zZepo&amp;feature=player_embedded&amp;add_user=swe1man")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=m0F2oYKVN1U&amp;add_user=MJuniversHD")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=meBgFFTuEss&amp;add_user=staticdon79&amp;feature=iv&amp;annotation_id=annotation_152198")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=n1MUirzhRak&amp;add_user=Jruberti&amp;annotation_id=annotation_363185&amp;feature=iv)")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=n1MUirzhRak&amp;amp;add_user=Jruberti&amp;amp;annotation_id=annotation_363185&amp;amp;feature=iv")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=sjbFhof2eeY&amp;add_user_id=nGneEhfpadP64ukxmo_nyw&amp;feature=player_profilepage")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=svd2K_djoJQ&amp;add_user=p...")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=xHgAJ86lOjA&amp;annotation_id=annotation_783309&amp;feature=iv&amp;add_user=TheBlackVikingHD")]
        [InlineData("http://www.youtube.com/subscription_center?src_vid=xHgAJ86lOjA&amp;annotation_id=annotation_783309&amp;feature=iv&amp;add_user=tomatsplashet")]
        [InlineData("http://www.youtube.com/user/LunarMonday#p/u/")]
        [InlineData("http://www.youtube.com/user/nfb#p/u/1/YzGvZ91_Ifo/?ntpg_src=links&amp;ntpg_sid=kr_rd_20111021")]
        [InlineData("http://www.youtube.com/user/nqtv?feature=chclk#p/u/")]
        [InlineData("http://www.youtube.com/user/onwavetv/#p/u/")]
        [InlineData("http://www.youtube.com/user/seddieloverx?feature=mhee#p/a/u/0/")]
        [InlineData("http://www.youtube.com/user/simonscat?blend=1&amp;ob=4#p/u/")]
        [InlineData("http://youtube.com/subscription_center?")]
        [InlineData("http://youtube.com/subscription_center?AussieStarcraft")]
        [InlineData("http://youtube.com/subscription_center?SUBSCRIBE")]
        [InlineData("http://youtube.com/subscription_center?a")]
        [InlineData("http://youtube.com/subscription_center?add")]
        [InlineData("http://youtube.com/subscription_center?add_ealygal")]
        [InlineData("http://youtube.com/subscription_center?add_username=mraaronashmore")]
        [InlineData("http://youtube.com/subscription_center?johnboden2k")]
        [InlineData("https://www.youtube.com/subscription_center?")]
        [InlineData("https://www.youtube.com/subscription_center?&amp;add_user=MesmerGaming")]
        [InlineData("https://www.youtube.com/subscription_center?GRTLShow=nalts")]
        [InlineData("https://www.youtube.com/subscription_center?ad...")]
        [InlineData("https://www.youtube.com/subscription_center?add=Hiroki.A")]
        [InlineData("https://www.youtube.com/subscription_center?add_")]
        [InlineData("https://www.youtube.com/subscription_center?add_channel=UCg40DVPD7jtlIOIyLMfUomw")]
        [InlineData("https://www.youtube.com/subscription_center?add_channel=UCuvVvG_Fc4hYs_fBSKmof1w")]
        [InlineData("https://www.youtube.com/subscription_center?add_u")]
        [InlineData("https://www.youtube.com/subscription_center?add_us26er=nalts")]
        [InlineData("https://www.youtube.com/subscription_center?add_us2er=midlerp")]
        [InlineData("https://www.youtube.com/subscription_center?add_user+swollnetts")]
        [InlineData("https://www.youtube.com/subscription_center?add_user_AimHeadshot1")]
        [InlineData("https://www.youtube.com/subscription_center?adduser_user=fatalismfilms")]
        [InlineData("https://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=82Gentleman")]
        [InlineData("https://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=DDayOf")]
        [InlineData("https://www.youtube.com/subscription_center?gl=CA&amp;hl=en&amp;add_user=TheMegamindVideos")]
        [InlineData("https://www.youtube.com/subscription_center?pewdiepie")]
        [InlineData("https://www.youtube.com/subscription_center?sebastianvsp")]
        [InlineData("https://www.youtube.com/watch?v=yTzhJfG6xcQ&amp;feature=share Mega tog über Gold-Wascieität dieses\"Gold für alle\" und hier G Rabatt bis zu 50% 😉👉 https://my.zzz.at/register/?id=123456")]
        [InlineData("https://youtube.com/subscription_center?add_channel=UCg40DVPD7jtlIOIyLMfUomw")]

        public void ShouldNotThrowException(string url)
        {
            YoutubeUri.TryCreate(url, out _);
        }
    }
}