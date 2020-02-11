namespace rts.building {
    public class SchoolBuilding : Building {
        // Currently training
        private int currentTrainingSoldiers;
        private int MaxSoldierTraining = 400;

        public SchoolBuilding() : base(StructureSize.BIG) {

        }

        // Progression
        public override int Setup(){
            return 2;
        }

        public override void Progress(){
            TrainSoldier();
        }

        private void TrainSoldier(){
            currentTrainingSoldiers--;
        }

        public bool CanTrain(ref EducationType education, ref int amount){
            switch (education){
                case EducationType.SOLDIER_TRAINING:
                    return (currentTrainingSoldiers + amount) <= MaxSoldierTraining;
                default: return false;
            }
        }

        public void Train(ref EducationType education, ref int amount){
            switch (education){
                case EducationType.SOLDIER_TRAINING:
                    currentTrainingSoldiers += amount;
                    break;
            }
        }
    }
}