using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Utils;
using Xamarin.Forms;

namespace TuEnvio.Controls
{
    public class CustomFrame : Frame
    {
        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals("Renderer"))
            {
                double width = UtilsXF.GetScreenWidth();
                WidthRequest = width - (width * 0.2);
            }
        }
    }
}
