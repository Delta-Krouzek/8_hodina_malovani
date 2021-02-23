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

namespace _8_hodina__malovani
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool maluje = false;
        bool maze = false;
        Point bod = new Point(0, 0);
        Color barva = Colors.Black;
        double velikost = 10;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void mrizka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            maluje = true;
        }

        private void mrizka_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            maluje = false;
        }

        private void mrizka_MouseMove(object sender, MouseEventArgs e)
        {
            bod = e.GetPosition(mrizka);
            Title = bod.X.ToString() + ";" + bod.Y.ToString();
            if(maluje && bod.X > velikost / 2)
            {
                Ellipse kolecko = new Ellipse();
                kolecko.HorizontalAlignment = HorizontalAlignment.Left;
                kolecko.VerticalAlignment = VerticalAlignment.Top;
                kolecko.Margin = new Thickness(bod.X - velikost / 2, bod.Y - velikost / 2, 0, 0);
                kolecko.Fill = new SolidColorBrush(barva);
                kolecko.Width = velikost;
                kolecko.Height = velikost;
                kolecko.MouseEnter += Kolecko_MouseEnter; //+=(Tab, Tab)
                mrizka.Children.Add(kolecko);
            }
        }

        private void Kolecko_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse kolecko)
            {
                if (maze)
                {
                    mrizka.Children.Remove(kolecko);
                }
            }
        }

        private void mrizka_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            maze = true;
        }

        private void mrizka_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            maze = false;
        }

        private void btnBarva_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog vyberBarvu = new System.Windows.Forms.ColorDialog();
            if (vyberBarvu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barva = Color.FromArgb(vyberBarvu.Color.A, vyberBarvu.Color.R, vyberBarvu.Color.G, vyberBarvu.Color.B);
                btnBarva.Background = new SolidColorBrush(barva);
            }
        }

        private void sldrVelikost_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                if (lblVelikost != null)
                {
                    lblVelikost.Content = Math.Round(slider.Value, 2);
                }
                velikost = slider.Value;
            }
        }

        private void bntUlozit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
