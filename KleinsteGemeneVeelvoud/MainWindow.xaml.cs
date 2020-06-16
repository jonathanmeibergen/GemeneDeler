using System;
using System.Collections;
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

        public int a { get; set;}
        public int b { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private int GeefKAV(int a, int b)
        {
            float kav = a;

            while (kav % b != 0)
            {
                kav += a;
                if (kav > 1000000)// big number stop
                    break;
            }
            return Convert.ToInt32(kav);
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

                if (grootste % kav == 0)
                    return Convert.ToInt32(kav);
            }

            return 1;
        }

        private List<int> ontbindInFactoren(int numerator)
        {
            List<int> factors = new List<int>();
            int quotient = numerator, denominator = 2;

            logObject(String.Format("De factoren van {0} zijn:", numerator), true);
            while (denominator <= quotient)
            {
                if (quotient % denominator == 0)
                {
                    factors.Add(denominator);
                    logObject(string.Format(" {0},", denominator), false);
                    quotient /= denominator;
                    denominator = 1; // the incrementer in the following statement makes the dominator 2 as it should be
                }
                denominator++;
            }
            return factors;
        }

        private int geefGAVontbind(int a, int b)
        {
            List<int> la = ontbindInFactoren(a), lb = ontbindInFactoren(b), gav_factoren = new List<int>();
            int gav = 1;

            
            foreach (var item in la)
            {
                if(lb.Count > 0 && lb.Contains(item))
                {
                    gav_factoren.Add(item);
                    lb.Remove(item);
                }
            }

            if (gav_factoren.Count > 0)
                logObject(String.Format("De overeenkomstige factoren van {0} en {1} zijn:", a, b), true);
            else
            {
                logObject("Er zijn geen overeenkomstige factoren", true);
                return gav;
            }

            foreach (int item in gav_factoren)
            {
                logObject(String.Format(" {0},", item), false);
                gav *= item;
            }



            return gav;
        }

        public void logObject(object value, bool newline)
        {
            if (newline)
                tbLog.Text += "\n";
            tbLog.Text += value.ToString();

            tbLog.CaretIndex = tbLog.Text.Length;
            tbLog.ScrollToEnd();
        }

        private int validateInput(object data)
        {
            int number = 0;
            if (int.TryParse(data.ToString(), out number))
                number = Convert.ToInt32(data.ToString());

            return number;
        }

        private void kav_click(object sender, RoutedEventArgs e)
        {
            a = validateInput(tbA.Text);
            b = validateInput(tbB.Text);
           
            logObject(String.Format("Kleinste algemene veelvoud van {0} en {1} is {2}",
                                        a,
                                        b,
                                        GeefKAV(a, b)), true);
        }

        private void gav_click(object sender, RoutedEventArgs e)
        {
            a = validateInput(tbA.Text);
            b = validateInput(tbB.Text);
            bool ontbind = cbOntbind.IsChecked ?? false;

            if (!ontbind)
            {
                logObject(String.Format("Grootste algemene veelvoud van {0} en {1} is {2}",
                                            a,
                                            b,
                                            GeefGAV(a, b)), true);
            }
            else
            {
                logObject(String.Format("Grootste algemene veelvoud van {0} en {1} is {2}",
                           a,
                           b,
                           geefGAVontbind(a, b)),true);
            }
        }
    }
}
