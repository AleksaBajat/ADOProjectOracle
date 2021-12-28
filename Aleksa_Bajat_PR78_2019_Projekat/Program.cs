using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.Models;
using Aleksa_Bajat_PR78_2019_Projekat.UIHandler;

namespace Aleksa_Bajat_PR78_2019_Projekat
{
    internal class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();
        static void Main(string[] args)
        {
            mainUIHandler.HandleMainUI();
        }
    }
}
