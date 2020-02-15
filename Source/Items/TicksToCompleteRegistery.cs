namespace rts.item {
    public static class TicksToCompleteRegistery {
        public static int INSTANT_COMPLETION = 0;

        public const int WHEAT = 6800;
        public const int OAT = 9000;

        public static int GetTicksToHarvest(ref ItemType item){
            switch (item){
                case ItemType.PLANT_OAT:
                    return OAT;
                case ItemType.PLANT_WHEAT:
                    return WHEAT;
                default:
                    return INSTANT_COMPLETION;
            }
        }
    }
}