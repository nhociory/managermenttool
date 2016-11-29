using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamagermentToolApi.Utils
{
    public class Constant
    {
        public static string baoMoiFeedUrl = "http://m.baomoi.com/trang[page].epi";
        public static string baoMoiHost = "http://m.baomoi.com";
        public static string replaceUrlBaoMoi = "[page]";
        public static string patternFeedBaoMoi = "<a.href=\"(.*.epi)\".title=\"(.*)\">\\s\\S.*\\s\\Simg.data-src=\"(.*)\".src.*\\s\\S.*\\s\\S.*\\s\\S.*\\s\\S.*\\s\\S.*\\s\\S.*\\s\\S.*\\s\\Sspan>(.*)<.*\\s\\S.*=\"(.*)\"><.*>\\s\\S.*[i>]\\s\\S*\\s\\S.*\\s(.*)";
    }
}
