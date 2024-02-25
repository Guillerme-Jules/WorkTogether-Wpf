using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsWpf.Internal;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf.ViewModels
{
    class ClientViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// La liste des clients
        /// </summary>
        private ObservableCollection<Customer> _Customers;

        /// <summary>
        /// Le client selectionner
        /// </summary>
        private Customer _SelectedCustomer;
        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste de clients 
        /// </summary>
        public ObservableCollection<Customer> Customers
        {
            get => _Customers;
            set => SetProperty(nameof(Customers), ref _Customers, value);
        }
        /// <summary>
        /// Recuperer et modifier le client selectionner
        /// </summary>
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set => SetProperty(nameof(SelectedCustomer), ref _SelectedCustomer, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Construteur de ClientViewModel
        /// </summary>
        public ClientViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Customers = new ObservableCollection<Customer>(context.Customers);
            }
        }
        #endregion

        #region Methods

        #endregion

    }
}
