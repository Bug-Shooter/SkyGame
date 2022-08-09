namespace SkyGame.Data
{
    public class Storage : Module
    {
        public static new string Name = "Склад";

        public int Volume { get; set; }
        public int Weight { get; private set; }
        private int _CargoWeightCurrent { get; set; }
        public int CargoWeightCurrent
        {
            get 
            { 
                return _CargoWeightCurrent; 
            }
            set
            {
                _CargoWeightCurrent = value <= CargoWaightMax ? value : CargoWaightMax;
                Weight = WeightBase + _CargoWeightCurrent;
            }
        }
        public int CargoWaightMax { get; set; }

    }
}
