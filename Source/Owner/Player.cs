namespace rts {
    // Defines a player that is AI/real
    public class Player : Owner {

        public bool AIControllable {get; private set;}

        public Player(bool ai){
            this.AIControllable = ai;
        }
        
    }
}