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
        /// <summary>
        /// La liste des pack
        /// </summary>
        private ObservableCollection<Pack> _Packs;

        /// <summary>
        /// Le pack selectionner
        /// </summary>
        private Pack _SelectedPack;

        /// <summary>
        /// Commande pour ajouter un pack
        /// </summary>
        private DelegateCommand<object> _CommandAddPack;

        /// <summary>
        /// Commande pour modifier un pack
        /// </summary>
        private DelegateCommand<object> _CommandModifyPack;

        /// <summary>
        /// Commande pour supprimer un pack
        /// </summary>
        private DelegateCommand<object> _CommandRemovePack;
        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste des pack
        /// </summary>
        public ObservableCollection<Pack> Packs
        {
            get => _Packs;
            set => SetProperty(nameof(Packs), ref _Packs, value);
        }

        /// <summary>
        /// Recuperer et modifier le pack selectionner
        /// </summary>
        public Pack SelectedPack
        {
            get => _SelectedPack;
            set => SetProperty(nameof(SelectedPack), ref _SelectedPack, value);
        }

        /// <summary>
        /// Recuperer et modifier la commande ajouter
        /// </summary>
        public DelegateCommand<object> CommandAddPack { get => _CommandAddPack; set => _CommandAddPack = value; }

        /// <summary>
        /// Recuperer et modifier la commande modifier
        /// </summary>
        public DelegateCommand<object> CommandModifyPack { get => _CommandModifyPack; set => _CommandModifyPack = value; }

        /// <summary>
        /// Recuperer et modifier la commande supprimer
        /// </summary>
        public DelegateCommand<object> CommandRemovePack { get => _CommandRemovePack; set => _CommandRemovePack = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Construteur de PackViewModel
        /// </summary>
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
        /// <summary>
        /// Methode d'ajout de pack
        /// </summary>
        /// <param name="parameter"></param>
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
        /// <summary>
        /// Methode supprimer pack
        /// </summary>
        /// <param name="parameter"></param>
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
        /// <summary>
        /// Methode modifier pack
        /// </summary>
        /// <param name="parameter"></param>
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
