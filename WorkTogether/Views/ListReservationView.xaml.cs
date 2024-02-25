using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour ListReservationView.xaml
    /// </summary>
    public partial class ListReservationView : UserControl
    {
        public ListReservationView()
        {
            InitializeComponent();
            this.DataContext = new ReservationViewModel();
        }


        private void PDFButton_Click(object sender, RoutedEventArgs e)
        {
            ((ReservationViewModel)this.DataContext).ExportToPdf();
        }

        private void CSVButton_Click(object sender, RoutedEventArgs e)
        {
            ((ReservationViewModel)this.DataContext).ExportToCsv();
        }
    }
}
