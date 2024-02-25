﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkTogether.Wpf.ViewModels;

namespace WorkTogether.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour PercentageRackView.xaml
    /// </summary>
    public partial class PercentageRackView : UserControl
    {
        public PercentageRackView()
        {
            InitializeComponent();
            this.DataContext = new PercentageRackViewModel();
        }

        private void OccupationBaie_Click(object sender, RoutedEventArgs e)
        {
            ((PercentageRackViewModel)this.DataContext).ExportToPdf();
        }
    }
}
