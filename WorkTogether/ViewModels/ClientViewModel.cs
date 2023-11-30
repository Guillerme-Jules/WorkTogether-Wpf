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
        private ObservableCollection<Customer> _Customers;

        private Customer _SelectedCustomer;
        #endregion

        #region Properties
        public ObservableCollection<Customer> Customers
        {
            get => _Customers;
            set => SetProperty(nameof(Customers), ref _Customers, value);
        }
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set => SetProperty(nameof(SelectedCustomer), ref _SelectedCustomer, value);
        }
        #endregion

        #region Constructors
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
