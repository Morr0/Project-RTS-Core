using System.Collections.Generic;
using rts.army;

namespace rts.building {
    /// <summary>
    /// An outpost controls an area related to a Player. Each outpost must exist first 
    /// in order for a school to form in its territory.
    /// </summary>
    public class Outpost : Building, ICommander {
        protected Player player;

        // Properties
        protected ArmyPack armyInside;

        // INTERNALS
        private List<Structure> structures;

        private SchoolBuilding school;

        internal Outpost(Player player) : base(StructureSize.BIG) {
            this.player = player;

            structures = new List<Structure>();

            // 

            armyInside = new ArmyPack(this);
        }

        public int MaxSoldiers(ref UnitType type) => ArmyPack.ARMY_PACK_UNLIMATED;

        // Progression
        public override int Setup(){
            return Building.IProgressable_NO_PROGRESS;
        }

        public override void Progress(){
        }

        public bool CanAddToTerritory(ref Structure structure){
            return true;
        }

        public void AddToTerritory(ref Structure structure){
            if (structure is SchoolBuilding)
                school = structure as SchoolBuilding;

            this.structures.Add(structure);
        }
    }
}