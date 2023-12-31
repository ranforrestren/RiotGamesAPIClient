using System.ComponentModel.DataAnnotations;

namespace RiotGamesAPIClient.src.Application.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string PlayerRiotUUID { get; set; } // pUUID
        [Required]
        [MaxLength(50)]
        public string PlayerRiotName { get; set; } // gameName
        [Required]
        [MaxLength(10)]
        public string PlayerRiotTagline { get; set; } // tagLine
        [Required]
        public string PlayerRiotAccountId { get; set; } // accountId
        [Required]
        public int PlayerProfileIconId { get; set; } // profileIconId
        [Required]
        public string PlayerSummonerId { get; set; } // id
        [Required]
        public long PlayerSummonerLevel { get; set; } // summonerLevel
    }
}
