namespace rts.building.farm {
    using rts.item;
    public class Farmland : TickProgressableBuilding {

        public int TicksToNextHarvest {get; private set;}
        public int TotalTicksToHarvest {get; private set;}

        public ItemType CurrentPlant {get; private set;}

        public Farmland() : base(StructureSize.SMALL){

        }

        // Progression
        public override int Setup(){
            return 10;
        }

        public override void Progress(){
            if (TicksToNextHarvest > 0)
                TicksToNextHarvest--;
        }

        public bool CanSetPlant(ref ItemType item){
            if (TicksToNextHarvest <= 0)
                return true;

            return false;
        }

        public void SetPlant(ref ItemType item){
            CurrentPlant = item;

            TicksToNextHarvest = TotalTicksToHarvest
             = TicksToCompleteRegistery.GetTicksToHarvest(ref item);
        }
    }
}