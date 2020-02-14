namespace rts.army {

    public class ArmyMarch : March {
        public ArmyMarch(ref Player player, ref Spot origin, ref Spot destination, ref ArmyPack pack) 
        : base(ref player, ref origin, ref destination){
            this.pack = pack;

        }

        public override bool CanProgress(){
            // Leave it here as well
            if (pack.Total <= 0){
                IsDead = true;
                return false;
            }
                

            return true;
        }

        protected override void HandledProgress(){
            
        }

        // Engagement stuff
        public override bool CanEngageWith(March anotherMarch){
            return true;
        }

        public override bool CanMarchOn(Spot spot){
            return true;
        }
    }
}