using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace KalkulatroKalorii
{
    static class Obliczenia
    {
        public static double ObliczPPM(double wiek, double wzrost, double waga, bool kobieta)
        {
            if(kobieta)
            {
                return (655.1 + (9.567*waga) + (1.85* wzrost) - (4.68 * wiek));
            }
            else
            {
               return (66.47 + 13.7*waga + 5.0*wzrost - 6.76 * wiek);
            }
        }

        public static double ObliczCPMiGramy(double pmm, double pal, double b, double w, double t)
        {
            double cmp = pmm * pal;
            MainWindow.BialkoGramy = Math.Round((cmp * (b / 100)/4),0);
            MainWindow.WeglGramy = Math.Round((cmp * (w / 100) / 4),0);
            MainWindow.TluszczGramy = Math.Round((cmp * (t / 100) / 9),0);
            return Math.Round(cmp, 0);
        }

        public static double ObliczBMI(TextBox nazwa, TextBlock zakres, double waga, double wzrost)
        {
            double bmi = (10000*waga/(wzrost*wzrost));
            bmi = Math.Round(bmi, 2);
            nazwa.Foreground = Brushes.Black;
            if (bmi<16)
            {
                nazwa.Text = "Wygłodzenie";
                nazwa.Background = Brushes.DarkBlue;
                nazwa.Foreground = Brushes.White;
                zakres.Text = "< 1,60";
            }
            else if(bmi<17)
            {
                nazwa.Text = "Wychudzenie";
                nazwa.Background = Brushes.Blue;
                nazwa.Foreground = Brushes.White;
                zakres.Text = "16,0-19,99";
            }
            else if (bmi < 18.5)
            {
                nazwa.Text = "Niedowaga";
                nazwa.Background = Brushes.LightBlue;
                zakres.Text = "17,0-18,49";
            }
            else if (bmi < 25)
            {
                nazwa.Text = "Pożądana masa ciała";
                nazwa.Background = Brushes.LightGreen;
                zakres.Text = "18,5-24,99";
            }
            else if (bmi < 30)
            {
                nazwa.Text = "Nadwaga";
                nazwa.Background = Brushes.Yellow;
                zakres.Text = "25,0-29,99";
            }
            else if (bmi < 35)
            {
                nazwa.Text = "Otyłość I stopnia";
                nazwa.Background = Brushes.Gold;
                zakres.Text = "30,0-34,99";
            }
            else if (bmi < 40)
            {
                nazwa.Text = "Otyłość II stopnia";
                nazwa.Background = Brushes.Orange;
                zakres.Text = "35,0-39,99";
            }
            else
            {
                nazwa.Text = "Otyłość III stopnia";
                nazwa.Background = Brushes.DarkRed;
                nazwa.Foreground = Brushes.White;
                zakres.Text = "≥ 40,0";
            }
            return bmi;
        }
    }
}
