using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TuEnvio.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageRender))]
namespace TuEnvio.iOS.Renderers
{
    //public class TabbedPageRender : TabbedRenderer
    //{
    //    private IPageController PageController => Element as IPageController;

    //    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    //    {
    //        base.OnElementChanged(e);
    //        if (e.NewElement != null)
    //        {
    //            TabBar.Translucent = true;

    //            var frame = View.Frame;
    //            Console.WriteLine("Page Controller Frame: " + frame);
    //            PageController.ContainerArea = new Rectangle(0, 0, frame.Width, frame.Height);
    //        }
    //    }
    //}
}