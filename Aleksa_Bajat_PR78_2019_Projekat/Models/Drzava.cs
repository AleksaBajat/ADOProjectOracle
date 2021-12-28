using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleksa_Bajat_PR78_2019_Projekat.Models
{
    internal class Drzava
    {
        public int Idd { get; set; }
        public string NazivD { get; set; }

        public Drzava(int idd, string nazivD)
        {
            Idd = idd;
            NazivD = nazivD;
        }
    }
}
