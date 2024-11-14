using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerApplikation
{
    internal class Artikel
    {
        public string _ArtikelName { get; set; }

        public int _ArtikelIdIntern { get; set; }

        public string _Lieferant { get; set; }

        public int _Amount { get; set; }

        public int _SizeInMeter { get; set; }


        public int _SizeInLiter { get; set; }

        public Artikel() {
            _ArtikelName = "";
            _ArtikelIdIntern= 0;
            _Lieferant = "0";
            _SizeInMeter = 0;
            _SizeInLiter = 0;
        }


    }
}
