using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.DAO.Impl;
using Aleksa_Bajat_PR78_2019_Projekat.DTA;
using Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4;
using Aleksa_Bajat_PR78_2019_Projekat.Models;

namespace Aleksa_Bajat_PR78_2019_Projekat.Service
{
    internal class RezultatService
    {
        private readonly RezultatiDAOImpl _rezultatiDaoImpl = new RezultatiDAOImpl();
        private readonly VozacDAOImpl _vozacDaoImpl = new VozacDAOImpl();


        public DTATacka3 RezultatiPrekoIDProsekBodova(int id)
        {
            DTATacka3 dta = new DTATacka3();

            dta.Rezultati = _rezultatiDaoImpl.FindAllById(id).ToList();
            dta.Average = _rezultatiDaoImpl.GetAverage(id);

            return dta;
        }

        public DTATacka4 IzvestajIRezultati()
        {
            DTATacka4 dta = new DTATacka4();

            dta.OsnovneInformacije = _vozacDaoImpl.ListaOsnovnihInformacija();


            foreach (VozacOsnovneInformacijeDTA info in dta.OsnovneInformacije)
            {
                dta.RezultatiPrvaMesta.Add(_rezultatiDaoImpl.FindFirstPlacementById(info.Idv));
                dta.BrojTrkaNijePrvi.Add(_rezultatiDaoImpl.NijePrvi(info.Idv));
            }

            

            return dta;
        }

        public void BrisanjeRezultata(int idv, string idr)
        {
            Rezultat rez = _rezultatiDaoImpl.FindById(idr, idv);

            if (rez != null)
            {
                if (rez.Plasman == 1)
                {
                    _rezultatiDaoImpl.DeleteById(idr);
                    Vozac v = _vozacDaoImpl.FindById(rez.Idv);

                    v.BrojTit -= 1;

                    _vozacDaoImpl.Save(v);
                }
                else
                {
                    _rezultatiDaoImpl.DeleteById(idr);
                }
            }
        }

        public List<Rezultat> IspisSvihRezultata()
        {
            return _rezultatiDaoImpl.FindAll().ToList();
        }
    }
}
