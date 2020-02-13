namespace rts.army {
    /// <summary>
    /// A march is a moving army, individual or ship. This base class does not handle the units inside, it is left to the childs.
    /// </summary>
    public abstract class March
    {
        public Player Player {get; private set;}
        /// <summary>
        /// Where it started marching from. If null it does not have a return destination.
        /// </summary>
        public Spot Origin {get; internal set;}
        /// <summary>
        /// A destination. If null then it is in the wild.
        /// </summary>
        public Spot Destination {get; set;}

        /// <summary>
        /// To be used when this march is 'dead' so that the march manager can delete this march safely.
        /// </summary>
        /// <value></value>
        public bool IsDone {get; protected set;}

        public March(ref Player player, ref Spot origin, ref Spot destination){
            Player = player;
            Origin = origin;
            Destination = destination;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool CanProgress();

        /// <summary>
        /// Must be proceeded by CanProgress();.Progress toward the destination if is not null. Also handles engagement with other marches.
        /// </summary>
        public abstract void Progress();

        // The engagement system is where two marches or more or one spot with a march want to interact. The interaction
        // might be a battle, trade or something else.

        /// <summary>
        /// To be called once so the Progress() does the rest.
        /// </summary>
        /// <param name="anotherMarch"></param>
        /// <returns></returns>
        public abstract bool CanEngageWith(March anotherMarch);
        /// <summary>
        /// To be called once so the Progress() does the rest.
        /// </summary>
        /// <param name="anotherMarch"></param>
        public abstract void Engage(March anotherMarch);
        /// <summary>
        /// To be called once so the Progress() does the rest.
        /// </summary>
        public abstract void Disengage();

        /// <summary>
        /// This is useful for pathfinding.
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        public abstract bool CanMarchOn(Spot spot);
    }
}