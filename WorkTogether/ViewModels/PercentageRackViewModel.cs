using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using ToolsWpf.Internal;
using WorkTogether.DBlib.Class;



namespace WorkTogether.Wpf.ViewModels
{
    class PercentageRackViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// Liste des baies
        /// </summary>
        private ObservableCollection<Rack> _Racks;

        /// <summary>
        /// Chaine de carractére pour l'occupation d'une baie
        /// </summary>
        private StringBuilder _Occupation;
        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste des baie
        /// </summary>
        public ObservableCollection<Rack> Racks
        {
            get => _Racks;
            set => SetProperty(nameof(Racks), ref _Racks, value);
        }
        /// <summary>
        /// Recuperer et modifier la chaine de carractére
        /// </summary>
        public StringBuilder Occupation { get => _Occupation; set => _Occupation = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur de PercentageRackViewModel
        /// </summary>
        public PercentageRackViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                context.Racks.Include(b => b.Units).ThenInclude(u => u.Reservation).Load();
                this.Racks = new ObservableCollection<Rack>(context.Racks);
                this.Occupation = this.RacksOccupation();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methode pour récuperer l'occupation des baies
        /// </summary>
        /// <returns></returns>
        internal StringBuilder RacksOccupation()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Rack rack in Racks)
                {
                    double rackOccupation = (rack.Units.Where(u => u.Reservation != null).Count()) * 100.00 / rack.NumberSlot;
                    stringBuilder.AppendLine("Baie°" + rack.Id + ": " + rackOccupation + "%");
                }
                return stringBuilder;
            }
        }
        /// <summary>
        /// Methode d'export d'un fichier pdf de l'occupation des baies
        /// </summary>
        internal void ExportToPdf()
        {
            System.IO.FileStream fs = new FileStream("C:\\Users\\Guillerme\\BTS IIA\\Csharp2\\Moi\\Document WorkTogether\\" + "Occupation_Baie" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".pdf", FileMode.Create);


            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            // Ajoutez une phrase simple et bien connue au document de manière fluide  
            document.Add(new iTextSharp.text.Paragraph(this.RacksOccupation().ToString()));
            // Ferme le document  
            document.Close();
            // Ferme l'instance du rédacteur  
            writer.Close();
            // Toujours fermer explicitement les descripteurs de fichiers ouverts  
            fs.Close();

            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var psi = new ProcessStartInfo();
            psi.FileName = @"c:\windows\explorer.exe";
            psi.Arguments = "C:\\Users\\Guillerme\\BTS IIA\\Csharp2\\Moi\\Document WorkTogether";
            Process.Start(psi);
        }
        #endregion










    }
}
