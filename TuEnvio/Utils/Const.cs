using System;
using System.Collections.Generic;
using System.Text;

namespace TuEnvio.Utils
{
    public static class Const
    {
        public const string URL_DOMAIN = "https://www.tuenvio.cu/";
        public const string URL_SEARCH = "Search.aspx?keywords=";

        public const string PINAR_DEL_RIO = "Pinar del río";
        public const string ARTEMISA = "Artemisa";
        public const string LA_HABANA = "La Habana";
        public const string MAYABEQUE = "Mayabeque";
        public const string MATANZAS = "Matanzas";
        public const string CIENFUEGOS = "Cienfuegos";
        public const string VILLA_CLARA = "Villa Clara";
        public const string SANCTI_SPIRITUS = "Sancti Spíritus";
        public const string CIEGO_DE_AVILA = "Ciego de Ávila";
        public const string CAMAGUEY = "Camagüey";
        public const string LAS_TUNAS = "Las Tunas";
        public const string HOLGUIN = "Holguín";
        public const string GRANMA = "Granma";
        public const string SANTIAGO_DE_CUBA = "Santiago de Cuba";
        public const string GUANTANAMO = "Guantánamo";
        public const string ISLA_DE_LA_JUVENTUD = "Isla de la Juventud";

        public static readonly List<string> ADS_UNIT_OLD = new List<string> {
            "ca-app-pub-2807998494224675/5950558114",
            "ca-app-pub-2807998494224675/1006257155",
            "ca-app-pub-2807998494224675/9463331676",
            "ca-app-pub-2807998494224675/7380093815",
            "ca-app-pub-2807998494224675/5103562069",
            "ca-app-pub-2807998494224675/3790480396"
        };

        public static readonly List<string> ADS_UNIT = new List<string> {
            "ca-app-pub-2807998494224675/8592817728", //App1
            "ca-app-pub-2807998494224675/8209674347", //App2
            "ca-app-pub-2807998494224675/4078857643", //App3
            "ca-app-pub-2807998494224675/9139612632", //App4
            "ca-app-pub-2807998494224675/3887285955", //App5
            "ca-app-pub-2807998494224675/2574204283"  //App6
        };

        public const string INIT_APP = "InitApp";
        public const string SEARCH = "Search";
        public const string SAVE_CHANGES = "SaveChanges";
        public const string SHARE_LINK = "ShareLink";
        public const string REFRESH_ALL = "RefreshAll";
        public const string OPEN_HELP = "OpenHelp";
        public const string OPEN_FROM_LINK = "OpenFromLink";
        public const string OPEN_TRANSFERMOVIL = "OpenTransfermovil";

        public static string GetRandomAds() {
            Random random = new Random();
            return ADS_UNIT[random.Next(5)];
        }
    }
}
