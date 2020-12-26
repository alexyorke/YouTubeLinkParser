using System;
using Xunit;

namespace YouTubeLinkParser.Tests
{
    public class UnitTests
    {
        [Theory]
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
            "", "", "")]
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
            "", "", "")]
        [InlineData(
            "https://www.youtube.com/watch?v=q4-fKQ4C8kY&feature=gp-n-y&google_comment_id=z12syd54wxrijdmeh23syd0", "",
            "", "q4-fKQ4C8kY", "")]
        [InlineData("https://www.youtube.com/playlist?list=PLYfTzYNWWppd5RROHhMs_HEzI5SkO5beZ", "", "", "", "PLYfTzYNWWppd5RROHhMs_HEzI5SkO5beZ")]
        [InlineData("https://www.youtube.com/playlist?list=PLYhKAl2FoGzCT_tUt4f_-L7t5KCihIw_w", "", "", "", "PLYhKAl2FoGzCT_tUt4f_-L7t5KCihIw_w")]
        [InlineData("https://www.youtube.com/playlist?list=PLYmfaMInSrAUgLlddz7gV8ISxdfC4Gefu", "", "", "", "PLYmfaMInSrAUgLlddz7gV8ISxdfC4Gefu")]
        [InlineData("https://www.youtube.com/playlist?list=PLYpYTXam-JvczdUFCS5nnBa3Z1LcVqga3", "", "", "", "PLYpYTXam-JvczdUFCS5nnBa3Z1LcVqga3")]
        [InlineData("https://www.youtube.com/playlist?list=PLYuM_5u2VWQjeGp7aannUAuyRMZysFkCq", "", "", "", "PLYuM_5u2VWQjeGp7aannUAuyRMZysFkCq")]
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
            "", "")] // loads to youtube.com on a desktop browser (not the video)
        [InlineData("http://m.youtube.com/user/MrGameFox?gl=JP&hl=ja&client=mv-google", "", "MrGameFox", "", "")]
        [InlineData("http://m.youtube.com/watch?feature=player_embedded&v=FstzJLi555c", "", "", "FstzJLi555c", "")]
        [InlineData("http://m.youtube.com/watch?list=PL4054DFC93AC75A3A&v=iyBQQ7oQBmo", "", "", "iyBQQ7oQBmo", "PL4054DFC93AC75A3A")]
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
        [InlineData("http://www.youtube.com/embed/watch?feature=player_embedded&v=iwGFalTRHDA", "", "", "iwGFalTRHDA", "")]
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
        [InlineData("https://m.youtube.com/watch?feature=youtu.be&v=mSDs2PqQSeg%2FDUALSCLOCK", "", "", "mSDs2PqQSeg", "")]
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
        [InlineData("https://m.youtube.com/?#/channel/UCXLPhUj3SutQwofHWXNL6tw", "UCXLPhUj3SutQwofHWXNL6tw", "", "", "")]
        [InlineData("https://m.youtube.com/?#/user/ViLEExtreamZ", "", "ViLEExtreamZ", "", "")]
        [InlineData(
            "https://www.youtube.com/channel/UCJ3wC_LyLPOrwhLpBu6KtnA?&ab_channel=UnsortedGaming-HaloForge,Custom",
            "UCJ3wC_LyLPOrwhLpBu6KtnA", "", "", "")]
        
        // https://stackoverflow.com/questions/3452546/how-do-i-get-the-youtube-video-id-from-a-url
        [InlineData("http://www.youtube.com/attribution_link?u=/watch?v=1p3vcRhsYGo&", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=/watch?v=1p3vcRhsYGo", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/user/username#p/a/u/2/videoidmaybe", "", "username", "videoidmaybe", "")] //?
        [InlineData("http://www.youtube.com/user/username#p/u/1/videoidmaybe?", "", "username", "videoidmaybe", "")]//?
        [InlineData("http://www.youtube.com/user/username#p/u/1/videoidmaybe", "", "username", "videoidmaybe", "")]//?
        [InlineData("www.youtube-nocookie.com/embed/1p3vcRhsYGo?", "", "", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=%2Fwatch%3Fv%3D*%26", "", "", "", "")]
        [InlineData("http://www.youtube.com/attribution_link?u=%2Fwatch%3Fv%3D", "", "", "", "")]
        [InlineData("http://www.youtube.com/watch?v=u8nQa1cJyX8&a=GxdCwVVULXctT2lYDEPllDR0LRTutYfW", "", "", "u8nQa1cJyX8", "")]
        [InlineData("http://www.youtube.com/watch?v=u8nQa1cJyX8", "", "", "u8nQa1cJyX8", "")]
        [InlineData("//www.youtube-nocookie.com/embed/up_lNV-yoK4?rel=0", "", "", "up_lNV-yoK4", "")]
        [InlineData("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo", "", "Scobleizer", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/user/SilkRoadTheatre#p/a/u/2/6dwqZw0j_jY", "", "SilkRoadTheatre", "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/6dwqZw0j_jY", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/6dwqZw0j_jY ", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://www.youtube.com/watch?v=6dwqZw0j_jY&feature=youtu.be", "", "", "6dwqZw0j_jY", "")]
        [InlineData("http://youtu.be/afa-5HQHiAs", "", "", "afa-5HQHiAs", "")]
        [InlineData("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo?rel=0", "", "Scobleizer", "1p3vcRhsYGo", "")]
        [InlineData("http://www.youtube.com/watch?v=cKZDdG9FTKY&feature=channel", "", "", "cKZDdG9FTKY", "")]
        [InlineData("http://www.youtube.com/watch?v=yZ-K7nCVnBI&playnext_from=TL&videos=osPknwzXEas&feature=sub", "", "", "yZ-K7nCVnBI", "")]
        [InlineData("http://www.youtube.com/ytscreeningroom?v=NRHVzbJVx8I", "", "", "NRHVzbJVx8I", "")]
        [InlineData("http://www.youtube.com/embed/nas1rJpm7wY?rel=0", "", "", "nas1rJpm7wY", "")]
        [InlineData("http://www.youtube.com/watch?v=peFZbP64dsU", "", "", "peFZbP64dsU", "")]
        [InlineData("http://youtube.com/v/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/vi/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/?vi=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/watch?v=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtube.com/watch?vi=dQw4w9WgXcQ&feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://youtu.be/dQw4w9WgXcQ?feature=youtube_gdata_player", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/v/0zM3nApSvMg?fs=1&hl=en_US&rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/a/u/1/KdwsulMb8EQ", "", "IngridMichaelsonVEVO", "KdwsulMb8EQ", "")]
        [InlineData("http://youtu.be/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/embed/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/v/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/e/dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/?v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/watch?feature=player_embedded&v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/?feature=player_embedded&v=dQw4w9WgXcQ", "", "", "dQw4w9WgXcQ", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/u/11/KdwsulMb8EQ", "", "IngridMichaelsonVEVO", "KdwsulMb8EQ", "")]
        [InlineData("http://www.youtube-nocookie.com/v/6L3ZvIMwZFM?version=3&hl=en_US&rel=0", "", "", "6L3ZvIMwZFM", "")]
        [InlineData("http://www.youtube.com/v/0zM3nApSvMg?fs=1&amp;hl=en_US&amp;rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/embed/0zM3nApSvMg?rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=JcjoGn6FLwI&asdasd", "", "", "JcjoGn6FLwI", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg&feature=feedrec_grec_index", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/user/IngridMichaelsonVEVO#p/a/u/1/QdK8U-VIH_o", "", "IngridMichaelsonVEVO", "QdK8U-VIH_o", "")]
        [InlineData("http://youtube.googleapis.com/v/0zM3nApSvMg?fs=1&hl=en_US&rel=0", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg#t=0m10s", "", "", "0zM3nApSvMg", "")]
       
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://youtu.be/0zM3nApSvMg", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?v=0zM3nApSvMg/", "", "", "0zM3nApSvMg", "")]
        [InlineData("http://www.youtube.com/watch?feature=player_detailpage&v=8UVNT4wvIGY", "", "", "8UVNT4wvIGY", "")]
        [InlineData("https://youtu.be/oTJRivZTMLs?list=PLToa5JuFMsXTNkrLJbRlB--76IAOjRM9b", "", "", "oTJRivZTMLs", "PLToa5JuFMsXTNkrLJbRlB--76IAOjRM9b")]
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
        [InlineData("http://www.youtube.com/user/dreamtheater#p/u/1/oTJRivZTMLs", "", "dreamtheater", "oTJRivZTMLs", "")]
        [InlineData("http://www.youtube.com/attribution_link?/watch?v=1p3vcRhsYGo", "", "", "1p3vcRhsYGo", "")]
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
        public void CreateInvalidUrl()
        {
            Assert.Throws<FormatException>(() => new YoutubeUri("https://google.com/"));
        }
    }
}
