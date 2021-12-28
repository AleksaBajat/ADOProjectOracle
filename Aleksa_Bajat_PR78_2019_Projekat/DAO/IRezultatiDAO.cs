using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4;
using Aleksa_Bajat_PR78_2019_Projekat.Models;

namespace Aleksa_Bajat_PR78_2019_Projekat.DAO.Impl
{
    internal interface IRezultatiDAO:ICRUDDao<Rezultat,string>
    { 
        int DeleteById(int id);


        IEnumerable<Rezultat> FindAllById(int id);

        double GetAverage(int id);

        List<Rezultat> FindFirstPlacementById(int id);


        int NijePrvi(int id);


        Rezultat FindById(string idr, int idv);
    }
}
