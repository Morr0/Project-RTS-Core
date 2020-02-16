namespace rts {
    using rts.util;
    using rts.building;
    using System.Collections.Generic;

    /// <summary>
    /// It is the interface of client/server that uses Player, e.g. Called by UI or server.
    /// Unlike Player, THIS NOT BE CALLED BY INTERNAL API BUT CALLS INTERNAL API.
    /// </summary>
    public sealed class PlayerManager {
        public Player Player {get; private set;}

        private List<TickTimer> timers;

        public PlayerManager (Player player){
            Player = player;

            timers = new List<TickTimer>();
        }

        public void TickUpdate(){
            foreach (TickTimer timer in timers){
                timer.Update();
            }
        }

        public void AddProgressable(IProgressable progressable){
            TickTimer timer = null;
            int timeRequired = progressable.Setup();

            // Looks for an existing timer
            foreach(TickTimer t in timers){
                if (t.TotalTicksToCall == timeRequired){
                    timer = t;
                    timer.Add(ref progressable);
                    break;
                }
            }

            // Makes a new timer 
            if (timer == null){
                timer = new TickTimer(timeRequired);
                timer.Add(ref progressable);
                timers.Add(timer);
            }
        }

        public void RemoveProgressable(IProgressable progressable){
            int timeRequired = progressable.Setup();
            foreach (TickTimer timer in timers){
                if (timer.TotalTicksToCall == timeRequired){
                    timer.Remove(ref progressable);
                    break;
                }
            }
        }


    }
}