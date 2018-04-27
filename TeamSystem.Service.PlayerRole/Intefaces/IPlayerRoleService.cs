namespace TeamSystem.Service.PlayerRole.Intefaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Service.PlayerRole.Models;

    public interface IPlayerRoleService
    {
        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<IEnumerable<PlayerRoleModel>> GetAllAsync();

        Task<PlayerRoleModel> GetByIdAsync(int id);
    }
}
