using System.ComponentModel.DataAnnotations;

namespace RiotGamesAPIClient.Models
{
    public class Player
    {
        [Key]
        public String PlayerId { get; set; } // pUUID
        [Required]
        [MaxLength(50)]
        public String PlayerName { get; set; } // gameName
        [Required]
        [MaxLength(10)]
        public String PlayerTagline { get; set; } // tagLine
    }
}
