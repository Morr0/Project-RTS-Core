namespace rts {
    public abstract class Structure {

        // PUBLIC MEMBERS
        public int Durability {get; protected set;}

        // PROTECTED MEMBERS
        protected StructureSize size;

        public Structure(ref StructureSize size){
            this.size = size;
        }

        public StructureSize GetSize() => size;
    }

    public enum StructureSize : byte {
        SMALL,
        BIG,
        HUGE
    }
}