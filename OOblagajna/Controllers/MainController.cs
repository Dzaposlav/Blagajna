using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOblagajna.Models;
using OOblagajna.Repositories;

namespace OOblagajna.Controllers
{
    class MainController
    {
        private void consolePrintCenter(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
        private void consolePrintCenterLeft(string text)
        {
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2)) + "}", text));
        }

        private void printList(List<string> lista)
        {
            int temp = 0;
            int prevTextOffs = 0;
            foreach(string text in lista)
            {
                int offset = Console.WindowWidth / 4 + temp * (Console.WindowWidth / 4);
                Console.Write(String.Format("{0," + (offset + (text.Length / 2) - prevTextOffs) + "}", text));
                prevTextOffs = text.Length / 2;
                if (temp == 1)
                {
                    Console.WriteLine("");
                    prevTextOffs = 0;
                }
                temp = (temp + 1) % 2;
            }
            Console.WriteLine("");
        }

        public void start()
        {
            consolePrintCenter("BLAGAJNA");
            consolePrintCenter("OBJEKTNO OBLIKOVANJE");
            opcije();

            /*
            int count = 0;
            while (count < 5)
            {
                string name = Console.ReadLine();
                float cijena = float.Parse(Console.ReadLine());
                int pdv = int.Parse(Console.ReadLine());
                string mjera = Console.ReadLine();
                mjernaJed mjr;
                if (mjera == "0") mjr = mjernaJed.poKomadu;
                else mjr = mjernaJed.poKilogramu;
                dodajArtikl(name, cijena, pdv, mjr);
                count++;

            }
            */

        }


        public void ispisArtikli()
        {
            consolePrintCenter("SVI ARTIKLI");
            List<string> ispis = new List<string>();
            foreach(Artikl artikl in ArtiklRepository.getArtikle())
            {
                ispis.Add(artikl.Id + " - " + artikl.naziv + "(pdv "+ artikl.stopaPDV + "%)");
            }
            printList(ispis);
            opcije();
        }

        public void opcije()
        {
            List<string> glavneOpcije = new List<string>();
            glavneOpcije.Add("1 - ispis artikala");
            glavneOpcije.Add("2 - unos novog artikla");
            glavneOpcije.Add("3 - kreiranje računa");
            glavneOpcije.Add("4 - promjena/brisanje računa");
            glavneOpcije.Add("5 - dnevno izvješče");
            glavneOpcije.Add("6 - izvješće artikala");
            printList(glavneOpcije);
        }
        public void dodajArtikl()
        {
            consolePrintCenterLeft("upisite naziv artikla:");
            string name = Console.ReadLine();
            consolePrintCenterLeft("upisite cijenu artikla:");
            float cijena = float.Parse(Console.ReadLine());
            consolePrintCenterLeft("upisite postotak PDV-a:");
            int pdv = int.Parse(Console.ReadLine());
            consolePrintCenterLeft("upisite prodajnu jedinicu(1 - komad, 2 - kilogram):");
            string mjera = Console.ReadLine();
            mjernaJed mjr;
            if (mjera == "1") mjr = mjernaJed.poKomadu;
            else mjr = mjernaJed.poKilogramu;

            int id = ArtiklRepository.getNextId();
            Artikl noviArtikl = new Artikl(id, name, cijena, pdv, mjr);
            ArtiklRepository.dodajArtikl(noviArtikl);
            opcije();
        }
    }
}
