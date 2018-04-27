namespace TeamSystem.Service.Player.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class PlayerModel
    {
        public int Id  { get; set; }

        [Required]
        [MinLength(PlayerNameMinLength)]
        [MaxLength(PlayerNameMaxLenghth)]
        public string  FirstName { get; set; }

        [Required]
        [MinLength(PlayerNameMinLength)]
        [MaxLength(PlayerNameMaxLenghth)]
        public string SecondName { get; set; }

        [Required]
        [MinLength(PlayerNameMinLength)]
        [MaxLength(PlayerNameMaxLenghth)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Ucn { get; set; }

        public DateTime BirthDate { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int ModelRoleId { get; set; }

        public string ModelRoleName { get; set; }

        [DisplayName("Is Reserved")]
        public bool IsReserved { get; set; }
    }
}
