using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToolsWpf.Internal;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf.ViewModels
{
    class ConnexionViewModel : ObservableObject
    {
        private string _Login;

        private string _Password;

        private bool _IsLoggedIn;

        public string Login { get => _Login; set => _Login = value; }
        public string Password { get => _Password; set => _Password = value; }
        public bool IsLoggedIn { get => _IsLoggedIn; set => SetProperty(nameof(IsLoggedIn), ref _IsLoggedIn, value); }

        public ConnexionViewModel()
        {
            Login = "admin@admin.com";
            Password = "admin-Password";
        }
        internal void ConnexionValidator()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                User? user = context.Users.FirstOrDefault(u => u.Email == Login);
                if (user != null)
                {
                    string userPassword = user.Password.Replace("$2y$13$", "$2a$13$");
                    bool valide = false;
                    if (Password != null)
                    {
                        valide = BCrypt.Net.BCrypt.Verify(Password, userPassword);
                        if (valide && (user.Roles.Contains("ROLE_ADMIN") || user.Roles.Contains("ROLE_COMPT")))
                        {
                            IsLoggedIn = true;
                            (Application.Current as App).User = user;
                            (Application.Current as App).ValidLogin();
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe non valide !!!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le mot de passe ne peut pas être vide !!!!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }
    }
}
