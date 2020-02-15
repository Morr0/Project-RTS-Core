namespace rts.army {
    internal class BattleEngagement : Engagement {
        // host -> the initial army
        // guest -> the engager
        private readonly ArmyPack hostPack, guestPack;

        // For the turn based nature. True if it is the host's turn now.
        private bool hostTurn;

        private int damage = 0;

        public BattleEngagement(ArmyPack hostPack, ArmyPack guestPack){
            this.hostPack = hostPack;
            this.guestPack = guestPack;
        }


        public override void Action(){
            if (hostTurn){
                damage = (100 * guestPack.Total) / (3);
                hostPack.Hit(ref damage);
            } else {
                damage = (100 * hostPack.Total) / (3);
                guestPack.Hit(ref damage);
            }

            hostTurn = !hostTurn;
        }
    }
}