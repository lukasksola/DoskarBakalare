using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoskarBakalare.DB;
using DoskarBakalare.Pages;
using DoskarBakalare.Znamky;

namespace DoskarBakalare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new ZnamkyO();
            frameNavigaiton.Navigate(new znamkyView());

        }
    }
}