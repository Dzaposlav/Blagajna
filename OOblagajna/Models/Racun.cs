using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOblagajna.Repositories;

namespace OOblagajna.Models
{
    [Serializable]
    class Racun : EntityBase<int>
    {
        private class ArtiklKupnja
        {
            public Artikl kupljeniArtil;
            public int brojKomada;
            public float brojKilograma;

            public ArtiklKupnja(int id, int brKom)
            {
                kupljeniArtil = ArtiklRepository.getArtiklById(id);
                brojKomada = brKom;
                brojKilograma = 0;
            }

            public ArtiklKupnja(int id, float brKg)
            {
                kupljeniArtil = ArtiklRepository.getArtiklById(id);
                brojKomada = 0;
                brojKilograma = brKg;
            }

        }
        DateTime DatumIzdavanja { get; set; }
        List<ArtiklKupnja> kupljeniArtikli;
        public float ukupanIznos;
        public float ukupniPDV;
        public Racun(int id, DateTime datum): base(id)
        {
            DatumIzdavanja = datum;
            kupljeniArtikli = new List<ArtiklKupnja>();
            ukupanIznos = 0;
            ukupniPDV = 0;
        }

        public void addArtikl(int id, int brKom)
        {
            ArtiklKupnja novaKupnja = new ArtiklKupnja(id, brKom);
            kupljeniArtikli.Add(novaKupnja);
            ukupanIznos = ukupanIznos + brKom * novaKupnja.kupljeniArtil.cijena;
            ukupniPDV = ukupniPDV + brKom * novaKupnja.kupljeniArtil.cijena * ((float)novaKupnja.kupljeniArtil.stopaPDV / 100);
        }

        public void addArtikl(int id, float brKg)
        {
            ArtiklKupnja novaKupnja = new ArtiklKupnja(id, brKg);
            kupljeniArtikli.Add(novaKupnja);
            ukupanIznos = ukupanIznos + brKg * novaKupnja.kupljeniArtil.cijena;
            ukupniPDV = ukupniPDV + brKg * novaKupnja.kupljeniArtil.cijena * ((float)novaKupnja.kupljeniArtil.stopaPDV / 100);
        }

        public List<string> getStavkeList()
        {
            List<string> ispis = new List<string>();
            string kolicina;
            foreach(ArtiklKupnja stavka in kupljeniArtikli)
            {
                Artikl artikl = stavka.kupljeniArtil;
                if (artikl.jedinicaMjere == mjernaJed.poKomadu) kolicina = "" + stavka.brojKomada;
                else kolicina = "" + stavka.brojKilograma;
                ispis.Add(String.Format("{0} - {1} ------- {2} -------{3}", artikl.Id, artikl.naziv, kolicina, artikl.cijena));
            }
            return ispis;
        }
    }
}
