using rts.army;

namespace rts.building {
    public class SchoolBuilding : Building, ICommander {
        // A reference to the army pack in the outpost this school belongs to
        private ArmyPack outpostArmyPack;
        // An internal army pack for training soldiers
        private TrainingPack trainingArmyPack;

        // Training priority
        public SoldierType CurrentTrainingPriority {get; set;} = SoldierType.LIGHT_INFANTRY;

        public SchoolBuilding(ref ArmyPack outpostArmyPack) : base(StructureSize.BIG) {
            this.outpostArmyPack = outpostArmyPack;
            this.trainingArmyPack = new TrainingPack(this);
        }

        // ICommander
        public int MaxSoldiers(ref SoldierType type){
            return ArmyPack.ARMY_PACK_UNLIMATED;
        }

        // Progression
        public override int Setup(){
            return 2;
        }

        public override void Progress(){
            SoldierType type = SoldierType.LIGHT_INFANTRY;
            if (trainingArmyPack.CanGet(ref type)){
                trainingArmyPack.Get(ref type);
                // Will ignore the CanAdd() because to get here the CanAdd() 
                // should have been checked in the CanTrain method
                outpostArmyPack.Add(ref type, 1);
            }
        }

        public bool CanTrainSoldier(ref SoldierType type, int amount = 1){
            return outpostArmyPack.CanAdd(ref type, amount);
        }

        public void TrainNewSoldier(ref SoldierType type, int amount){
            // Will ignore checking for CanAdd(); since the training pack is unlimated
            // in capacity
            trainingArmyPack.Add(ref type, amount);
        }
    }
}