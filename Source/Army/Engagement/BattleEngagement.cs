namespace rts.army {
    internal class BattleEngagement : Engagement {
        // host -> the initial army
        // guest -> the engager
        private readonly ArmyPack hostPack, guestPack;

        // For the turn based nature. True if it is the host's turn now.
        private bool hostTurn;

        public BattleEngagement(ArmyPack hostPack, ArmyPack guestPack){
            this.hostPack = hostPack;
            this.guestPack = guestPack;
        }


        public override void Action(){
            if (hostTurn){
                hostPack.Hit(new DamageInfo());
            } else {
                guestPack.Hit(new DamageInfo());
            }

            hostTurn = !hostTurn;
        }
    }
}