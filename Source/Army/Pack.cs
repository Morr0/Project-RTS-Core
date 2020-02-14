namespace rts.army {
    public abstract class Pack {
        public static int ARMY_PACK_UNLIMATED = -1;

        public bool Engageable {get; protected set;} = true;

        public ICommander Commander {get; private set;}
        // Represents the total of all the soldiers in this pack
        public int Total {get; protected set;}

        public int TotalHP {get; protected set;}

        public Pack(ref ICommander commander){
            Commander = commander;
        }

        public abstract void Hit(DamageInfo damage);

        
    }
}