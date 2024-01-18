namespace MatrimonyWebApi.Data
{
    public static class InterestStatusType
    {
        public static KeyValuePair<string, int> open = new KeyValuePair<string, int> ("open", 1);
        public static KeyValuePair<string, int> accepted = new KeyValuePair<string, int> ("accepted", 2);
        public static KeyValuePair<string, int> rejected = new KeyValuePair<string, int> ("rejected", 3);
    }
       
}
