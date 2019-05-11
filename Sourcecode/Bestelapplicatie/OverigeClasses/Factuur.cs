using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.IO;
using Bestelapplicatie.EntiteitClasses;
using System.Diagnostics;

namespace Bestelapplicatie.OverigeClasses
{
    class Factuur
    {
        public string aanmaken(Klant klant, Bedrijfsinformatie bedrijf, Bestelling bestelling, string datum, string omschrijving, string aantal, string prijs, string prijsTotaal, string totaal)
        {
            string factuurdatum = bestelling.besteldatum.ToString().Substring(0, bestelling.besteldatum.ToString().Length - 3);
            object fileStandaard = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "factuur.docx");
            object fileSave = @"C:\Users\Giovanni\Documents\Facturen\" + "Factuur_" + bestelling.id + ".docx";
            object fileSavePdf = @"C:\Users\Giovanni\Documents\Facturen\" + "Factuur_" + bestelling.id + ".pdf";

            File.Copy(fileStandaard.ToString(), fileSave.ToString(), true);

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = true };

            Document aDoc = wordApp.Documents.Open(ref fileSave, ReadOnly: false, Visible: true);

            Find fnd = wordApp.ActiveWindow.Selection.Find;

            fnd.ClearFormatting();
            fnd.Replacement.ClearFormatting();
            fnd.Forward = true;

            fnd.Wrap = WdFindWrap.wdFindContinue;

            //klantgegevens

            fnd.Text = "%voorletter%";
            fnd.Replacement.Text = Convert.ToString(klant.voornaam[0]);
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%achternaam%";
            fnd.Replacement.Text = klant.achternaam;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%adres%";
            fnd.Replacement.Text = klant.adres;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%postcode%";
            fnd.Replacement.Text = klant.postcode;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%woonplaats%";
            fnd.Replacement.Text = klant.woonplaats;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%email%";
            fnd.Replacement.Text = klant.email;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%telefoon%";
            fnd.Replacement.Text = klant.telefoon;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            //bedrijfsgegevens

            fnd.Text = "%naamBed%";
            fnd.Replacement.Text = bedrijf.naam;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%adresBed%";
            fnd.Replacement.Text = bedrijf.adres;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%postcodeBed%";
            fnd.Replacement.Text = bedrijf.postcode;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%plaatsBed%";
            fnd.Replacement.Text = bedrijf.plaats;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%kvknummerBed%";
            fnd.Replacement.Text = Convert.ToString(bedrijf.kvk_nummer);
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%btwnummerBed%";
            fnd.Replacement.Text = bedrijf.btw_nummer;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%rekeningnummerBed%";
            fnd.Replacement.Text = bedrijf.rekeningnummer;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            //factuurgegevens

            fnd.Text = "%factuurnummer%";
            fnd.Replacement.Text = Convert.ToString(bestelling.id);
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%factuurdatum%";
            fnd.Replacement.Text = Convert.ToString(factuurdatum);
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            //orderregels

            fnd.Text = "%datum%";
            fnd.Replacement.Text = datum;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%omschrijving%";
            fnd.Replacement.Text = omschrijving;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%aantal%";
            fnd.Replacement.Text = aantal;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%prijs%";
            fnd.Replacement.Text = prijs;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            fnd.Text = "%totaalprijs%";
            fnd.Replacement.Text = prijsTotaal;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            //totaal

            fnd.Text = "%totaal%";
            fnd.Replacement.Text = totaal;
            fnd.Execute(Replace: WdReplace.wdReplaceAll);

            aDoc.Save();

            foreach (Process p in Process.GetProcessesByName("WINWORD"))
            {
                p.Kill();
            }

            converteerPdf(bestelling);
            return Convert.ToString(fileSavePdf);
        }

        public void overzicht(Bestelling bestelling)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = bestelling.factuur;
            process.Start();
        }

        public void printen(Bestelling bestelling)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = bestelling.factuur;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);

            if (false == p.CloseMainWindow())
                p.Kill();
        }

        private void converteerPdf(Bestelling bestelling)
        {
            // Create a new Microsoft Word application object
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            // C# doesn't have optional arguments so we'll need a dummy value
            object oMissing = System.Reflection.Missing.Value;

            // Get list of Word files in specified directory
            FileInfo wordFile = new FileInfo(@"C:\Users\Giovanni\Documents\Facturen\" + "Factuur_" + bestelling.id + ".docx");

            word.Visible = false;
            word.ScreenUpdating = false;

                // Cast as Object for word Open method
                Object filename = (Object)wordFile.FullName;

                // Use the dummy value as a placeholder for optional arguments
                Document doc = word.Documents.Open(ref filename, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                doc.Activate();

                object outputFileName = wordFile.FullName.Replace(".docx", ".pdf");
                object fileFormat = WdSaveFormat.wdFormatPDF;

                // Save document into PDF Format
                doc.SaveAs(ref outputFileName,
                    ref fileFormat, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);

              
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
                doc = null;

        ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
                    word = null;

            File.Delete(@"C:\Users\Giovanni\Documents\Facturen\" + "Factuur_" + bestelling.id + ".docx");
        }
    }
}
