namespace TeamSystem.Service.PlayerRole.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Service.PlayerRole.Intefaces;
    using TeamSystem.Service.PlayerRole.Models;

    public class PlayerRoleService : IPlayerRoleService
    {
        private readonly TeamSystemDbContext db;

        public PlayerRoleService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string role)
        {
            var playerRole = new ModelRoles()
            {
                Role = role
            };

            await this.db.AddAsync(playerRole);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var playerRoleById = await this.db.ModelRoles.FindAsync(id);

            if (playerRoleById == null)
            {
                return;
            }

            this.db.Remove(playerRoleById);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string role)
        {
            var playerRoleById = await this.db.ModelRoles.FindAsync(id);

            if (playerRoleById == null)
            {
                return;
            }

            playerRoleById.Role = role;

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayerRoleModel>> GetAllAsync()
            => await this.db.ModelRoles
            .Select(mr => new PlayerRoleModel()
            {
                Id = mr.Id,
                RoleName = mr.Role
            })
            .ToListAsync();

        public async Task<PlayerRoleModel> GetByIdAsync(int id)
            => await this.db.ModelRoles
            .Where(mr => mr.Id == id)
            .Select(mr => new PlayerRoleModel()
            {
                Id = mr.Id,
                RoleName = mr.Role
            })
            .FirstOrDefaultAsync();
    }
}
