namespace SkyGame.Data
{
    public class FuelTank : Module
    {
        public static new string Name = "Топливный Бак";
        public int VolumeMax { get; set; }
        private int _VolumeCurrent { get; set; }
        public int VolumeCurrent 
        {
            get { return _VolumeCurrent; } 
            set {
                _VolumeCurrent = value <= VolumeMax ? value : VolumeMax;
                Weight = WeightBase + VolumeCurrent * Statics.FuelWeight;
            } 
        }
        public int Weight { get; private set; }
    }
}
