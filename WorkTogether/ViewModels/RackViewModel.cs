using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.DBlib.Class;
using ToolsWpf.Internal;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace WorkTogether.Wpf.ViewModels
{
    class RackViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// La liste des baies
        /// </summary>
        private ObservableCollection<Rack> _Racks;

        /// <summary>
        /// La baie selectionner
        /// </summary>

        private Rack _SelectedRack;

        /// <summary>
        /// Commande ajout baie
        /// </summary>
        private DelegateCommand<object> _CommandAddRack;

        /// <summary>
        /// Commande supprimer baie
        /// </summary>
        private DelegateCommand<object> _CommandRemoveRack;

        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste des baies
        /// </summary>
        public ObservableCollection<Rack> Racks
        {
            get => _Racks;
            set => SetProperty(nameof(Racks), ref _Racks, value);
        }
        /// <summary>
        /// Recuperer et modifier la baie selectionner 
        /// </summary>
        public Rack SelectedRack
        {
            get => _SelectedRack;
            set => SetProperty(nameof(SelectedRack), ref _SelectedRack, value);
        }
        /// <summary>
        /// Recuperer et modifier la commande ajout
        /// </summary>
        public DelegateCommand<object> CommandAddRack { get => _CommandAddRack; set => _CommandAddRack = value; }
        /// <summary>
        /// Recuperer et modifier la commande supprimer
        /// </summary>
        public DelegateCommand<object> CommandRemoveRack { get => _CommandRemoveRack; set => _CommandRemoveRack = value; }

        #endregion

        #region Constructors
        /// <summary>
        /// Construteur RackViewModel
        /// </summary>
        public RackViewModel()
        {
            CommandAddRack = new DelegateCommand<object>(AddRack);

            CommandRemoveRack = new DelegateCommand<object>(RemoveRack).ObservesProperty(() => this.SelectedRack);


            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                context.Racks.Include(b => b.Units).ThenInclude(u => u.Reservation).Load();
                this.Racks = new ObservableCollection<Rack>(context.Racks);
                
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methode ajout baie
        /// </summary>
        /// <param name="parameter"></param>
        internal void AddRack(object parameter = null)
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                Rack newRack = new Rack() { NumberSlot = 42 };
                context.Racks.Add(newRack);
                this.Racks.Add(newRack);
                for (int i = 0; i < newRack.NumberSlot; i++)
                {
                    Unit newUnit = new Unit()
                    {
                        Rack = newRack,
                        LocationSlot = i + 1,
                    };
                    context.Add(newUnit);
                }
                SelectedRack = newRack;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Methode modifier baie
        /// </summary>
        /// <param name="parameter"></param>
        internal void RemoveRack(object parameter = null)
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedRack != null)
                {
                    ICollection<Unit> units = SelectedRack.Units;
                    bool CanRemove = units.Any(u => u.Reservation != null);
                    if (!CanRemove)
                    {
                        foreach (Unit unit in units)
                        {
                            context.Units.Remove(unit);
                        }
                        context.SaveChanges();
                        context.Racks.Remove(SelectedRack);
                        this.Racks.Remove(SelectedRack);
                        context.SaveChanges();
                    }
                }
            }
        }

        

        
        #endregion




    }
}
