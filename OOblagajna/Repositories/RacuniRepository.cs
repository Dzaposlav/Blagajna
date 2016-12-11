using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOblagajna.Models;
using System.IO;

namespace OOblagajna.Repositories
{
    class RacuniRepository
    {
        private static List<Racun> _racuni = new List<Racun>();
        private static int _nextId = 1;

        public static int getNextId()
        {
            int next = _nextId;
            _nextId++;
            return next;
        }

        public static void dodajRacun(Racun noviRacun)
        {
            _racuni.Add(noviRacun);
        }


        public static Racun getRacunById(int id)
        {
            Racun racun = _racuni.Where(rac => rac.Id == id).Single();
            return racun;
        }

        public static List<Racun> getRacune()
        {
            return _racuni;
        }

        public static void dohvatiSveRacune()
        {
            using (Stream stream = File.Open("racuni.bin", FileMode.Open))
            {
                var bSerializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                _racuni = (List<Racun>)bSerializer.Deserialize(stream);

                int temp = 0;
                foreach (Racun rac in _racuni)
                {
                    if (rac.Id > temp)
                        temp = rac.Id;
                }
                _nextId = temp + 1;
            }
        }

        public static void spremiRacune()
        {
            using (Stream stream = File.Open("racuni.bin", FileMode.Create))
            {
                var bSerializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bSerializer.Serialize(stream, _racuni);
            }
        }
    }
}

