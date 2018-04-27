namespace TeamSystem.Service.Team.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Service.Team.Models;

    public interface ITeamService
    {
        Task CreateAsync(string name, string thumbnailUrl);

        Task EditAsync(int id, string name, string thumbnailUrl);

        Task DeleteAsync(int id);

        Task<IEnumerable<TeamModel>> GetAllAsync();

        Task<TeamModel> GetByIdAsync(int id);

        Task<IEnumerable<TeamModel>> GetPerPageAsync(int itemsPerPage, int page = 1);
    }
}
