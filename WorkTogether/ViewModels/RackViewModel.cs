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

namespace WorkTogether.Wpf.ViewModels
{
    class RackViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<Rack> _Racks;

        private Rack _SelectedRack;

        private DelegateCommand<object> _CommandAddRack;

        private DelegateCommand<object> _CommandRemoveRack;

        #endregion

        #region Properties
        public ObservableCollection<Rack> Racks
        {
            get => _Racks;
            set => SetProperty(nameof(Racks), ref _Racks, value);
        }
        public Rack SelectedRack
        {
            get => _SelectedRack;
            set => SetProperty(nameof(SelectedRack), ref _SelectedRack, value);
        }
        public DelegateCommand<object> CommandAddRack { get => _CommandAddRack; set => _CommandAddRack = value; }
        public DelegateCommand<object> CommandRemoveRack { get => _CommandRemoveRack; set => _CommandRemoveRack = value; }

        #endregion

        #region Constructors
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
