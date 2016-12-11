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

        private void printList(List<string> lista)
        {
            int temp = 0;
            foreach(string text in lista)
            {
                int offset = Console.WindowWidth / 4 + temp * (sConsole.WindowWidth / 2);
            }
        }

        public void start()
        {
            consolePrintCenter("BLAGAJNA");
            consolePrintCenter("OBJEKTNO OBLIKOVANJE");
            Console.ReadKey();

        }

        public void opcije()
        {

        }
        public void dodajArtikl(string name, float cijena, int pdv, mjernaJed mjera)
        {
            int id = ArtiklRepository.getNextId();
            Artikl noviArtikl = new Artikl(id, name, cijena, pdv, mjera);
            ArtiklRepository.dodajArtikl(noviArtikl);
        }
    }
}
