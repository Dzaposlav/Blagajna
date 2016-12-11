using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOblagajna.Models
{
    [Serializable]
    class Racun : EntityBase<int>
    {
        private class ArtiklKupnja
        {
            Artikl kupljeniArtil;
            int brojKomada;
            float brojKilograma;

            public ArtiklKupnja(int id, int brKom)
            {

            }

            public ArtiklKupnja(int id, float brKg)
            {

            }

        }
        DateTime DatumIzdavanja { get; set; }
        public Racun(int id, DateTime datum): base(id)
        {
            DatumIzdavanja = datum;
        }
    }
}
