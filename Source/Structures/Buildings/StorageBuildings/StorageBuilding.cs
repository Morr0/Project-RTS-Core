using rts.item;

namespace rts.building {
    /// <summary>
    /// A general storage building. Can hold any items including water.
    /// </summary>
    public class StorageBuilding : Building {
        /// <summary>
        /// for liquids, it is in terms of L 
        /// for solids, it is in terms of pieces
        /// </summary>
        public static int MINIMUM_CAPACITY = 2000;

        // Properties
        public ItemType currentItem {get; private set;} = ItemType.NONE;
        public int CurrentCapacity {get; private set;}
        public int MaxCapacity {get; private set;}

        public StorageBuilding(StructureSize size) : base(size) {
            MaxCapacity = ((byte) size) * MINIMUM_CAPACITY;
        }

        public bool CanPut(ref ItemType type, ref int amount){
            if (currentItem == ItemType.NONE)
                return true;

            // If different item
            if (currentItem != type)
                return false;

            // Computing if there exists enough amount
            int _currentCapacity = CurrentCapacity;
            _currentCapacity += amount;
            return _currentCapacity <= MaxCapacity;
        }

        /// <summary>
        /// MUST BE PROCEEDED BY CanPut();
        /// </summary>
        /// <param name="amount"></param>
        public void Put(ref int amount){
            CurrentCapacity += amount;
        }

        public bool CanConsume(ref int amount){
            int _currentCapacity = CurrentCapacity;
            _currentCapacity -= amount;
            return _currentCapacity >= 0;
        }

        /// <summary>
        /// MUST BE PROCEEDED BY CanConsume();
        /// </summary>
        /// <param name="amount"></param>
        public void Consume(ref int amount){
            CurrentCapacity -= amount;
        }

        public bool CanChangeItem(){
            return !(CurrentCapacity > 0);
        }

        public void ChangeItem(ref ItemType newItem){
            currentItem = newItem;
        }

    }
}