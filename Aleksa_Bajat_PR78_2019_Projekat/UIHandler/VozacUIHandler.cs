using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.Models;
using Aleksa_Bajat_PR78_2019_Projekat.Service;

namespace Aleksa_Bajat_PR78_2019_Projekat.UIHandler
{
    internal class VozacUIHandler
    {
        private readonly VozacService _vozacService = new VozacService();

        public void HandleVozacUI()
        {
            string ans = null;
            

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Broj Vozaca");
                Console.WriteLine("2. Obrisi Vozaca");
                Console.WriteLine("3. Proveri Postojanje Vozaca");
                Console.WriteLine("4. Ispisi Sve Vozace");
                Console.WriteLine("5 - Ispisi Vozaca");
                Console.WriteLine("6 - Ispisi Sve Vozace Specificnog Identifikacionog Broja");
                Console.WriteLine("7 - Unesi/Izmeni Vozaca");
                Console.WriteLine("8 - Unesi/Izmeni Vise Vozaca");
                Console.WriteLine("9 - Obrisi Sve Vozace");
                Console.WriteLine("X - izlazak");


                ans = Console.ReadLine();

                switch (ans.ToUpper())
                {
                    case "1":
                        BrojVozaca();
                        break;

                    case "2":
                        ObrisiVozaca();
                        break;

                    case "3":
                        PostojanjeVozaca();
                        break;

                    case "4":
                        IspisiSveVozace();
                        break;

                    case "5":
                        IspisiVozaca();
                        break;

                    case "6":
                        IspisiSveVozaceSaID();
                        break;

                    case "7":
                        UnesiVozaca();
                        break;

                    case "8":
                        UnesiViseVozaca();
                        break;

                    case "9":
                        ObrisiSveVozace();
                        break;

                    case "X":
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (ans != null && ans.ToUpper() != "X");
        }

        private void ObrisiSveVozace()
        {
            
            _vozacService.ObrisiSveVozace();
            Console.WriteLine("Done!");
        }

        private void UnesiViseVozaca()
        {
            List<Vozac> vozaci = new List<Vozac>();

            string answer = null;

            do
            {
                Console.WriteLine("Unesi id vozaca:");
                Int32.TryParse(Console.ReadLine(), out int idv);

                Console.WriteLine("Unesi ime vozaca:");
                string ime = Console.ReadLine();

                Console.WriteLine("Unesi prezime vozaca:");
                string prezime = Console.ReadLine();

                Console.WriteLine("Unesi godinu rodjenja vozaca:");
                Int32.TryParse(Console.ReadLine(), out int godina);

                Console.WriteLine("Unesi broj titula vozaca:");
                Int32.TryParse(Console.ReadLine(), out int brojtit);

                Console.WriteLine("Unesi id drzave vozaca:");
                Int32.TryParse(Console.ReadLine(), out int drzavaid);

                Vozac v = new Vozac(idv, ime, prezime, godina, brojtit, drzavaid);


                vozaci.Add(v);

                Console.WriteLine("Da li zelite da nastavite unos? Ako ne pritisnite X, u suprotnom bilo sta sem X");
                answer = Console.ReadLine();


            } while (answer.ToUpper() != "X");



            _vozacService.UnesiIzmeniVozace(vozaci);
        }

        private void UnesiVozaca()
        {
            Console.WriteLine("Unesi id vozaca:");
            Int32.TryParse(Console.ReadLine(), out int idv);

            Console.WriteLine("Unesi ime vozaca:");
            string ime = Console.ReadLine();

            Console.WriteLine("Unesi prezime vozaca:");
            string prezime = Console.ReadLine();

            Console.WriteLine("Unesi godinu rodjenja vozaca:");
            Int32.TryParse(Console.ReadLine(), out int godina);

            Console.WriteLine("Unesi broj titula vozaca:");
            Int32.TryParse(Console.ReadLine(), out int brojtit);

            Console.WriteLine("Unesi id drzave vozaca:");
            Int32.TryParse(Console.ReadLine(), out int drzavaid);

            Vozac v = new Vozac(idv, ime, prezime, godina, brojtit, drzavaid);

            _vozacService.UnesiIzmeniVozaca(v);

        }



        private void IspisiSveVozaceSaID()
        {
            Console.WriteLine("Unosi ID jedan po jedan. Zavrsava se dodavanje pri unosu X");

            string ans = null;
            List<int> ids = new List<int>();

            do
            {
                ans = Console.ReadLine();

                Int32.TryParse(ans, out int res);

                ids.Add(res);

            } while (ans.ToUpper() != "X");

            Console.WriteLine(Vozac.GetFormattedHeader());
            foreach (Vozac v in _vozacService.IspisiSveVozaceSaID(ids))
            {
                Console.WriteLine(v);
            }
        }

        private void IspisiVozaca()
        {
            Console.WriteLine("Unesi ID vozaca:");

            Int32.TryParse(Console.ReadLine(), out int id);

            Vozac v = _vozacService.IspisiVozaca(id);

            if (v != null)
            {
                Console.WriteLine(Vozac.GetFormattedHeader());
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("Ne postoji vozac!");
            }
            
        }

        private void IspisiSveVozace()
        {

            Console.WriteLine(Vozac.GetFormattedHeader());
            foreach (Vozac v in _vozacService.IspisiSveVozace())
            {
                Console.WriteLine(v);
            }
        }

        private void PostojanjeVozaca()
        {
            Console.WriteLine("Unesi ID vozaca:");

            Int32.TryParse(Console.ReadLine(), out int id);

            if (_vozacService.ProveraPostojanjaVozaca(id))
            {
                Console.WriteLine("Postoji!");
            }
            else
            {
                Console.WriteLine("Ne postoji!");
            }
        }

        private void ObrisiVozaca()
        {
            Console.WriteLine("Unesi ID vozaca:");

            Int32.TryParse(Console.ReadLine(), out int id);

            _vozacService.ObrisiVozaca(id);
        }

        private void BrojVozaca()
        {
            Console.WriteLine($"Broj vozaca je: {_vozacService.BrojVozaca()}.");
        }
    }
}
