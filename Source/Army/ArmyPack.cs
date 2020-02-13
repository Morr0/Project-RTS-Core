using System.Collections.Generic;

namespace rts.army {
    /// <summary>
    /// Represents an army that contains various types of soldiers
    /// </summary>
    public class ArmyPack : Pack {
        protected Dictionary<UnitType, int> soldierBank;

        public ArmyPack(ICommander commander) : base(ref commander){
            // The best possible approach i can think of
            soldierBank = new Dictionary<UnitType, int>();
            soldierBank.Add(UnitType.LIGHT_INFANTRY, 0);
            soldierBank.Add(UnitType.HEAVY_INFANTRY, 0);
            soldierBank.Add(UnitType.CAVALRY, 0);
            soldierBank.Add(UnitType.ARCHER, 0);
            soldierBank.Add(UnitType.ARCHER_CAVALRY, 0);
        }

        public bool CanAdd(ref UnitType type, int amount){
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
        public void Add(ref UnitType type, int amount){
            soldierBank[type] = soldierBank[type] + amount;
            Total += amount;
        }

        public bool CanGet(ref UnitType type, int amount = 1) {
            return ((soldierBank[type]) - amount) > 0; 
        }

        /// <summary>
        /// Must be proceeded by CanGet();. Remove the 'amount' from the ArmyPack
        /// </summary>
        /// <param name="amount"></param>
        public void Get(ref UnitType type, int amount = 1){
            soldierBank[type] = soldierBank[type] - amount;
            Total -= amount;
        }

    }
}