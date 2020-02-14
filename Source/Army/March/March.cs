namespace rts.army {
    using System.Collections.Generic;

    /// <summary>
    /// A march is a moving army, individual or ship. 
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
        public bool IsDead {get; protected set;}

        internal Pack pack;

        protected List<Engagement> engagements;

        public March(ref Player player, ref Spot origin, ref Spot destination){
            Player = player;
            Origin = origin;
            Destination = destination;

            engagements = new List<Engagement>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool CanProgress();

        public void Progress(){
            foreach (Engagement engagement in engagements){
                engagement.Action();
            }

            HandledProgress();
        }

        /// <summary>
        /// Must be proceeded by CanProgress();.Progress toward the destination if is not null. Also handles engagement with other marches.
        /// </summary>
        protected abstract void HandledProgress();

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
        public Engagement Engage(March guestMarch){
            Engagement engagement = null;

            if (guestMarch is ArmyMarch){
                engagement = new BattleEngagement(pack as ArmyPack, guestMarch.pack as ArmyPack);
            }

            engagements.Add(engagement);
            return engagement;
        }
        /// <summary>
        /// To be called once so the Progress() does the rest.
        /// </summary>
        public void Disengage(Engagement engagement){
            engagements.Remove(engagement);
        }

        /// <summary>
        /// This is useful for pathfinding.
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        public abstract bool CanMarchOn(Spot spot);
    }
}