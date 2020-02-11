namespace rts.army {
    /// <summary>
    /// Represents a commander that can control an army pack. An outpost is a commander.
    /// </summary>
    public interface ICommander {
        int MaxSoldiers(ref SoldierType type);
    }
}