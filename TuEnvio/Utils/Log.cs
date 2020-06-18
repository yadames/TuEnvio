using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TuEnvio.Utils
{
    public class Log
    {
        public static void Track(string msg) {
            IFirebaseAnalyticsService service = DependencyService.Get<IFirebaseAnalyticsService>();
            service?.LogEvent("");
        }
    }
}
