using DoskarBakalare.DB;
using DoskarBakalare.Znamky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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

namespace DoskarBakalare.Pages
{
    /// <summary>
    /// Interakční logika pro znamkyView.xaml
    /// </summary>
    public partial class znamkyView : Page, INotifyPropertyChanged
    {
        
        public znamkyView()
        {
            InitializeComponent();
            Prumer = ("Prumer znamek v predmetu sda: " + 0);

            this.DataContext = this;

            Reload();

        }

        void Reload()
        {

            var input = new ZnamkyI();
            input.ReadDb();
            input.FilterById(IdPredmetu);
            ZnamkyHolder.ItemsSource = input.LoadedZnamky;
            PocetZnamek.Text = "Počet známek v předmětu: " + input.LoadedZnamky.Count;

           

            int sum = 0;
            int weights = 0;
            averagePredmetu = 0;
            foreach(Zapis znamka in input.LoadedZnamky)
            {
                sum += znamka.Hodnota * znamka.Vaha;
                weights += znamka.Vaha;
            }

            if (weights != 0)
            {
                averagePredmetu = (float)sum / weights;
            }
            else
            {
                averagePredmetu = 0;
            }

            Prumer = ("Prumer znamek v predmetu: " + averagePredmetu);
            
        }
        public float averagePredmetu;

        int idPremetu;
        public int IdPredmetu
        {
            get { return idPremetu; }
            set
            {
                if (value >= 0)
                {
                    idPremetu = value;

                    OnPropertyChanged();
                    Reload();
                }

            }
        }

        string prumer;
        public string Prumer
        {
            get { return prumer; }
            set
            {
                prumer = value;
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void PridatZnamku(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PridatZnamkuView(IdPredmetu));
        }
        private void OdebratZnamku(object sender, RoutedEventArgs e)
        {
            if (ZnamkyHolder.SelectedItems.Count > 0) {
                foreach(Zapis zapis in ZnamkyHolder.SelectedItems)
                {
                    ZnamkyO.instance.DeleteZapis(zapis);
                }
            }
            Reload();
        }

        private void UpravitZnamku(object sender, RoutedEventArgs e)
        {
            if (ZnamkyHolder.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(new UpravitZnamkuView(IdPredmetu, (Zapis)ZnamkyHolder.SelectedItems[0]));
            }
            Reload();

        }
    }
}
