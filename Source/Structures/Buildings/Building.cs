namespace rts.building {
    public abstract class Building : Structure, IProgressable {
        // PUBLIC CONSTANTS
        /// <summary>
        /// WHERE a Building does not need to be updated regularly
        /// </summary>
        public static int IProgressable_NO_PROGRESS = -1;

        // IProgressable
        public abstract int Setup();
        public abstract void Progress();

        // CONSTRUCTION
        public Building(StructureSize size){
            this.size = size;
        }

        // PROTECTED MEMBERS
        protected StructureSize size;

        // PUBLIC MEMBERS
        public int Durability {get; protected set;}

        public StructureSize GetSize() => size;

    }
}