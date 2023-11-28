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
using WorkTogether.Wpf.Views;

namespace WorkTogether.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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
}