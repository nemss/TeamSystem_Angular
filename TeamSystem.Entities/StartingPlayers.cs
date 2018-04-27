namespace TeamSystem.Entities
{
    using System;

    public partial class StartingPlayers
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? PlayerId { get; set; }

        public StartingMembersOfAteam Member { get; set; }
        public PersonModels Player { get; set; }
    }
}
