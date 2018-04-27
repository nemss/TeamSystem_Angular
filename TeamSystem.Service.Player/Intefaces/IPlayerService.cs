namespace TeamSystem.Service.Player.Intefaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Service.Player.Models;

    public interface IPlayerService
    {
        Task CreateAsync(string firstName,
                         string secondName,
                         string LastName,
                         string ucn,
                         DateTime birthDate,
                         int teamId,
                         int modelId,
                         bool isReserved);

        Task EditAsync(int id,
                       string firstName,
                       string secondName,
                       string lastName,
                       string ucn,
                       DateTime birthDate,
                       int teamId,
                       int modelId,
                       bool isReserved);

        Task DeleteAsync(int id);

        Task<PlayerModel> GetByIdAsync(int id);

        Task<IEnumerable<PlayerModel>> GetAllAsync();

        Task<IEnumerable<PlayerModel>> GetPerPageAsync(int itemsPerPage, int page = 1);

        Task<IEnumerable<PlayerModel>> FindAsync(string searchedText);
    }
}
