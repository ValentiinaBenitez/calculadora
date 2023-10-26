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
        private void cero_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("0");
        }

        private void uno_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("1");
        }

        private void dos_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("2");
        }

        private void tres_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("3");
        }

        private void cuatro_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("4");
        }

        private void cinco_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("5");
        }

        private void seis_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("6");
        }

        private void siete_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("7");
        }

        private void ocho_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("8");
        }

        private void nueve_Click(object sender, RoutedEventArgs e)
        {
            AgregarNumero("9");
        }
        void AgregarNumero(string numero)
        {
            if ((string)pantalla.Content == "0")
            {
                pantalla.Content = numero;
            }
            else
            {
                pantalla.Content = pantalla.Content + numero;
            }
        }

        private void dividido_Click(object sender, RoutedEventArgs e)
        {
            AgregarOperador("/");
        }

        private void multiplicacion_Click(object sender, RoutedEventArgs e)
        {
            AgregarOperador("*");
        }

        private void resta_Click(object sender, RoutedEventArgs e)
        {
            AgregarOperador("-");
        }

        private void suma_Click(object sender, RoutedEventArgs e)
        {
            AgregarOperador("+");
        }
        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            pantalla.Content = "0";
        }

        private void coma_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)pantalla.Content;
            if (!(c.EndsWith(",")))
            {
                if (c.EndsWith(" "))
                {
                    pantalla.Content = pantalla.Content + "0,";
                }
                else
                {
                    pantalla.Content = pantalla.Content + ",";
                }
            }
        }

        private void signos_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)pantalla.Content;
            if (c.StartsWith("-"))
            {
                pantalla.Content = c.Substring(1, c.Length -1);
            } else
            {
                pantalla.Content = "-" + pantalla.Content;
            }

        }

        private void porcentaje_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)pantalla.Content;
            if (c.Contains(" "))
            {
                string ch = c.Substring(c.LastIndexOf(" ", c.Length - 1));
                float f = float.Parse(ch);
                f = f / 100;
                pantalla.Content = c.Substring(0, c.LastIndexOf(" ") + 1) + f.ToString();
            } else
            {
                float f = float.Parse(c);
                f = f / 100;
                pantalla.Content =f.ToString();
            }
        }

        void AgregarOperador(string op)
        {
            string c = (string)pantalla.Content; 
                if (c.EndsWith(" "))
                {
                    pantalla.Content = c.Substring(0, c.IndexOf(" ")) + " " + op + " ";
                } else
                {
                    if (c.Contains("+") || c.Contains("-") || c.Contains("*") || c.Contains("/"))
                    {
                        Calcular();
                    }
                    pantalla.Content = pantalla.Content + " " + op + " ";
                }
        }

        void Calcular()
        {
            string c = (string)pantalla.Content;
            string[] partes = c.Split(' ');
            float a = float.Parse(partes[0]);
            float b = float.Parse(partes[2]);
            float resultado = 0;
            
            if (partes[1] == "+")
            { 
                resultado = a + b;
            } else if (partes[1] == "-")
            {
                resultado = a - b;
            } else if (partes[1] == "*")
            {
                resultado = a * b;
            } else if (partes[1] == "/")
            {
                resultado = a / b;
            }

            pantalla.Content = resultado;
            
        }


        private void igual_Click(object sender, RoutedEventArgs e)
        {
            string c = (string)pantalla.Content;
            if (c.EndsWith(" "))
            {
                    pantalla.Content = c.Substring(0, c.IndexOf(" "));
            }
            else
            {
                Calcular();
            }
        }

       
    }
}
