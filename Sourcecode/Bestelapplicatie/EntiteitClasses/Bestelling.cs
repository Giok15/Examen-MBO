using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
   public class Bestelling
    {
        public int id { get; set; }
        public DateTime besteldatum { get; set; }
        public DateTime leverdatum { get; set; }
        public string status { get; set; }
        public string factuur { get; set; }
        public int klant_id { get; set; }
    }
}
