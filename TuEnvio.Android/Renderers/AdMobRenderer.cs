﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TuEnvio.Controls;
using TuEnvio.Droid.Renderers;
using TuEnvio.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdmobControl), typeof(AdMobRenderer))]
namespace TuEnvio.Droid.Renderers
{
    public class AdMobRenderer : ViewRenderer<AdmobControl, AdView>
    {
        public AdMobRenderer(Context context) : base(context)
        {
        }

        private int GetSmartBannerDpHeight()
        {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400) return 32;
            if (dpHeight <= 720) return 50;
            return 90;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var adView = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    //AdUnitId = "ca-app-pub-3940256099942544/6300978111"
                    AdUnitId = Element.AdUnitId

                };

                var requestbuilder = new AdRequest.Builder();

                adView.LoadAd(requestbuilder.Build());

                e.NewElement.HeightRequest = GetSmartBannerDpHeight();
                SetNativeControl(adView);
            }
        }
    }
}