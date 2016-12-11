using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOblagajna.Controllers;
using OOblagajna.Repositories;

namespace OOblagajna
{
    public enum mjernaJed
    {
        poKomadu, poKilogramu

    };
    class Program
    {
        static void Main(string[] args)
        {
            MainController control = new MainController();
            ArtiklRepository.dohvatiSveArtikle();
            RacuniRepository.dohvatiSveRacune();
            control.start();
            string input;
            while (true)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        control.ispisArtikli();
                        break;
                    case "2":
                        control.dodajArtikl();
                        break;
                    case "3":
                        control.dodajRacun();
                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;

                }

            }
        }


    }




}
