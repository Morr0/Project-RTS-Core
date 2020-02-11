using rts.item;

namespace rts.building {
    public class StorageBuilding : Building {
        public static int MINIMUM_CAPACITY = 2000;

        public sealed override int Setup(){
            return Building.IProgressable_NO_PROGRESS;
        }

        // Progressing is irrelevant to a storage container
        public sealed override void Progress(){}

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