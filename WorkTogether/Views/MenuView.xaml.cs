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
using WorkTogether.DBlib.Class;
using WorkTogether.Wpf.ViewModels;

namespace WorkTogether.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        private User _User;

        public User User
        {
            get { return _User; }
            set { _User = value; }
        }

        public MenuView()
        {

            InitializeComponent();
            User = (Application.Current as App).User;
        }

        private void ListPack_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new ListPackView());
        }

        private void ListRack_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new ListRackView());
        }

        private void ListReservation_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new ListReservationView());
        }

        private void ListClient_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new ListClientView());
        }

        private void ListTicket_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new ListTicketView());
        }

        private void PercentageRack_Click(object sender, RoutedEventArgs e)
        {
            DockPanelShow.Children.Clear();
            DockPanelShow.Children.Add(new PercentageRackView());
        }
    }
}
