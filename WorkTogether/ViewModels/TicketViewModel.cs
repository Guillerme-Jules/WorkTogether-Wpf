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
    class TicketViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// Liste des tickets
        /// </summary>
        private ObservableCollection<CustomerTicket> _Tickets;

        /// <summary>
        /// Ticket selectionner
        /// </summary>
        private CustomerTicket _SelectedTicket;


        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste des Tickets
        /// </summary>
        public ObservableCollection<CustomerTicket> Tickets { get => _Tickets; set => SetProperty(nameof(Tickets), ref _Tickets, value); }
        /// <summary>
        /// Recuperer et modifier le ticket selectionner
        /// </summary>
        public CustomerTicket SelectedTicket { get => _SelectedTicket; set => SetProperty(nameof(SelectedTicket), ref _SelectedTicket, value); }
        #endregion

        #region Constructors
        /// <summary>
        /// Construteur de TicketViewModel
        /// </summary>
        public TicketViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                context.CustomerTickets.Include(r => r.Customer).Load();

                this.Tickets = new ObservableCollection<CustomerTicket>(context.CustomerTickets);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methode ticket vérifier
        /// </summary>
        public void Checked()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                context.Update(SelectedTicket);
                context.SaveChanges();
            }

        }
        #endregion

    }
}
