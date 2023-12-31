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
    }
}
