using DoskarBakalare.DB;
using DoskarBakalare.Znamky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

namespace DoskarBakalare.Pages
{
    /// <summary>
    /// Interakční logika pro PridatZnamkuView.xaml
    /// </summary>
    public partial class UpravitZnamkuView : Page, INotifyPropertyChanged
    {
        int hodnota;


        public int Hodnota 
        { 
            get 
            {
                return hodnota;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    hodnota = value;
                    OnPropertyChanged();
                }
            }
        }


        int vaha;

        public int Vaha
        {
            get
            {
                return vaha;
            }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    vaha = value;
                    OnPropertyChanged();
                }
            }
        }

        string tema;

        public string Tema
        {
            get
            {
                return tema;
            }
            set
            {
                if (value.Length >= 1 && value.Length <= 32)
                {
                    tema = value;
                    
                    OnPropertyChanged();
                }
            }
        }
        public int idPredmetu;

        public int Id;

        public UpravitZnamkuView(int idPredmetu, Zapis zapis)
        {
            InitializeComponent();
            this.DataContext = this;
            Id = zapis.Id;
            Hodnota = zapis.Hodnota;
            Vaha = zapis.Vaha;
            Tema = zapis.Popis;
            dateUpravit.SelectedDate = zapis.Date;
            idPredmetu = zapis.IdCloveka;

            this.idPredmetu = zapis.IdCloveka;
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new znamkyView());
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {

            if(Validation.GetHasError(hodnotaBoxUpravit) || Validation.GetHasError(vahaBoxUpravit) || Validation.GetHasError(temaBoxUpravit) || dateUpravit.SelectedDate == null)
            {
                MessageBox.Show("INPUT ERROR");
            } else
            {
                MessageBox.Show($"Upraveno");


                Zapis newZapis = new Zapis();

                newZapis.Id = Id;
                newZapis.Hodnota = Hodnota;
                newZapis.Vaha = Vaha;
                newZapis.Popis = Tema;
                newZapis.Date = (DateTime)dateUpravit.SelectedDate;
                newZapis.IdCloveka = idPredmetu;

                ZnamkyO.instance.UpravitZapis(newZapis);
            }
                
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
