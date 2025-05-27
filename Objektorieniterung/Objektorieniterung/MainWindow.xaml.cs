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

namespace Objektorieniterung
{
    class Rechteck
    {
        public double laenge = 1;
        public double breite = 2;
        public double posX = 1;
        public double posY = 1;



        public double FlaecheBerechnen()
       {

         
            return laenge*breite;
       }

        public Rechteck(double laenge, double breite, double posX, double posY)

        {
            this.laenge = laenge;
            this.breite = breite;
            this.posX = posX;
            this.posY = posY;
        }

        public override string ToString()
        {
            return $"Rechteck: {laenge}x{breite}";
        }

    }
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rechteck> rechtecke = new List <Rechteck>();

        public MainWindow()
        {
            InitializeComponent();

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string laengeStr = this.tbxLaenge.Text;
                double laenge = double.Parse(laengeStr);
                string breiteStr = this.tbxBreite.Text;
                double breite = double.Parse(breiteStr);
                double posX = double.Parse(tbxx.Text);
                double posY = double.Parse(tbxy.Text);

                if (lstRechtecke.SelectedItem != null)
                {
                    Rechteck r = (Rechteck)lstRechtecke.SelectedItem;
                    r.laenge = laenge;
                    r.breite = breite;

                    
              
                }
                else
                {
                    Rechteck r = new Rechteck(laenge, breite,posX,posY);
                    lstRechtecke.Items.Add(r);
                    rechtecke.Add(r);
                }

                tbxLaenge.Clear();
                tbxBreite.Clear();
                tbxx.Clear();
                tbxy.Clear();
                lstRechtecke.SelectedItem = null;

                lstRechtecke.Items.Refresh();
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe!");
            }
        }


        private void lstRechtecke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rechteck r = (Rechteck)this.lstRechtecke.SelectedItem;
            if (r != null)
            {
                tbxLaenge.Text = r.laenge.ToString();
                tbxBreite.Text = r.breite.ToString();
                tbxx.Text = r.posX.ToString();
                tbxy.Text = r.posY.ToString();
            }
        }

        private void Button_Zeichnen_Click(object sender, RoutedEventArgs e)
        {
            string laengeStr = this.tbxLaenge.Text;
            double laenge = double.Parse(laengeStr);
            string breiteStr = this.tbxBreite.Text;
            double breite = double.Parse(breiteStr);
            string posXStr =this.tbxx.Text;
            double posX = double.Parse(tbxx.Text);
            string posYStr =this.tbxy.Text;
            double posY = double.Parse(tbxy.Text);
            
            Rectangle rect = new Rectangle();

            rect.Width = laenge;
            rect.Height = breite;
            rect.StrokeThickness = 2;
            rect.Stroke = Brushes.Black;

            Canvas.SetLeft(rect, posX);
            Canvas.SetTop(rect, posY);


            myCanvas.Children.Add(rect);
        }

        private void Button_LoeschenAlle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
