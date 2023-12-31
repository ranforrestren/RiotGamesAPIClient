

namespace RiotGamesAPIClient.src.Infrastructure.Services.Responses
{
    public class RiotMatchAPIResponse
    {
        public Info info { get; set; }

        public class Info
        {
            public Participant[] participants { get; set; }
        }

        public class Participant
        {
            public string puuid { get; set; }
            public string championName { get; set; }
            public int championId { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int goldEarned { get; set; }
            public int totalDamageDealtToChampions { get; set; }
        }

    }
}
