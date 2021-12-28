using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.DTA;
using Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4;
using Aleksa_Bajat_PR78_2019_Projekat.Models;
using Aleksa_Bajat_PR78_2019_Projekat.Service;

namespace Aleksa_Bajat_PR78_2019_Projekat.UIHandler
{
    internal class OstaliZadaciUIHandler
    {
        private static readonly RezultatService _rezultatService = new RezultatService();

        public void HandleOstaliZadaciUI()
        {
            string ans = null;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Kontrolna Tacka 3");
                Console.WriteLine("2. Kontrolna Tacka 4");
                Console.WriteLine("3. Kontrolna Tacka 5");
                Console.WriteLine("4. Ispis Svih Rezultata");
                Console.WriteLine("X - Izlazak");


                ans = Console.ReadLine();

                switch (ans.ToUpper())
                {
                    case "1":
                        KontrolnaTacka3();
                        break;

                    case "2":
                        KontrolnaTacka4();
                        break;

                    case "3":
                        KontrolnaTacka5();
                        break;

                    case "4":
                        IspisiSveRezultate();
                        break;

                    case "X":
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (ans != null && ans.ToUpper() != "X");
        }

        private void IspisiSveRezultate()
        {
            Console.WriteLine(Rezultat.GetFormattedHeader());
            foreach (Rezultat rez in _rezultatService.IspisSvihRezultata())
            {
                Console.WriteLine(rez);
            }
        }

        private void KontrolnaTacka5()
        {
            Console.WriteLine("Unesi ID vozaca:");
            Int32.TryParse(Console.ReadLine(), out int idv);

            Console.WriteLine("Unesi ID rezultata:");
            string idr = Console.ReadLine();

            _rezultatService.BrisanjeRezultata(idv, idr);
        }

        private void KontrolnaTacka4()
        {
            DTATacka4 dtaTacka4 = _rezultatService.IzvestajIRezultati();


            int i = 0;

            foreach (VozacOsnovneInformacijeDTA info in dtaTacka4.OsnovneInformacije)
            {
                Console.WriteLine("###############################################");
                
                Console.WriteLine(VozacOsnovneInformacijeDTA.GetFormattedHeader());
                Console.WriteLine(info);

                if (dtaTacka4.RezultatiPrvaMesta[i].Count == 0)
                {
                    Console.WriteLine("Nije bio prvoplasirani!");
                }
                else
                {
                    Console.WriteLine(Rezultat.GetFormattedHeader());
                }


                int j = 0;
                for (j = 0; j < dtaTacka4.RezultatiPrvaMesta[i].Count; j++)
                {
                    Console.WriteLine(dtaTacka4.RezultatiPrvaMesta[i][j]);
                }

                Console.WriteLine($"\nVozac u trkama nije bio prvoplasiran {dtaTacka4.BrojTrkaNijePrvi[j]} puta");

                Console.WriteLine("###############################################\n\n");

                i++;

            }
        }

        private void KontrolnaTacka3()
        {
            Console.WriteLine("Unesite ID staze: ");
            Int32.TryParse(Console.ReadLine(), out int id);


            DTATacka3 dtaTacka3 = _rezultatService.RezultatiPrekoIDProsekBodova(id);

            Console.WriteLine(Rezultat.GetFormattedHeader());

            foreach (Rezultat rez in dtaTacka3.Rezultati)
            {
                Console.WriteLine(rez);
            }

            Console.WriteLine($"Prosek bodova na ovoj stazi je : {dtaTacka3.Average}");
        }
    }
}
