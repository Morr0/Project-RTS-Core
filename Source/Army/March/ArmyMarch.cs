namespace rts.army {
    public class ArmyMarch : March {
        private ArmyPack pack;

        public ArmyMarch(ref Player player, ref Spot origin, ref Spot destination, ref ArmyPack pack) 
        : base(ref player, ref origin, ref destination){
            this.pack = pack;
        }

        public override bool CanProgress(){
            // Leave it here as well
            if (pack.Total <= 0){
                IsDone = true;
                return false;
            }
                

            return true;
        }

        public override void Progress(){
            
        }

        // Engagement stuff
        public override bool CanEngageWith(March anotherMarch){
            return true;
        }

        public override void Engage(March anotherMarch){

        }

        public override void Disengage(){

        }

        public override bool CanMarchOn(Spot spot){
            return true;
        }
    }
}