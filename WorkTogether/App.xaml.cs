using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private User? _User;

        //public User? User { get => _User; set => SetProperty(nameof(User),ref _User, value); }
        public User? User { get => _User; set => _User = value  ; }

        public void ValidLogin()
        {
            (MainWindow as MainWindow).LoadMenuView();
        }


        #region Events


        
        #endregion
    }

}
