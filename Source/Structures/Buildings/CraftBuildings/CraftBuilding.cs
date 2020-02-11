using System.Collections.Generic;
using rts.item;

namespace rts.building {

    public class CraftBuilding : Building {
        public CraftType Craft {get; private set;}

        private List<ItemType> usableItems;

        // Craft process
        // from -> the raw item
        // to -> whatever needs to be made
        // craftingCost -> how much does it cost to craft 1 item
        private ItemType from;
        private ItemType to;
        private int craftingCost;
        private int currentRaw;
        private int currentMade;


        public CraftBuilding(StructureSize size, CraftType craft) : base(size) {
            Craft = craft;

            // Hardcoded construction of workable materials
            usableItems = new List<ItemType>();

            if (craft == CraftType.CARPENTERY){
                usableItems.Add(ItemType.WOOD);
            }
        }

        // public bool CanWorkOn(ref ItemType fromType, ref ItemType toType){
        //     if (currentRaw > 0 || currentMade > 0)
        //         return false;

        // }

        // Progression
        public override int Setup(){
            return 5;
        }

        public override void Progress(){
            CraftItem();
        }

        private void CraftItem(){

        }

    }


    public enum CraftType : byte {
        CARPENTERY
    }
}