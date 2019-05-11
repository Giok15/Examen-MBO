using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
    public class Bedrijfsinformatie
    {
        public int kvk_nummer { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public string postcode { get; set; }
        public string plaats { get; set; }
        public string rekeningnummer { get; set; }
        public string telefoonnummer { get; set; }
        public string btw_nummer { get; set; }
    }
}
