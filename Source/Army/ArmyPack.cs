using System.Collections.Generic;
using System;

namespace rts.army {
    /// <summary>
    /// Represents an army that contains various types of soldiers
    /// </summary>
    public class ArmyPack : Pack {
        public const int HP_CONSTANT = 4;

        protected Dictionary<UnitType, int> soldierBank;

        protected Dictionary<UnitType, int> woundedSoldierBank;

        public ArmyPack(ICommander commander) : base(ref commander){
            // The best possible approach i can think of
            PopulateDictionary(ref soldierBank);
            PopulateDictionary(ref woundedSoldierBank);
        }

        private void PopulateDictionary(ref Dictionary<UnitType, int> dictionary){
            dictionary = new Dictionary<UnitType, int>();
            dictionary.Add(UnitType.LIGHT_INFANTRY, 0);
            dictionary.Add(UnitType.HEAVY_INFANTRY, 0);
            dictionary.Add(UnitType.CAVALRY, 0);
            dictionary.Add(UnitType.ARCHER, 0);
            dictionary.Add(UnitType.ARCHER_CAVALRY, 0);
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
            TotalHP = Total * HP_CONSTANT;
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
            TotalHP = Total * HP_CONSTANT;
        }

        public override void Hit(ref int damage){
            TotalHP -= damage;
            Total = TotalHP / HP_CONSTANT;

        }

    }
}