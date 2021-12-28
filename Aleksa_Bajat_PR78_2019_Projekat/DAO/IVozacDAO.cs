using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4;
using Aleksa_Bajat_PR78_2019_Projekat.Models;

namespace Aleksa_Bajat_PR78_2019_Projekat.DAO
{
    internal interface IVozacDAO:ICRUDDao<Vozac,int>
    {
        List<VozacOsnovneInformacijeDTA> ListaOsnovnihInformacija();
    }
}
