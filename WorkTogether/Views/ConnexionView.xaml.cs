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
using WorkTogether.Wpf.ViewModels;

namespace WorkTogether.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour ConnexionView.xaml
    /// </summary>
    public partial class ConnexionView : UserControl
    {
        public ConnexionView()
        {
            InitializeComponent();
            this.DataContext = new ConnexionViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ((ConnexionViewModel)this.DataContext).ConnexionValidator();
            
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((ConnexionViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }
    }
}
