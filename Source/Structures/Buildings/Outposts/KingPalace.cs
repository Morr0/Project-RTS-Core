namespace rts.building.supreme {

    /// <summary>
    /// All money is held here.
    /// </summary>
    public sealed class KingPalace : Outpost {
        public long Cash {get; private set;}

        internal KingPalace(Player player) : base(player) {

        }
    }
}