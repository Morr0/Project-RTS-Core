using System.Collections.Generic;

namespace rts.army {
    /// <summary>
    /// Represents an army that contains various types of soldiers
    /// </summary>
    public class ArmyPack {
        public static int ARMY_PACK_UNLIMATED = -1;

        public ICommander Commander {get; private set;}

        protected Dictionary<SoldierType, int> soldierBank;
        // Represents the total of all the soldiers in this pack
        protected int totalInPack;

        public ArmyPack(ICommander commander){
            Commander = commander;

            // The best possible approach i can think of
            soldierBank = new Dictionary<SoldierType, int>();
            soldierBank.Add(SoldierType.LIGHT_INFANTRY, 0);
            soldierBank.Add(SoldierType.HEAVY_INFANTRY, 0);
            soldierBank.Add(SoldierType.CAVALRY, 0);
            soldierBank.Add(SoldierType.ARCHER, 0);
            soldierBank.Add(SoldierType.ARCHER_CAVALRY, 0);
        }

        public bool CanAdd(ref SoldierType type, int amount){
            int maxOfType = Commander.MaxSoldiers(ref type);

            if (maxOfType == ARMY_PACK_UNLIMATED)
                return true;

            return ((soldierBank[type]) + amount) <= maxOfType;
        }

        /// <summary>
        /// Must be proceeded by CanAdd();
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        public void Add(ref SoldierType type, int amount){
            soldierBank[type] = soldierBank[type] + amount;
            totalInPack += amount;
        }

        public bool CanGet(ref SoldierType type, int amount = 1) {
            return ((soldierBank[type]) - amount) > 0; 
        }

        /// <summary>
        /// Must be proceeded by CanGet();. Remove the 'amount' from the ArmyPack
        /// </summary>
        /// <param name="amount"></param>
        public void Get(ref SoldierType type, int amount = 1){
            soldierBank[type] = soldierBank[type] - amount;
            totalInPack -= amount;
        }

    }
}