using System.Text.Json;

namespace SkyGame.Data
{
    public class ShipService
    {
        static bool IsLoaded = false;
        const string path = "ships.txt";

        private List<Ship> shipList = new List<Ship>();

        public List<Ship> Ships 
        { 
            get
            {
                if (!IsLoaded)
                    ReadShips();
                return shipList;
            }
            set
            {
                shipList = value;
            }
        }

        public void ReadShips()
        {
            if(File.Exists(path))
                using(StreamReader reader = new StreamReader(path))
                {
                    var sh = JsonSerializer.Deserialize<List<Ship>>(reader.ReadToEnd());
                    if(sh != null)
                        Ships = sh;
                }
            else
                File.Create(path).Close();
        }
        public Ship GetShip(int id)
        {
            if (!IsLoaded)
            {
                ReadShips();
                IsLoaded = true;
            }
            if(id <= 0)
            {
                var ship = Ships.FirstOrDefault();
                return ship != null ? ship : new Ship();
            }
            else
                return Ships.Exists(x => x.ID == id) ? Ships.First(x=>x.ID==id) : new Ship();
        }
        public bool SaveShip(Ship ship)
        {
            if(ship==null)
                return false;

            if (Ships.Exists(x => x.ID == ship.ID))
            {
                int index = Ships.FindIndex(x=>x.ID==ship.ID);
                Ships[index] = ship;
                return SaveJson();
            }
            else
            {
                Ships.Add(ship);
                return SaveJson();
            }
        }

        public bool DeleteShip(int id)
        {
            if (Ships.Exists(x => x.ID == id))
            {
                int index = Ships.FindIndex(x => x.ID == id);
                Ships.RemoveAt(index);
                return SaveJson();
            }
            else
                return false;
        }

        public bool SaveJson()
        {
            using(StreamWriter sw = new StreamWriter(path,false))
            {
                string json = JsonSerializer.Serialize<List<Ship>>(Ships);
                sw.Write(json);
                return true;
            }
        }
    }
}