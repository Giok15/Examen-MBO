using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
    public class Logging
    {
         public int id { get; set; }
          public string onderwerp { get; set; }
          public string handeling { get; set; }
          public DateTime datum { get; set; }
          public int medewerker_id { get; set; }
          public string boek_isbn_nummer { get; set; }
          public int bestelling_id { get; set; }
         public int klant_id { get; set; }
    }
}
