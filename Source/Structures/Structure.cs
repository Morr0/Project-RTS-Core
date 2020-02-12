namespace rts {
    public abstract class Structure {

        // PUBLIC MEMBERS
        public int Durability {get; protected set;}

        public Structure(){
        }
    }

    public enum StructureSize : byte {
        SMALL,
        BIG,
        HUGE
    }
}