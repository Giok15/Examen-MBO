using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Bestelapplicatie.EntiteitClasses;
using System.Windows.Forms;

namespace Bestelapplicatie.OverigeClasses
{
    class Mail
    {
        SmtpClient sc = new SmtpClient();
        MailMessage msg = new MailMessage();
        private bool is_verstuurd;

        private string verzendEmail = "norepl_UitgeverijHetBoekje@outlook.com";
        private string verzendWw = "Uitgeverij1";
        private string verzendSmtpserver = "smtp-mail.outlook.com";
        private int verzendPort = 587;

        private string ontvanger;
        private string onderwerp;
        private string bericht;
        private byte[] byteFactuur;
        private string factuurLocatie;

        private string factuurnummer;

        public void mailAanmaken(Klant klant, Bestelling bestelling, string factuur = null)
        {
            factuurnummer = Convert.ToString(bestelling.id);
            factuurLocatie = factuur;

            if (factuurLocatie != null)
            {
                byteFactuur = File.ReadAllBytes(factuurLocatie);
                ontvanger = klant.email;
                onderwerp = "Factuur:" + bestelling.id;
                bericht = "Geachte " + klant.voornaam[0] + ". " + klant.achternaam + "<br></br> in de bijlage vind u uw factuur van de bestelling op: " +
                          bestelling.besteldatum + "<br></br><br></br>" +
                            "Uitgeverij HetBoekje" + "<br></br>" +
                            "Kortendijksestraat 77" + "<br></br>" +
                            "4706 TR Roosendaal" + "<br></br>" +
                            "Tel: 0165 - 567990" + "<br></br>";
            }
            else
            {
                ontvanger = klant.email;
                onderwerp = "Uw artikel is bij ons binnen";
                bericht = "Geachte " + klant.voornaam[0] + ". " + klant.achternaam + "<br></br> Uw artikel dat u besteld heeft op: " + bestelling.besteldatum.ToString().Substring(0, bestelling.besteldatum.ToString().Length - 3) + " staat klaar." +
                          "<br></br> " + "U kunt deze bij ons komen ophalen." + "<br></br><br></br>" +
                            "Uitgeverij HetBoekje" + "<br></br>" +
                            "Kortendijksestraat 77" + "<br></br>" +
                            "4706 TR Roosendaal" + "<br></br>" +
                            "Tel: 0165 - 567990" + "<br></br>";
            }

            bool result = Stuur();
            {
                if (result == false)
                {
                   MessageBox.Show("Mail is niet verzonden, neem contact op met de programmeur", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); System.Windows.Forms.Application.Exit();
                }
            }
        }

        private bool Stuur()
        {
            try
            {
                msg.To.Add(new MailAddress(ontvanger));
                msg.From = new MailAddress(verzendEmail);

                msg.Subject = onderwerp;
                msg.IsBodyHtml = true;

                string htmlFile = bericht;
                msg.Body = htmlFile;

                sc.Port = verzendPort;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Host = verzendSmtpserver;
                sc.UseDefaultCredentials = false;
                NetworkCredential inlogGegevens = new NetworkCredential(verzendEmail, verzendWw);
                sc.Credentials = inlogGegevens;
                sc.EnableSsl = true;

                if (byteFactuur != null)
                {
                    MemoryStream stream = new MemoryStream(byteFactuur);
                    Attachment attachment = new Attachment(stream, "Factuur " + factuurnummer + ".pdf");
                    msg.Attachments.Add(attachment);
                }

                sc.Send(msg);
                return is_verstuurd = true;
            }
            catch
            {
                return is_verstuurd = false;

            }
        }
    }
}
