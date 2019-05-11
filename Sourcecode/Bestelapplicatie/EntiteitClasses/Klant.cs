using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
    public class Klant
    {
         public int id { get; set; }
          public string voornaam { get; set; }
          public string achternaam { get; set; }
          public string adres { get; set; }
          public string postcode { get; set; }
          public string woonplaats { get; set; }
          public string email { get; set; }
          public string telefoon { get; set; }
    }
}
