namespace rts {
    /// <summary>
    /// A spot holds a structure. It sits on ground/water and is independent of position
    /// </summary>
    public class Spot {
        public Structure structure {get; set;}
        public Owner Ownerr {get; internal set;}
    }
}