using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoskarBakalare
{
    class IOznamky
    {
        public static IOznamky instance;
        public List<Zapis> ZapisyPrectene { get; set; }

        public List<Zapis> Zapisy { get; set; }
        public string path = "settings.ini";

        public void NacistZnamky()
        {
            if (!Path.Exists(path))
            {
                return;
            }

            using(StreamReader reader = new(path))
            {
                string content = reader.ReadToEnd();
                ZapisyPrectene = JsonSerializer.Deserialize<List<Zapis>>(content);
            }
        }

        public void UlozitZaznamy()
        {
            using (StreamWriter writer = new(path))
            {
                string json = JsonSerializer.Serialize<List<Zapis>>(Zapisy);
                writer.WriteLine(json);
                writer.Flush();
            }
        }

    }
}
