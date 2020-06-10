using System;
using System.Collections.Generic;
using System.Text;

namespace TuEnvio.Utils
{
    public static class UtilsXF
    {
        public static double GetScreenWidth()
        {
            double width;
            if (App.HostApp.MainPage != null)
                width = App.HostApp.MainPage.Width;
            else
            {
#if __IOS__
                width = 200;
#else
                width = 300;
#endif
            }

            return width;
        }

        public static double GetScreenHeight()
        {
            double height;
            if (App.HostApp.MainPage != null)
                height = App.HostApp.MainPage.Height;
            else
            {
#if __IOS__
                height = 200;
#else
                height = 300;
#endif
            }

            return height;
        }



        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= 'á' && c <= 'ú') || c == '.' || c == '_' || c == '-' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
