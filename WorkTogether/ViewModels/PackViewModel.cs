using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using ToolsWpf.Internal;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf.ViewModels
{
    class PackViewModel : ObservableObject
    {

        #region Fields
        private ObservableCollection<Pack> _Packs;

        private Pack _SelectedPack;

        private DelegateCommand<object> _CommandAddPack;

        private DelegateCommand<object> _CommandModifyPack;

        private DelegateCommand<object> _CommandRemovePack;
        #endregion

        #region Properties
        public ObservableCollection<Pack> Packs
        {
            get => _Packs;
            set => SetProperty(nameof(Packs), ref _Packs, value);
        }
        public Pack SelectedPack
        {
            get => _SelectedPack;
            set => SetProperty(nameof(SelectedPack), ref _SelectedPack, value);
        }

        public DelegateCommand<object> CommandAddPack { get => _CommandAddPack; set => _CommandAddPack = value; }

        public DelegateCommand<object> CommandModifyPack { get => _CommandModifyPack; set => _CommandModifyPack = value; }

        public DelegateCommand<object> CommandRemovePack { get => _CommandRemovePack; set => _CommandRemovePack = value; }
        #endregion

        #region Constructors
        public PackViewModel()
        {
            CommandAddPack = new DelegateCommand<object>(AddPack)
            .ObservesProperty(() => this.SelectedPack);
            CommandModifyPack = new DelegateCommand<object>(ModifyPack)
                .ObservesProperty(() => this.SelectedPack);
            CommandRemovePack = new DelegateCommand<object>(RemovePack)
                .ObservesProperty(() => this.SelectedPack);
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Packs = new ObservableCollection<Pack>(context.Packs);
            }
        }
        #endregion

        #region Methods
        internal void AddPack(object parameter = null)
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                Pack newPack = new Pack()
                {
                    Name = "Nouveaux Pack",
                };
                if (!context.Packs.Any(p => p.Name == newPack.Name))
                {
                    context.Packs.Add(newPack);
                    this.Packs.Add(newPack);
                    SelectedPack = newPack;
                    context.SaveChanges();

                }
            }
        }
        internal void RemovePack(object parameter = null)
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedPack != null)
                {
                    context.Packs.Remove(SelectedPack);
                    this.Packs.Remove(SelectedPack);
                    context.SaveChanges();
                }

                this.SelectedPack = null;
            }
        }
        internal void ModifyPack(object parameter = null)
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedPack != null)
                {
                    context.Update(this.SelectedPack);
                    context.SaveChanges();
                }

            }
        }
        #endregion

    }
}
