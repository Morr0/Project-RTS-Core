namespace rts.building {
    // To be used with buildings
    // For a building to be updated by a server every n server ticks
    public interface IProgressable
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns>Every n server ticks to call Progress()</returns>
        int Setup();
        void Progress();
    }
}