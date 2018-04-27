namespace TeamSystem.Service.Match.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Service.Match.Models;

    public interface IMatchService
    {
        Task CreateAsync(int homeTeamId, int guestTeamId, DateTime? matchDate);

        Task EditAsync(int id, int homeTeamId, int guestTeamId, int? homeTeamScore, int? guesTeamScore);

        Task DeleteAsync(int id);

        Task<IEnumerable<MatchModel>> AllAsync();

        Task<MatchModel> GetByIdAsync(int id);

        Task<IEnumerable<MatchModel>> GetPerPageAsync(int itemsPerPage, int page = 1);
    }
}
