namespace TeamSystem.Service.Team.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class TeamModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TeamNameMinLength)]
        [MaxLength(TeamNameMaxLength)]
        public string TeamName { get; set; }

        [Required]
        [MaxLength(ThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }
    }
}
