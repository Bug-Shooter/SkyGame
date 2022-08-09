namespace SkyGame.Data
{
    public class LetanTanks : Module
    {
        public static new string Name = "Летановый балон";
        public int SectionsCount { get; set; }
        private int _VolumeCurrent { get; set; }
        public int VolumeCurrent
        {
            get { return _VolumeCurrent; }
            set
            {
                _VolumeCurrent = value <= VolumeMax ? value : VolumeMax;
                LiftingForce = VolumeCurrent * Statics.LetanLiftingForce;
            }
        }
        public int VolumeMax { get; set; }
        public int LiftingForce { get; private set; }
    }
}
