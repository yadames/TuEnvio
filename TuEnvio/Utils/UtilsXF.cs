using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Model;

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

        public static List<Tienda> StringToTiendas(string tiendasConf)
        {
            List<Tienda> listado = new List<Tienda>();
            string[] tiendas = tiendasConf.Split('%');
            foreach (string tienda in tiendas)
            {
                string[] conf = tienda.Split('|');
                listado.Add(new Tienda { Nombre = conf[0], Provincia = conf[1], URL = conf[2], IsEnable = Boolean.Parse(conf[3]), CanSearch = Boolean.Parse(conf[4]) });
            }

            return listado;
        }

        public static double[] GetPointOfFloatingButton() {
            double width = GetScreenWidth();
            double height = GetScreenHeight();

            double[] point = { width - 90, height - 180 };

            return point;
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
