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

namespace DoskarBakalare.Pages
{
    /// <summary>
    /// Interakční logika pro znamkyView.xaml
    /// </summary>
    public partial class znamkyView : Page
    {
        public znamkyView()
        {
            InitializeComponent();
            this.DataContext = this;
            ZnamkyHolder.ItemsSource = IOznamky.instance.Zapisy;
        }

        private void PridatZnamku(object sender, RoutedEventArgs e)
        {

        }
        private void OdebratZnamku(object sender, RoutedEventArgs e)
        {

        }
        private void UpravitZnamku(object sender, RoutedEventArgs e)
        {

        }
    }
}
