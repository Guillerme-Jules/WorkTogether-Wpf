using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        #region Fields
        /// <summary>
        /// Le nom d'utilisateur
        /// </summary>
        private string _Login;

        /// <summary>
        /// Le mod de passe
        /// </summary>
        private string _Password;

        /// <summary>
        /// Boolean de connection
        /// </summary>
        private bool _IsLoggedIn;
        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier le nom d'utilisateur
        /// </summary>
        public string Login { get => _Login; set => _Login = value; }

        /// <summary>
        /// Recuperer et modifier le mod de passe
        /// </summary>
        public string Password { get => _Password; set => _Password = value; }

        /// <summary>
        /// Recuperer et modifier le boolean de connexion
        /// </summary>
        public bool IsLoggedIn { get => _IsLoggedIn; set => SetProperty(nameof(IsLoggedIn), ref _IsLoggedIn, value); }
        #endregion

        #region Constructors
        public ConnexionViewModel()
        {
            Login = "admin@admin.com";
            Password = "admin-Password";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methode pour vérifier la connexion d'un utilisateur.
        /// </summary>
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
        #endregion
    }
}
