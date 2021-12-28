using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4
{
    internal class VozacOsnovneInformacijeDTA
    {
        public int Idv { get; set; }

        public string Imev { get; set; }

        public string Prezv { get; set; }

        public int Brojtit { get; set; }

        public int Godrodj { get; set; }

        public string Drzava { get; set; }

        public VozacOsnovneInformacijeDTA(int idv, string imev, string prezv, int brojtit, int godrodj, string drzava)
        {
            Idv = idv;
            Imev = imev;
            Prezv = prezv;
            Brojtit = brojtit;
            Godrodj = godrodj;
            Drzava = drzava;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10}",
                Idv, Imev, Prezv, Brojtit,Godrodj, Drzava);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10}",
                "IDV", "IMEV", "PREZV", "BROJTIT","GODRODJ", "DRZV");
        }
    }
}
