namespace SkyGame.Data
{
    public abstract class Module
    {
        public static string Name { get; set; } = "";
        public int HP { get; set; }
        public int CurrentHP { get; set; }
        public int WeightBase { get; set; }
        public int DR { get; set; }
        public int Cooling { get; set; }
        public int Energy { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
}
