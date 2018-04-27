namespace TeamSystem.Service.Match.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Entities;

    public class MatchModel
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public int GuestTeamId { get; set; }

        public IEnumerable<string> HomeTeamMembers { get; set; }

        public IEnumerable<string> GuestTeamMembers { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? GuestTeamScore { get; set; }

        public DateTime? MatchDate { get; set; }

        public string HomeTeamName { get; set; }

        public string GuestTeamName { get; set; }

        public string HomeTeamThumb { get; set; }

        public string GuestTeamThumb { get; set; }
    }
}
