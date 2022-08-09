namespace SkyGame.Data
{
    public class Ship
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Корабль";
        public int HP { get; set; }
        public int CurrentHP { get; set; }

        public int CruisingSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public int DR { get; set; }
        public string Matherial { get; set; } = "";

        public int SheathingLiftingForce { get; set; }
        public int ShellWaight { get; set; }

        public int GetTotalLiftingForce() =>
            (SheathingLiftingForce + LetanTanks.LiftingForce) / GetTotalWaight();
        public int GetTotalWaight() =>
            ShellWaight + Bridge.WeightBase + Communication.WeightBase +
            CoolerTank.Weight + Engine.WeightBase + Engineer.WeightBase +
            FuelTank.Weight + LetanTanks.WeightBase + Storage.Weight;
        public int GetTotalModules()
        {
            int total = 0;
            if (Bridge.HP != 0)
                total++;
            if (Communication.HP != 0)
                total++;
            if (CoolerTank.HP != 0)
                total++;
            if (Engine.HP != 0)
                total++;
            if (Engineer.HP != 0)
                total++;
            if (FuelTank.HP != 0)
                total++;
            if (LetanTanks.HP != 0)
                total++;
            if (Storage.HP != 0)
                total++;
            return total;
        }
        public int GetTotalModulesDamage() => 
            GetTotalModules() == 0 ? 0 : //Check to not divide zero
            (Bridge.HP != 0 ? Bridge.CurrentHP / Bridge.HP : 0 +
            Communication.HP != 0 ? Communication.CurrentHP / Communication.HP : 0 +
            CoolerTank.HP != 0 ? CoolerTank.CurrentHP / CoolerTank.HP : 0 +
            Engine.HP != 0 ? Engine.CurrentHP / Engine.HP : 0 +
            Engineer.HP != 0 ? Engineer.CurrentHP / Engineer.HP : 0 +
            FuelTank.HP != 0 ? FuelTank.CurrentHP / FuelTank.HP : 0 +
            LetanTanks.HP != 0 ? LetanTanks.CurrentHP / LetanTanks.HP : 0 +
            Storage.HP != 0 ? Storage.CurrentHP / Storage.HP : 0) / GetTotalModules();
        


        //Modules
        public Bridge Bridge { get; init; } = new Bridge();
        public Communication Communication { get; init; } = new Communication();
        public CoolerTank CoolerTank { get; init; } = new CoolerTank();
        public Engine Engine { get; init; } = new Engine();
        public Engineer Engineer { get; init; } = new Engineer();
        public FuelTank FuelTank { get; init; } = new FuelTank();
        public LetanTanks LetanTanks { get; init; } = new LetanTanks();
        public Storage Storage { get; init; } = new Storage();
    }
}
