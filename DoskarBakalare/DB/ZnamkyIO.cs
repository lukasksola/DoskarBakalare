using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoskarBakalare.Znamky;

namespace DoskarBakalare.DB
{
    public class ZnamkyO
    {
        public static ZnamkyO instance;
        public static bool inicialized;

        public ZnamkyO()
        {
            if (!ZnamkyO.inicialized)
            {
                ZnamkyO.instance = this;
            }
        }

        public void AddZapis(Zapis zapis)
        {
            using (var db = new SqliteContext())
            {
                db.Znamky.Add(zapis);
                db.SaveChanges();
            }
        }
    }
    public class ZnamkyI
    {

        public List<Zapis> LoadedZnamky = new List<Zapis>();

        public void ReadDb()
        {
            using (var db = new SqliteContext())
            {
                LoadedZnamky = db.Znamky.ToList();
            }
        }
    }
}
