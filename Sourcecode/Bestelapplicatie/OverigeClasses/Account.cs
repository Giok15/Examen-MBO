using Bestelapplicatie.EntiteitClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestelapplicatie.OverigeClasses
{
    static class Account
    {
      private static Medewerker account = new Medewerker();

        public static void inloggen(Medewerker medewerker)
        {
            account = medewerker;
        }

        public static Medewerker getMedewerker()
        {
            return account;
        }

        public static void uitloggen()
        {
            account = null;
        }
    }
}
