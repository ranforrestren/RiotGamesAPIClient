using System.ComponentModel.DataAnnotations;

namespace RiotGamesAPIClient.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(100)]
        public String PlayerRiotUUID { get; set; } // pUUID
        [Required]
        [MaxLength(50)]
        public String PlayerRiotName { get; set; } // gameName
        [Required]
        [MaxLength(10)]
        public String PlayerRiotTagline { get; set; } // tagLine
    }
}
