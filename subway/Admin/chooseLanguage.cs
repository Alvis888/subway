using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subway.Admin
{
    public class chooseLanguage
    {
        private static string currentCultureName = "zh-cn";
        public chooseLanguage() { }
        public static object cc
        {
            get
            {
                switch(currentCultureName)
                {
                    case "zh-cn":return new ResxResources.zh_cn();
                    case "en-us": return new ResxResources.en_us();
                    default: return new ResxResources.zh_cn();
                }
            }
        }
    }
}
