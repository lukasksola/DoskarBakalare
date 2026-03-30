using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoskarBakalare.Znamky
{
    public class Zapis
    {
        public int Id { get; set; }
        public int Hodnota { get; set; }
        public int Vaha { get; set; }
        public string Popis { get; set; }
        public DateTime Date { get; set; }

        public int IdCloveka { get; set; }
    }
}
