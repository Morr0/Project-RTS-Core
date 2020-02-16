namespace rts.building {
    public abstract class Building : Structure {
        // CONSTRUCTION
        public Building(StructureSize size) : base(ref size){
        }
    }
}