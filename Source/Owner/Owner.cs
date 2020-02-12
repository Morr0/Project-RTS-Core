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

        // To be initialised by 
        protected Array outposts;

    }
}