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
        Affiche.Children.Clear();

        Affiche.Children.Add(new ConnexionView());
    }


    public void LoadMenuView()
    {
        Affiche.Children.Add(new MenuView());
    }


}