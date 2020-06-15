using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TuEnvio.Utils
{
    class ShareUtils
    {
        public static async Task ShareText(string producto, string url)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = $"#alerta (Desde TuEnvioApp){producto} {url}",
                Title = "Compartir enlace de TuEnvio.cu"
            });
        }
    }
}
