using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoskarBakalare.Znamky;

namespace DoskarBakalare.DB
{
    public class ZnamkyI
    {

        public List<Zapis> LoadedZnamky = new List<Zapis>();
        public List<Zapis> Znamky = new List<Zapis>();


        public void ReadDb()
        {
            using (var db = new SqliteContext())
            {
                LoadedZnamky = db.Znamky.ToList();
            }
        }

        public void FilterById(int id)
        {
            List<Zapis> filtrace = new List<Zapis>();

            foreach(Zapis znamka in LoadedZnamky)
            {
                if(znamka.IdCloveka == id)
                {
                    filtrace.Add(znamka);
                }
            }

            LoadedZnamky = filtrace;
        }
    }
}
