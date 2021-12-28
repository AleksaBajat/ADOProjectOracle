using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleksa_Bajat_PR78_2019_Projekat.Models
{
    internal class Vozac
    {
        public int IdV { get; set; }

        public string ImeV { get; set; }
        public string PrezV { get; set; }

        public int Godrodj { get; set; }

        public int BrojTit { get; set; }
        
        public int DrzV { get; set; }


        public Vozac(int idv, string imev, string prez,int godrodj ,int brojtit, int drzv)
        {
            IdV = idv;
            ImeV = imev;
            PrezV = prez;
            BrojTit = brojtit;
            DrzV = drzv;
            Godrodj = godrodj;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10}",
                IdV, ImeV, PrezV,Godrodj, BrojTit, DrzV);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10}",
                "IDV", "IMEV", "PREZV","GODRODJ", "BROJTIT", "DRZV");
        }

        public override bool Equals(object obj)
        {
            var vozac = obj as Vozac;

            return vozac != null &&
                   IdV == vozac.IdV &&
                   ImeV == vozac.ImeV &&
                   PrezV == vozac.PrezV &&
                   BrojTit == vozac.BrojTit &&
                   DrzV == vozac.DrzV &&
                   Godrodj == vozac.Godrodj;
        }
    }
}
