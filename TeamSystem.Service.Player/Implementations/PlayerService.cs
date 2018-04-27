namespace TeamSystem.Service.Player.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Service.Player.Intefaces;
    using TeamSystem.Service.Player.Models;

    public class PlayerService : IPlayerService
    {
        private readonly TeamSystemDbContext db;

        public PlayerService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string firstName, string secondName, string LastName, string ucn, DateTime birthDate, int teamId, int modelId, bool isReserved)
        {
            var player = new PersonModels
            {
                FirstName = firstName,
                MiddleName = secondName,
                LastName = LastName,
                Ucn = ucn,
                BirthDate = birthDate,
                Team = await this.db.Teams.FindAsync(teamId),
                ModelRole = await this.db.ModelRoles.FindAsync(modelId),
                IsReserve = isReserved
            };

            await this.db.AddAsync(player);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var playerById = await this.db.PersonModels.FindAsync(id);

            if (playerById == null)
            {
                return;
            }

            this.db.Remove(playerById);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string firstName, string secondName, string lastName, string ucn, DateTime birthDate, int teamId, int modelId, bool isReserved)
        {
            var playerById = await this.db.PersonModels.FindAsync(id);

            if (playerById == null)
            {
                return;
            }

            playerById.FirstName = firstName;
            playerById.MiddleName = secondName;
            playerById.LastName = lastName;
            playerById.Ucn = ucn;
            playerById.BirthDate = birthDate;
            playerById.TeamId = teamId;
            playerById.ModelRoleId = modelId;
            playerById.IsReserve = isReserved;

            await db.SaveChangesAsync();
        }

        public async Task<PlayerModel> GetByIdAsync(int id)
            => await this.db.PersonModels
            .Where(p => p.Id == id)
            .Include(t => t.Team)
            .Include(t => t.ModelRole)
            .Select(p => new PlayerModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                SecondName = p.MiddleName,
                Ucn = p.Ucn,
                BirthDate = p.BirthDate,
                TeamId = p.TeamId,
                TeamName = p.Team.TeamName,
                ModelRoleId = p.ModelRoleId,
                ModelRoleName = p.ModelRole.Role,
                IsReserved = p.IsReserve
            })
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PlayerModel>> GetAllAsync()
            => await this.db.PersonModels
            .Include(t => t.Team)
            .Include(t => t.ModelRole)
            .Select(p => new PlayerModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                SecondName = p.MiddleName,
                Ucn = p.Ucn,
                BirthDate = p.BirthDate,
                TeamId = p.TeamId,
                TeamName = p.Team.TeamName,
                ModelRoleId = p.ModelRoleId,
                ModelRoleName = p.ModelRole.Role,
                IsReserved = p.IsReserve
            })
            .ToListAsync();

        public async Task<IEnumerable<PlayerModel>> GetPerPageAsync(int itemsPerPage, int page = 1)
            => await db.PersonModels
            .Include(t => t.Team)
            .Include(t => t.ModelRole)
            .OrderBy(p => p.FirstName)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .Select(p => new PlayerModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                SecondName = p.MiddleName,
                Ucn = p.Ucn,
                BirthDate = p.BirthDate,
                TeamId = p.TeamId,
                TeamName = p.Team.TeamName,
                ModelRoleId = p.ModelRoleId,
                ModelRoleName = p.ModelRole.Role,
                IsReserved = p.IsReserve
            })
            .ToListAsync();

        public async Task<IEnumerable<PlayerModel>> FindAsync(string searchedText)
        {
            searchedText = searchedText ?? string.Empty;

            return await db.PersonModels
                .OrderByDescending(p => p.Id)
                .Where(p => p.Ucn.ToLower().Contains(searchedText.ToLower()))
                .Select(p => new PlayerModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    SecondName = p.MiddleName,
                    Ucn = p.Ucn,
                    BirthDate = p.BirthDate,
                    TeamId = p.TeamId,
                    ModelRoleId = p.ModelRoleId,
                    IsReserved = p.IsReserve
                })
                .ToListAsync();
        }
    }
}
