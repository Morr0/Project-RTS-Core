namespace rts.army {
    /// <summary>
    /// Represents a commander that can control a army. An outpost is a commander. e.g. a looter, high level soldier
    /// </summary>
    public interface ICommander {
        int MaxSoldiers(ref UnitType type);
    }
}