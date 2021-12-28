using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.DAO.Impl;
using Aleksa_Bajat_PR78_2019_Projekat.Models;

namespace Aleksa_Bajat_PR78_2019_Projekat.Service
{
    internal class VozacService
    {
        private static readonly VozacDAOImpl vozacDAO = new VozacDAOImpl();

        public int BrojVozaca()
        {
            return vozacDAO.Count();
        }

        public int ObrisiVozaca(int id)
        {
            return vozacDAO.DeleteById(id);
        }

        public bool ProveraPostojanjaVozaca(int id)
        {
            return vozacDAO.ExistsById(id);
        }

        public List<Vozac> IspisiSveVozace()
        {
            return vozacDAO.FindAll().ToList();
        }

        public Vozac IspisiVozaca(int id)
        {
            return vozacDAO.FindById(id);
        }

        public List<Vozac> IspisiSveVozaceSaID(List<int> ids)
        {
            return vozacDAO.FindAllById(ids).ToList();
        }

        public int UnesiIzmeniVozaca(Vozac v)
        {
            return vozacDAO.Save(v);
        }

        public int UnesiIzmeniVozace(List<Vozac> vs)
        {
            return vozacDAO.SaveAll(vs);
        }

        public int ObrisiSveVozace()
        {
            return vozacDAO.DeleteAll();
        }

    }
}
