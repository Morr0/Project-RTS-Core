namespace rts.util {
    using rts.building;
    using System.Collections.Generic;

    internal class TickTimer {
        /// <summary>
        /// How many ticks left to call
        /// </summary>
        /// <value></value>
        public int TicksToCall {get; private set;}
        /// <summary>
        /// Total number of ticks to call
        /// </summary>
        /// <value></value>
        public int TotalTicksToCall {get; private set;}

        private List<IProgressable> progressables;

        public TickTimer(int totalTicksToCall){
            TotalTicksToCall = totalTicksToCall;
            TicksToCall = totalTicksToCall;

            progressables = new List<IProgressable>();
        }

        public void Update(){
            TicksToCall--;

            // Call when it is the time
            if (TicksToCall <= 0){
                TicksToCall = TotalTicksToCall;

                foreach (IProgressable progressable in progressables){
                    progressable.Progress();
                }
            }
        }

        public void Add(ref IProgressable progressable){
            progressables.Add(progressable);
        }

        public void Remove(ref IProgressable progressable){
            progressables.Remove(progressable);
        }
    }
}