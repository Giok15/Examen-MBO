﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
    public class Bestellingregel
    {
         public string boek_isbn_nummer { get; set; }
         public int bestelling_id { get; set; }
         public int aantal { get; set; }
    }
}
