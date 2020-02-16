namespace rts.building {
    public abstract class TickProgressableBuilding : Building, IProgressable {
        // PUBLIC CONSTANTS
        /// <summary>
        /// WHERE a Building does not need to be updated regularly
        /// </summary>
        public static int IProgressable_NO_PROGRESS = -1;

        // IProgressable
        public abstract int Setup();
        public abstract void Progress();

        // CONSTRUCTION
        public TickProgressableBuilding(StructureSize size) : base(size){
            this.size = size;
        }
    }
}