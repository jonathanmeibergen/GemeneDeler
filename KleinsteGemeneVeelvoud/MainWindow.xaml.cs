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

namespace KleinsteGemeneVeelvoud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] digits = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };

        private int GeefKAV(int a, int b)
        {
            float kav = a;

            while (kav % b != 0)
            {
                //logObject(kav);
                kav += a;

                if (kav > 1000000)// big number stop
                    break;

            }

            return Convert.ToInt32(kav);
        }

        private void ontbindInFactoren(int a)
        {
            int[] factoren = new int[16];
            int temp = 1;

            for (int i = a/2; i > 0; i--)
            {
                for (int j = 2; j < a/2; j++)
                {
                    
                }
            }
        }

        private int GeefGAV(int a, int b)
        {
            float kav = a;
            int kleinste = 1, grootste = 1;

            if (a != b)
            {
                if (a < b)
                {
                    kleinste = a;
                    grootste = b;
                } else 
                {
                    kleinste = b;
                    grootste = a;
                }
            } else
            {
                return a;
            }

            for (int i = 1; i <= kleinste / 2; i++)
            {
                kav = (float)kleinste / (float)i;
                //logObject(kav);

                if (grootste % kav == 0)
                {
                    return Convert.ToInt32(kav);
                }
            }

            return 1;

        }

        public void logObject(object value)
        {
            tbLog.Text += value.ToString();
            tbLog.Text += "\n";

            tbLog.CaretIndex = tbLog.Text.Length;
            tbLog.ScrollToEnd();
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void calc_click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            string log;
            int a, b;

            if (int.TryParse(tbA.Text, out a) && int.TryParse(tbA.Text, out b))
            {
                a = Convert.ToInt32(tbA.Text);
                b = Convert.ToInt32(tbB.Text);

                //int.TryParse(

                if (btn.Name.Equals("bKAV"))
                {
                    log = String.Format("Kleinste algemene veelvoud van {0} en {1} is {2}",
                                        a,
                                        b,
                                        GeefKAV(a, b));
                }
                else
                {
                    log = String.Format("Grootste algemene veelvoud van {0} en {1} is {2}",
                                        a,
                                        b,
                                        GeefGAV(a, b));
                }

            } else
            {
                log = "Input is geen getal";
            }
            logObject(log);
        }
    }
}
