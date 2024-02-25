using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ToolsWpf.Internal;
using WorkTogether.DBlib.Class;
using Document = iTextSharp.text.Document;

namespace WorkTogether.Wpf.ViewModels
{
    class ReservationViewModel : ObservableObject
    {

        #region Fields
        /// <summary>
        /// La liste des reservations
        /// </summary>
        private ObservableCollection<Reservation> _Reservations;

        /// <summary>
        /// La reservation selectionner
        /// </summary>
        private Reservation _SelectedReservation;
        #endregion

        #region Properties
        /// <summary>
        /// Recuperer et modifier la liste des reservations
        /// </summary>
        public ObservableCollection<Reservation> Reservations
        {
            get => _Reservations;
            set => SetProperty(nameof(Reservations), ref _Reservations, value);
        }
        /// <summary>
        /// Recuperer et modifier la reservation selectionner
        /// </summary>
        public Reservation SelectedReservation
        {
            get => _SelectedReservation;
            set => SetProperty(nameof(SelectedReservation), ref _SelectedReservation, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Construteur de ReservationViewModel
        /// </summary>
        public ReservationViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                context.Reservations.Include(r => r.Pack).Load();
                context.Reservations.Include(r => r.Client).Load();

                this.Reservations = new ObservableCollection<Reservation>(context.Reservations);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methode d'export fichier pdf des reservations
        /// </summary>
        internal void ExportToPdf()
        {

            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("Liste des réservations : " + Environment.NewLine);

            foreach (var resa in this.Reservations)
            {
                stringBuilder.AppendLine("Code : " + resa.Code + " Prix : " + resa.Price + "€ " + " Nom du pack " + resa.Pack.Name);
            }

            System.IO.FileStream fs = new FileStream("C:\\Users\\Guillerme\\BTS IIA\\Csharp2\\Moi\\Document WorkTogether\\" + "Reservation"+DateTime.Now.ToString("yyyyMMdd_hhmmss")+".pdf", FileMode.Create);


            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            // Ajoutez une phrase simple et bien connue au document de manière fluide  
            document.Add(new iTextSharp.text.Paragraph(stringBuilder.ToString()));
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
        /// <summary>
        /// Methode d'export fichier csv des reservations
        /// </summary>
        internal void ExportToCsv()
        {

            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("Code,Prix,Nom du pack");

            foreach (var resa in this.Reservations)
            {
                stringBuilder.AppendLine(resa.Code + "," + resa.Price + "," + resa.Pack.Name);
            }

            System.IO.FileStream fs = new FileStream("C:\\Users\\Guillerme\\BTS IIA\\Csharp2\\Moi\\Document WorkTogether\\" + "Reservation" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", FileMode.Create);


            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            // Ajoutez une phrase simple et bien connue au document de manière fluide  
            document.Add(new iTextSharp.text.Paragraph(stringBuilder.ToString()));
            // Ferme le document  
            document.Close();
            // Ferme l'instance du rédacteur  
            writer.Close();
            // Toujours fermer explicitement les descripteurs de fichiers ouverts  
            fs.Close();

            
        }
        #endregion

    }
}
