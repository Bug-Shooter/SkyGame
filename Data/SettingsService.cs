using System.Text.Json;

namespace SkyGame.Data
{
    public class SettingsService
    {
        const string path = "settings.txt";
        public void Save()
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                string json = JsonSerializer.Serialize<StaticsServ>(new StaticsServ { FuelWeight= Statics.FuelWeight, CoolerWeight = Statics.CoolerWeight, LetanLiftingForce = Statics.LetanLiftingForce});
                sw.Write(json);
            }
        }
        public void Load()
        {
            if (File.Exists(path))
                using (StreamReader reader = new StreamReader(path))
                {
                    var sh = JsonSerializer.Deserialize<StaticsServ>(reader.ReadToEnd());
                    if (sh != null)
                    {
                        Statics.CoolerWeight = sh.CoolerWeight;
                        Statics.LetanLiftingForce = sh.LetanLiftingForce;
                        Statics.FuelWeight = sh.FuelWeight;
                    }
                }
            else
                File.Create(path).Close();
        }
    }
}