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

        public void DeleteZapis(Zapis zapis)
        {
            using (var db = new SqliteContext())
            {
                db.Znamky.Remove(zapis);
                db.SaveChanges();
            }
        }

        public void UpravitZapis(Zapis zapis)
        {
            using (var db = new SqliteContext())
            {
                var list = db.Znamky.ToList();
                for (int i = 0; i < list.Count; i++) {
                    if (list[i].Id == zapis.Id) {
                        db.Znamky.Remove(list[i]);
                        db.Znamky.Add(zapis);
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
