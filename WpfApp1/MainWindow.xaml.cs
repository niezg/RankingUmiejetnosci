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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Pole> pola = new List<Pole>();
        
        int CzyLewa = 1;
        int l=0;
        int p=1;
        int pPoczatek=1;
        public string[] Pytania { get; set; }

        public MainWindow()
        {
            

            InitializeComponent();


            for (int i = 0; i < 10; ++i)
            {
                pola.Add( new Pole());
                pola[i].ID = i;
            }

            Pytania = new string[] { "Która strona jest moją najsilniejszą?", "W którą stronę chce się rozwijać?" };
            DataContext = this;


        }

        private void TB2_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void TB2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            pola[0].Name = TB1.Text;
            pola[1].Name = TB2.Text ;
            pola[2].Name = TB3.Text ;
            pola[3].Name = TB4.Text ;
            pola[4].Name = TB5.Text ;
            pola[5].Name = TB6.Text ;
            pola[6].Name = TB7.Text ;
            pola[7].Name = TB8.Text ;
            pola[8].Name = TB9.Text ;
            pola[9].Name = TB10.Text ;

            
           

            PrawyButton.Content = pola[p].Name;
            LewyButton.Content = pola[l].Name;








        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Lewa_Click(object sender, RoutedEventArgs e)
        {
            
            CzyLewa = 1;
            Compare();
        }

        private void Prawa_Click(object sender, RoutedEventArgs e)
        {
            
            CzyLewa = 0;
            Compare();
        }

        void Compare ()
        {

            if (pPoczatek == 10) return;

            if (CzyLewa == 1)
            {
                pola[l].AddPunkt();
                pola[l].Compare[p] = 1;
            }
            else
            {
                pola[p].AddPunkt();
                pola[p].Compare[l] = 1;
            }
            ++l;
            ++p;
            if (p > 9)
            {
                pPoczatek += 1;
                p = pPoczatek;
                l = 0;
            }

            if (pPoczatek == 10) Koniec();
            else
            {
                PrawyButton.Content = pola[p].Name;
                LewyButton.Content = pola[l].Name;

                //LewyButton.Margin = 330;
            }


       }


        void Koniec()
        {

            pola.Sort();
            pola.Reverse();
            Lista.ItemsSource = pola;
            Etykieta.Content = Pytanie.Text;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WyborPytania_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void WyborPytania_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void WyborPytania_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void WyborPytania_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void WyborPytania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WyborPytania.SelectedIndex >= 0)
                Pytanie.Text = Pytania[WyborPytania.SelectedIndex];
        }
    }
}
