using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace KalkulatroKalorii
{
    class WpisywanePole
    {
        public WpisywanePole()
        {
        }
        public WpisywanePole(TextBlock TeBl, TextBox TeBx, double mi, double ma)
        {
            textBox = TeBx;
            textBlock = TeBl;
            max = ma;
            min = mi;
        }
        public TextBox textBox { get; set; }
        public TextBlock textBlock { get; set; }
        public double max { get; }
        public double min { get; }

        private static string ChangeDotOnComma(string s_number)
        {
            return s_number.Replace('.', ',');
        }

        public void Cheack(ref double wpisanyParametr)
        {
            try
            {
                wpisanyParametr = double.Parse(ChangeDotOnComma(textBox.Text));
                if (wpisanyParametr > max) throw new Exception("ZaDuzy"); 
                if (wpisanyParametr < min) throw new Exception("ZaMaly"); 
                textBlock.Text = "";
                textBox.Background = Brushes.White;
            }
            catch (FormatException)
            {
                textBlock.Text = "Nie podano poprawnie liczby";
                textBox.Background = Brushes.LightPink;
                MainWindow.Error = true;
            }
            catch (Exception error_code)
            {
                if (error_code.Message == "ZaDuzy")
                {
                    textBlock.Text = $"Podano zbyt dużą liczbę. Maksymalna wartość to {max}";
                }
                if (error_code.Message == "ZaMaly")
                {
                    textBlock.Text = $"Podano zbyt małą liczbę. Minimalna wartość to {min}";
                }
                textBox.Background = System.Windows.Media.Brushes.LightPink;
                MainWindow.Error = true;
            }

        }

        public void Wyczysc()
        {
            textBox.Text = "";
            textBlock.Text = "";
            textBox.Background = Brushes.White;
        }
    }
}
