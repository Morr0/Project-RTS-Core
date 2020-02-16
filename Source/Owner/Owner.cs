namespace rts {

    using System;
    using System.Collections.Generic;
    using rts.building;

    public abstract class Owner {
        /// <summary>
        /// False -> is player
        /// True -> is a clan
        /// </summary>
        /// <value></value>
        public bool IsClan {get; protected set;} = false;

        internal List<Spot> occupiedSpots;

        public Owner(){
            occupiedSpots = new List<Spot>();
        }

    }
}