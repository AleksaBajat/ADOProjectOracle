using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleksa_Bajat_PR78_2019_Projekat.UIHandler
{
    internal class MainUIHandler
    {
        private readonly VozacUIHandler _vozacUIHandler = new VozacUIHandler();
        private readonly OstaliZadaciUIHandler _ostaliZadaciUIHandler = new OstaliZadaciUIHandler();

        public void HandleMainUI()
        {
            string ans = null;

            do
            {
                Console.WriteLine("1. Upravljajte vozacima");
                Console.WriteLine("2. Ostali zadaci");
                Console.WriteLine("X - izlazak");

                
                ans = Console.ReadLine();

                switch (ans.ToUpper())
                {
                    case "1":
                        _vozacUIHandler.HandleVozacUI();
                        break;

                    case "2":
                        _ostaliZadaciUIHandler.HandleOstaliZadaciUI();
                        break;

                    case "X":
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (ans != null && ans.ToUpper() != "X");

        }
    }
}
