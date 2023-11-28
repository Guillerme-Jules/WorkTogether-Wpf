using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf.ViewModels
{
    class RackViewModel
    {
        #region Fields
        private ObservableCollection<Rack> _Racks;

        private Rack _SelectedRack;

        #endregion

        #region Properties
        public ObservableCollection<Rack> Racks { get => _Racks; set => _Racks = value; }
        public Rack SelectedRack { get => _SelectedRack; set => _SelectedRack = value; }

        #endregion

        #region Constructors
        public RackViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Racks = new ObservableCollection<Rack>(context.Racks);
            }
        }
        #endregion

        #region Methods

        #endregion




    }
}
