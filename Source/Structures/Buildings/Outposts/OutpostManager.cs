using System.Collections.Generic;

namespace rts.building.supreme {
    public class OutpostManager {
        internal Player player;

        internal Outpost[] outposts;
        

        public OutpostManager(Player player){
            this.player = player;

            // Location 0 -> KingPalace
            this.outposts = new Outpost[3];
        }

        public KingPalace KingPalace(){
            if (outposts[0] == null){
                outposts[0] = new KingPalace(player);
            }

            return outposts[0] as KingPalace;
        }

        /// <summary>
        /// Must be called only after KingPalace();
        /// </summary>
        /// <returns></returns>
        public bool CanCreateOutpost() => outposts[1] != null && outposts[2] != null;

        public Outpost CreateOutpost(){
            Outpost outpost = new Outpost(player);
            if (outposts[1] == null)
                outposts[1] = outpost;
            else
                outposts[2] = outpost;

            return outpost;

        }

    }
}