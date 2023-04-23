namespace COH3ReplayManager
{
    internal class ReplayData
    {
        public int version { get; set; }
        public string timestamp { get; set; }
        public long matchhistory_id { get; set; }
        public Map map { get; set; }
        public List<Player> players { get; set; }
        public int length { get; set; }

        public class Map
        {
            public string filename { get; set; }
            public string localized_name_id { get; set; }
            public string localized_description_id { get; set; }
        }

        public class Player
        {
            public string name { get; set; }
            public string faction { get; set; }
            public long steam_id { get; set; }
            public long profile_id { get; set; }
            public List<PlayerMessage> messages { get; set; }

            public class PlayerMessage
            {
                public int tick { get; set; }
                public string message { get; set; }
            }
        }
    }
}