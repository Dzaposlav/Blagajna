using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOblagajna.Models;
using System.IO;

namespace OOblagajna.Repositories
{
    public static class ArtiklRepository
    {
        private static List<Artikl> _artikli = new List<Artikl>();
        private static int _nextId = 1;

        public static int getNextId()
        {
            int next = _nextId;
            _nextId++;
            return next;
        }

        public static void dodajArtikl(Artikl noviArtikl)
        {
            if(_artikli.Any(art => art.naziv == noviArtikl.naziv))
            {
                // exception
            }
            _artikli.Add(noviArtikl);
            spremiArtikle();
        }


        public static void dohvatiSveArtikle()
        {
            using (Stream stream = File.Open("artikli.bin", FileMode.Open))
            {
                var bSerializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                _artikli = (List<Artikl>)bSerializer.Deserialize(stream);

                int temp = 0;
                foreach(Artikl art in _artikli)
                {
                    if (art.Id > temp)
                        temp = art.Id;
                }
                _nextId = temp + 1;
            }
        }

        public static void spremiArtikle()
        {
            using (Stream stream = File.Open("artikli.bin", FileMode.Create))
            {
                var bSerializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bSerializer.Serialize(stream, _artikli);
            }
        }
    }
}
