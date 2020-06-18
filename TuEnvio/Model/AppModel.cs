using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Utils;
using Xamarin.Essentials;

namespace TuEnvio.Model
{
    public class AppModel
    {
        List<Tienda> listadoTiendas = new List<Tienda>();

        public List<Tienda> Tiendas { get { return listadoTiendas; } }

        public bool IsChanged { get; set; }

        public AppModel()
        {
            IsChanged = false;

            //PINAR DEL RIO
            listadoTiendas.Add(new Tienda { Nombre = Const.PINAR_DEL_RIO, Provincia = Const.PINAR_DEL_RIO, URL = Const.URL_DOMAIN + "pinar/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.PINAR_DEL_RIO, false) });

            //ARTEMISA
            listadoTiendas.Add(new Tienda { Nombre = Const.ARTEMISA, Provincia = Const.ARTEMISA, URL = Const.URL_DOMAIN + "artemisa/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.ARTEMISA, false) });

            //HABANA
            listadoTiendas.Add(new Tienda { Nombre = "CarlosIII", Provincia = Const.LA_HABANA, URL = Const.URL_DOMAIN + "carlos3/", IsEnable = true, CanSearch = false, IsSelected = Preferences.Get("CarlosIII", false) });
            listadoTiendas.Add(new Tienda { Nombre = "4Caminos", Provincia = Const.LA_HABANA, URL = Const.URL_DOMAIN + "4caminos/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get("4Caminos", false) });
            listadoTiendas.Add(new Tienda { Nombre = "Pedregal", Provincia = Const.LA_HABANA, URL = Const.URL_DOMAIN + "tvpedregal/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get("Pedregal", false) });
            listadoTiendas.Add(new Tienda { Nombre = "La Típica", Provincia = Const.LA_HABANA, URL = Const.URL_DOMAIN + "tipicaboyeros/", IsEnable = true, CanSearch = false, IsSelected = Preferences.Get("La Típica", false) });
            listadoTiendas.Add(new Tienda { Nombre = "Villa Diana", Provincia = Const.LA_HABANA, URL = Const.URL_DOMAIN + "caribehabana/", IsEnable = false, CanSearch = false, IsSelected = Preferences.Get("Villa Diana", false) });

            //MAYABEQUE
            listadoTiendas.Add(new Tienda { Nombre = Const.MAYABEQUE, Provincia = Const.MAYABEQUE, URL = Const.URL_DOMAIN + "mayabeque-tv/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.MAYABEQUE, false) });

            //MATANZAS
            listadoTiendas.Add(new Tienda { Nombre = Const.MATANZAS, Provincia = Const.MATANZAS, URL = Const.URL_DOMAIN + "matanzas/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.MATANZAS, false) });

            //CIENGUEGOS
            listadoTiendas.Add(new Tienda { Nombre = Const.CIENFUEGOS, Provincia = Const.CIENFUEGOS, URL = Const.URL_DOMAIN + "cienfuegos/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.CIENFUEGOS, false) });

            //VILLA CLARA
            listadoTiendas.Add(new Tienda { Nombre = Const.VILLA_CLARA, Provincia = Const.VILLA_CLARA, URL = Const.URL_DOMAIN + "villaclara/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.VILLA_CLARA, false) });

            //SANCTI SPIRITUS
            listadoTiendas.Add(new Tienda { Nombre = Const.SANCTI_SPIRITUS, Provincia = Const.SANCTI_SPIRITUS, URL = Const.URL_DOMAIN + "sancti/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.SANCTI_SPIRITUS, false) });

            //CIEGO DE AVILA
            listadoTiendas.Add(new Tienda { Nombre = Const.CIEGO_DE_AVILA, Provincia = Const.CIEGO_DE_AVILA, URL = Const.URL_DOMAIN + "ciego/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.CIEGO_DE_AVILA, false) });

            //CAMAGUEY
            listadoTiendas.Add(new Tienda { Nombre = Const.CAMAGUEY, Provincia = Const.CAMAGUEY, URL = Const.URL_DOMAIN + "camaguey/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.CAMAGUEY, false) });

            //LAS TUNAS
            listadoTiendas.Add(new Tienda { Nombre = Const.LAS_TUNAS, Provincia = Const.LAS_TUNAS, URL = Const.URL_DOMAIN + "tunas/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.LAS_TUNAS, false) });

            //HOLGIN
            listadoTiendas.Add(new Tienda { Nombre = Const.HOLGUIN, Provincia = Const.HOLGUIN, URL = Const.URL_DOMAIN + "holguin/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.HOLGUIN, false) });

            //GRANMA
            listadoTiendas.Add(new Tienda { Nombre = Const.GRANMA, Provincia = Const.GRANMA, URL = Const.URL_DOMAIN + "granma/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.GRANMA, false) });

            //SANTIAGO DE CUBA
            listadoTiendas.Add(new Tienda { Nombre = Const.SANTIAGO_DE_CUBA, Provincia = Const.SANTIAGO_DE_CUBA, URL = Const.URL_DOMAIN + "santiago/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.SANTIAGO_DE_CUBA, false) });

            //GUANTANAMO
            listadoTiendas.Add(new Tienda { Nombre = Const.GUANTANAMO, Provincia = Const.GUANTANAMO, URL = Const.URL_DOMAIN + "guantanamo/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.GUANTANAMO, false) });

            //ISLA DE LA JUVENTUD
            listadoTiendas.Add(new Tienda { Nombre = Const.ISLA_DE_LA_JUVENTUD, Provincia = Const.ISLA_DE_LA_JUVENTUD, URL = Const.URL_DOMAIN + "isla/", IsEnable = true, CanSearch = true, IsSelected = Preferences.Get(Const.ISLA_DE_LA_JUVENTUD, false) });
        }

        public List<Tienda> GetSelected() {

            List<Tienda> selected = new List<Tienda>();
            foreach (Tienda tienda in listadoTiendas) {
                if (tienda.IsSelected)
                    selected.Add(tienda);
            }
            return selected;
        }

        public void UpdatePreferences() {

            foreach (Tienda tienda in Tiendas) {
                Preferences.Set(tienda.Nombre, tienda.IsSelected);
            }
            IsChanged = false;
        }
    }
}
