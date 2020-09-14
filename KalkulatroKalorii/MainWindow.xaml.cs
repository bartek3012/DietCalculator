using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KalkulatroKalorii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double waga;
        static double height;
        static double wiek;
        static double pal;
        static double prWegl;
        static double prBialko;
        static double prTluszcz;
        static bool kobieta;
        static double ppm;

        static public bool Error { get; set; }
        public static double WeglGramy { get; set; }
        public static double BialkoGramy { get; set; }
        public static double TluszczGramy { get; set; }
        static WpisywanePole wagaPole;
        static WpisywanePole wzrostPole;
        static WpisywanePole wiekPole;
        static WpisywanePole palPole;
        static WpisywanePole weglPole;
        static WpisywanePole bialkoPole;
        static WpisywanePole tluszczPole;
        static WpisywanePole[] Pola;     
        public MainWindow()
        {
            InitializeComponent();
            wagaPole = new WpisywanePole(textBlockWagaError, textBoxWaga, 6, 700);
            wzrostPole = new WpisywanePole(textBlockWzrostError, textBoxWzrost, 50, 300);
            wiekPole = new WpisywanePole(textBlockWiekError, textBoxWiek, 18, 130);
            palPole = new WpisywanePole(textBlockPalError, textBoxPal, 1, 3);
            weglPole = new WpisywanePole(textBlockWeglError, textBoxWegl, 0, 100);
            bialkoPole = new WpisywanePole(textBlockBialkoError, textBoxBialko, 0, 100);
            tluszczPole = new WpisywanePole(textBlockTluszczError, textBoxTluszcz, 0, 100);
            Pola = new WpisywanePole[7];
            Pola[0] = wagaPole; Pola[1] = wzrostPole; Pola[2] = wiekPole; Pola[3] = palPole; Pola[4] = weglPole; Pola[5] = bialkoPole; Pola[6] = tluszczPole;
        }

        private void Button_Oblicz_Click(object sender, RoutedEventArgs e)
        {
            Error = false;
            wagaPole.Cheack(ref waga);
            wzrostPole.Cheack(ref height);
            wiekPole.Cheack(ref wiek);
            palPole.Cheack(ref pal);
            weglPole.Cheack(ref prWegl);
            bialkoPole.Cheack(ref prBialko);
            tluszczPole.Cheack(ref prTluszcz);
            double x = prWegl + prBialko + prTluszcz;
            if (x != 100)
            {
                textBlockTluszczError.Text = "Suma skadników musi wynosić 100 [%]";
                Error = true;
            }
            kobieta = (bool)RadioButtonFemale.IsChecked;
            if (Error) return;
            ppm = Obliczenia.ObliczPPM(wiek, height, waga, kobieta);
            textBoxPPM.Text = Math.Round(ppm, 0).ToString();
            textBoxCMP.Text = Obliczenia.ObliczCPMiGramy(ppm, pal, prBialko, prWegl, prTluszcz).ToString();
            textBoxBGramy.Text = BialkoGramy.ToString();
            textBoxWGramy.Text = WeglGramy.ToString();
            textBoxTGramy.Text = TluszczGramy.ToString();
            textBoxBMI.Text = Obliczenia.ObliczBMI(textBoxBMIGrupa, textBlockBMIZakres, waga, height).ToString();
        }

        private void Button_Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxWaga.Text == "Paulina" && textBoxWzrost.Text == "Sieradzka")
            {
                harryImage.Visibility = Visibility.Visible;
                ImagePaulina.Visibility = Visibility.Visible;
            }
            for (int i=0; i<Pola.Length; i++)
            {
                Pola[i].Wyczysc();
            }
            textBoxPPM.Text = "";
            textBoxCMP.Text = "";
            textBoxBGramy.Text = "";
            textBoxWGramy.Text = "";
            textBoxTGramy.Text = "";
            textBoxBMI.Text = "";
            textBoxBMIGrupa.Text = "";
            textBoxBMIGrupa.Background = Brushes.White;
            textBoxBMIGrupa.Foreground = Brushes.Black;
            textBlockBMIZakres.Text = "";
        }

        private void Window_KeyEnter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            Button_Oblicz_Click(sender, null);
        }

    }
}
