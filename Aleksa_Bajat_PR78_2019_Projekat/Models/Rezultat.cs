using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleksa_Bajat_PR78_2019_Projekat.Models
{
    internal class Rezultat
    {
        public string Idr { get; set; }
        public int Idv { get; set; }

        public int Ids { get; set; }

        public int Sezona { get; set; }

        public int Plasman { get; set; }

        public int Bodovi { get; set; }

        public double MaksBrzina { get; set; }

        public Rezultat(string idr, int idv, int ids, int sezona, int plasman, int bodovi, double maksBrzina)
        {
            Idr = idr;
            Idv = idv;
            Ids = ids;
            Sezona = sezona;
            Plasman = plasman;
            Bodovi = bodovi;
            MaksBrzina = maksBrzina;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10} {6,10}",
                Idr, Idv, Ids, Sezona, Plasman,Bodovi,MaksBrzina);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10} {6,10}",
                "IDR", "IDV", "IDS", "SEZONA", "PLASMAN", "BODOVA", "MAKSBRZINA");
        }
    }
}
