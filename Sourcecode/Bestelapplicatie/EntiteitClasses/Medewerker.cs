﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.EntiteitClasses
{
    public class Medewerker
    {
         public int id { get; set; }
         public string voornaam { get; set; }
         public string achternaam { get; set; }
         public string gebruikersnaam { get; set; }
          public string wachtwoord { get; set; }
          public string rechten { get; set; }
    }
}
