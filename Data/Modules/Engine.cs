namespace SkyGame.Data
{
    public class Engine : Module
    {
        public static new string Name = "Двигатель";
        public int Power { get; set; }
        public int AfterBurnMax { get; set; }
        public int EngineHours { get; set; }
        public int EngineHoursMax { get; set; }
    }
}
