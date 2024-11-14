using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerApplikation
{
    internal class Lager
    {
        public string _LagerName { get; set; }

        public List<Artikel> _ArtikelStock { get; set; }

        public Lager() { 
            _LagerName = " ";
            _ArtikelStock= new List<Artikel>();
        }

    }
}
