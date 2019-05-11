using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
   public class Boek
    {
         public string isbn_nummer { get; set; }
         public string titel { get; set; }
         public string auteur { get; set; }
         public string beschrijving { get; set; }
         public string genre { get; set; }
         public decimal prijs { get; set; }
         public bool zichtbaar { get; set; }
         public string uitgeversector_naam { get; set; }
    }
}
