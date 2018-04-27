namespace TeamSystem.Service.PlayerRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    using System.Text;

    public class PlayerRoleModel
    {
        public int Id { get; set; }

        [MaxLength(ModelRolesNameMaxLength)]
        [MinLength(ModelRolesNameMinLength)]
        public string RoleName { get; set; }
    }
}
