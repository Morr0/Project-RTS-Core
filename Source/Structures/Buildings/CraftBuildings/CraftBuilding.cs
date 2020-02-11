using System.Collections.Generic;
using rts.item;

namespace rts.building {

    public class CraftBuilding : Building {
        public CraftType Craft {get; private set;}

        private List<ItemType> usableItems;


        public CraftBuilding(StructureSize size, CraftType craft) : base(size) {
            Craft = craft;

            // Hardcoded construction of workable materials
            usableItems = new List<ItemType>();

            if (craft == CraftType.CARPENTERY){
                usableItems.Add(ItemType.WOOD);
            }
        }

        // Progression
        public override int Setup(){
            return 1;
        }

        public override void Progress(){

        }

    }


    public enum CraftType : byte {
        CARPENTERY
    }
}