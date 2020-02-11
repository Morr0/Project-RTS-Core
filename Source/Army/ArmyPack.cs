namespace rts.army {
    /// <summary>
    /// Represents an army that contains various types of soldiers
    /// </summary>
    public class ArmyPack {
        public static int ARMY_PACK_UNLIMATED = -1;

        public ICommander Commander {get; private set;}

        public int LightInfantry {get; private set;}
        public int HeavyInfantry {get; private set;}
        public int Cavalry {get; private set;}
        public int Archers {get; private set;}
        public int ArcherCavalry {get; private set;}

        public ArmyPack(ICommander commander){
            Commander = commander;
        }

        public bool CanAdd(ref SoldierType type, ref int amount){
            int maxOfType = Commander.MaxSoldiers(ref type);

            if (maxOfType == ARMY_PACK_UNLIMATED)
                return true;

            if ((LightInfantry + amount) <= maxOfType)
                return true;
            else if ((HeavyInfantry + amount) <= maxOfType)
                return true;
            else if ((Cavalry + amount) <= maxOfType)
                return true;
            else if ((Archers + amount) <= maxOfType)
                return true;
            else if ((ArcherCavalry + amount) <= maxOfType)
                return true;

            return false;
        }

        public void Add(ref SoldierType type, ref int amount){
            if (type == SoldierType.LIGHT_INFANTRY)
                LightInfantry += amount;
            else if (type == SoldierType.HEAVY_INFANTRY)
                HeavyInfantry += amount;
            else if (type == SoldierType.CAVALRY)
                Cavalry += amount;
            else if (type == SoldierType.ARCHER)
                Archers += amount;
            else if (type == SoldierType.ARCHER_CAVALRY)
                ArcherCavalry += amount;
        }

    }
}