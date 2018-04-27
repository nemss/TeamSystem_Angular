namespace TeamSystem.Service.Team.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Service.Team.Interfaces;
    using TeamSystem.Service.Team.Models;

    public class TeamService : ITeamService
    {
        private readonly TeamSystemDbContext db;

        public TeamService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, string thumbnailUrl)
        {
            var team = new Teams
            {
                TeamName = name,
                ThumbnailUrl = thumbnailUrl
            };

            await this.db.AddAsync(team);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teamById = await this.db.Teams.FindAsync(id);

            if (teamById == null)
            {
                return;
            }

            this.db.Remove(teamById);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, string thumbnailUrl)
        {
            var teamById = await this.db.Teams.FindAsync(id);

            if (teamById == null)
            {
                return;
            }

            teamById.TeamName = name;
            teamById.ThumbnailUrl = thumbnailUrl;
            await this.db.SaveChangesAsync();
        }
        public async Task<IEnumerable<TeamModel>> GetAllAsync()
            => await this.db.Teams
            .OrderBy(t => t.TeamName)
            .Select(t => new TeamModel()
            {
                Id = t.Id,
                TeamName = t.TeamName,
                ThumbnailUrl = t.ThumbnailUrl
            })
            .ToListAsync();

        public async Task<TeamModel> GetByIdAsync(int id)
            => await this.db.Teams
            .Where(t => t.Id == id)
            .Select(t => new TeamModel()
            {
                Id = t.Id,
                TeamName = t.TeamName,
                ThumbnailUrl = t.ThumbnailUrl
            })
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<TeamModel>> GetPerPageAsync(int itemsPerPage, int page = 1)
            => await this.db.Teams
            .OrderBy(t => t.TeamName)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .Select(t => new TeamModel()
            {
                Id = t.Id,
                TeamName = t.TeamName,
                ThumbnailUrl = t.ThumbnailUrl
            })
            .ToListAsync();
    }
}
