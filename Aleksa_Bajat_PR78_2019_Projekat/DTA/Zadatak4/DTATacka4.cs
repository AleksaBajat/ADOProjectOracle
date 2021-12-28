using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.Models;

namespace Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4
{
    internal class DTATacka4
    {
        public List<VozacOsnovneInformacijeDTA> OsnovneInformacije { get; set; } =
            new List<VozacOsnovneInformacijeDTA>();

        public List<List<Rezultat>> RezultatiPrvaMesta { get; set; } = new List<List<Rezultat>>();

        public List<int> BrojTrkaNijePrvi { get; set; } = new List<int>();

    }
}
