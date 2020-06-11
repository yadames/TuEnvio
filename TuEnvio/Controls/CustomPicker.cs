using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TuEnvio.Controls
{
    public class CustomPicker : Picker
    {
        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals("Renderer"))
            {
                var departamentos = new List<string>() {};
                departamentos.Add("Alimentos y bebidas");
                departamentos.Add("- Aderesos, aliños y salsas");
                departamentos.Add("- Alimentos refrigerados");
                departamentos.Add("- Aperitivos y condimentos");
                departamentos.Add("Bebé");
                departamentos.Add("Belleza");
                departamentos.Add("Electrónica");
                departamentos.Add("Para el hogar");
                departamentos.Add("Alimentos y bebidas");
                departamentos.Add("- Aderesos, aliños y salsas");
                departamentos.Add("- Alimentos refrigerados");
                departamentos.Add("- Aperitivos y condimentos");
                departamentos.Add("Bebé");
                departamentos.Add("Belleza");
                departamentos.Add("Electrónica");
                departamentos.Add("Para el hogar");
                departamentos.Add("Alimentos y bebidas");
                departamentos.Add("- Aderesos, aliños y salsas");
                departamentos.Add("- Alimentos refrigerados");
                departamentos.Add("- Aperitivos y condimentos");
                departamentos.Add("Bebé");
                departamentos.Add("Belleza");
                departamentos.Add("Electrónica");
                departamentos.Add("Para el hogar");

                ItemsSource = departamentos;
            }
        }
    }
}
