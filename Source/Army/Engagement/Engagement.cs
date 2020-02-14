namespace rts.army {
    /// <summary>
    /// Manages the engagements of TWO marches ONLY. 
    /// Each new engagement must be in it's own class. 
    /// The child class handles the details. 
    /// Only one of the engagers should have a reference on that as it is a middle man.
    /// The host is typically the one which was already there and got interacted with.
    /// </summary>
    public abstract class Engagement {
        

        /// <summary>
        /// Must be called by Progress();
        /// </summary>
        public abstract void Action();
    } 
}