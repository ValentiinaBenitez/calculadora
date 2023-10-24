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

namespace calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void setoperator(string op)
        {
            string c = (string)result.Content;
            if (c.Substring(c.Length - 1, 1) == ".")
                result.Content = result.Content + "0 " + op + " ";
            else
            {
                if (c.EndsWith(" "))
                    result.Content = c.Substring(0, c.IndexOf(" ")) + " " + op + " ";

                else
                {
                    if (c.Contains("+") || c.Contains("*") || c.Contains("-") || c.Contains("/"))
                        calcul();

                    result.Content = result.Content + " " + op + " ";
                }
            }
        }

        void setNumber(String num)
        {

            if ((string)result.Content == "0")
                result.Content = num;
            else
            {
                result.Content = result.Content + num;
            }
        }


        void calcul()
        {
            string c = (string)result.Content;
            string[] tokens = c.Split(' ');
            float a = float.Parse(tokens[0]);
            float b = float.Parse(tokens[2]);
            float res = 0;

            if (tokens[1] == "+")
                res = a + b;
            else if (tokens[1] == "-")
                res = a - b;
            else if (tokens[1] == "*")
                res = a * b;
            else if (tokens[1] == "/")
                res = a / b;
            result.Content = res.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "0";
        }

        private void Divide_Click_1(object sender, RoutedEventArgs e)
        {
            setoperator("/");
        }

        private void Mul_Click_1(object sender, RoutedEventArgs e)
        {
            setoperator("*");
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            setoperator("-");
        }
        private void Sumar_Click(object sender, RoutedEventArgs e)
        {
            setoperator("+");
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)result.Content;
            if (c.EndsWith(" "))
            {
                if (c.Contains("%"))
                {
                    float f = float.Parse(c.Substring(0, c.IndexOf(" "))) / 100;
                    result.Content = f.ToString();
                }
                else
                    result.Content = c.Substring(0, c.IndexOf(" "));
            }
            else
            {
                calcul();
            }
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)result.Content;
            if (!(c.EndsWith(".")))
            {
                if (c.EndsWith(" "))
                    result.Content = result.Content + "0.";
                else
                    result.Content = result.Content + ".";
            }
        }
        private void Clear_Click_1(object sender, RoutedEventArgs e)
        {
            result.Content = "0";
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            setNumber("1");
        }
             
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            setNumber("3");
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            setNumber("4");
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            setNumber("5");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            setNumber("6");
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            setNumber("7");
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            setNumber("8");
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            setNumber("9");
        }



        private void Percent_Click_1(object sender, RoutedEventArgs e)
        {
            string c = (string)result.Content;
            if (c.EndsWith("."))
            {
                c = c + "0";
            }
            if (c.Contains(" "))
            {
                string ch = c.Substring(c.LastIndexOf(" ", c.Length - 1));
                float f = float.Parse(ch);
                f = f / 100;
                result.Content = c.Substring(0, c.LastIndexOf(" ") + 1) + f.ToString();
            }
            else
            {
                float f = float.Parse(c);
                f = f / 100;
                result.Content = f.ToString();
            }
        }

        private void Sign_Click_1(object sender, RoutedEventArgs e)
        {
            string c = (string)result.Content;
            if (c.StartsWith("-"))
                result.Content = c.Substring(1, c.Length - 1);
            else
                result.Content = "-" + result.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setNumber("2");
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            result.Content = result.Content + "0";
        }
    }
}
