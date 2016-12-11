using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOblagajna.Models
{
    [Serializable]
    public class Artikl : EntityBase<int>
    {
        public string naziv { get; set; }
        public float cijena { get; set; }

        public int stopaPDV { get; set; }
        public mjernaJed jedinicaMjere { get; set; }

        public Artikl(int id, string name, float price, int pdv, mjernaJed mjer) : base(id)
        {    
            naziv = name;
            cijena = price;
            stopaPDV = pdv;
            jedinicaMjere = mjer;
        }

    }
}
