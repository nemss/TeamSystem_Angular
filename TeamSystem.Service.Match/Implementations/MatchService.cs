namespace TeamSystem.Service.Match.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Service.Match.Interfaces;
    using TeamSystem.Service.Match.Models;

    public class MatchService : IMatchService
    {
        private readonly TeamSystemDbContext db;

        public MatchService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(int homeTeamId, int guestTeamId, DateTime? matchDate)
        {
            var match = new Matches()
            {
                MatchDate = matchDate,
                HomeTeamId = homeTeamId,
                HomeTeam = await this.db.Teams.FindAsync(homeTeamId),
                GuestTeamId = guestTeamId,
                GuestTeam = await this.db.Teams.FindAsync(guestTeamId)
            };

            await this.db.AddAsync(match);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, int homeTeamId, int guestTeamId, int? homeTeamScore, int? guesTeamScore)
        {
            var matchById = await this.db.Matches.FindAsync(id);

            if (matchById == null)
            {
                return;
            }

            matchById.MatchDate = DateTime.Now;
            matchById.HomeTeamId = homeTeamId;
            matchById.HomeTeam = await this.db.Teams.FindAsync(homeTeamId);
            matchById.HomeTeamScore = homeTeamScore;
            matchById.GuestTeamId = guestTeamId;
            matchById.GuestTeam = await this.db.Teams.FindAsync(guestTeamId);
            matchById.GuestTeamScore = guesTeamScore;

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var matchById = await this.db.Matches.FindAsync(id);

            if (matchById == null)
            {
                return;
            }

            this.db.Remove(matchById);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MatchModel>> AllAsync()
            => await this.db.Matches
            .Include(t => t.HomeTeam)
            .Include(t => t.GuestTeam)
            .OrderByDescending(m => m.MatchDate)
            .Select(m => new MatchModel()
            {
                Id = m.Id,
                MatchDate = m.MatchDate,
                HomeTeamId = m.HomeTeam.Id,
                HomeTeamScore = m.HomeTeamScore,
                GuestTeamId = m.GuestTeam.Id,
                GuestTeamScore = m.GuestTeamScore,
                HomeTeamName = m.HomeTeam.TeamName,
                GuestTeamName = m.GuestTeam.TeamName,
                HomeTeamThumb = m.HomeTeam.ThumbnailUrl,
                GuestTeamThumb = m.GuestTeam.ThumbnailUrl
            })
            .ToListAsync();

        public async Task<MatchModel> GetByIdAsync(int id)
            => await this.db.Matches
            .Where(m => m.Id == id)
            .Select(m => new MatchModel()
            {
               Id = m.Id,
               MatchDate = m.MatchDate,
               HomeTeamScore = m.HomeTeamScore,
               GuestTeamScore = m.GuestTeamScore,
               HomeTeamName = m.HomeTeam.TeamName,
               GuestTeamName = m .GuestTeam.TeamName,
               HomeTeamId = m.HomeTeam.Id,
               GuestTeamId = m.GuestTeam.Id,
               HomeTeamThumb = m.HomeTeam.ThumbnailUrl,
               GuestTeamThumb = m.GuestTeam.ThumbnailUrl

            })
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<MatchModel>> GetPerPageAsync(int itemsPerPage, int page = 1)
            => await this.db.Matches
            .Include(t => t.HomeTeam)
            .Include(t => t.GuestTeam)
            .OrderByDescending(m => m.MatchDate)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .Select(m => new MatchModel()
            {
                Id = m.Id,
                MatchDate = m.MatchDate,
                HomeTeamId = m.HomeTeam.Id,
                HomeTeamScore = m.HomeTeamScore,
                GuestTeamId = m.GuestTeam.Id,
                GuestTeamScore = m.GuestTeamScore,
                HomeTeamName = m.HomeTeam.TeamName,
                GuestTeamName = m.GuestTeam.TeamName,
                HomeTeamThumb = m.HomeTeam.ThumbnailUrl,
                GuestTeamThumb = m.GuestTeam.ThumbnailUrl
            })
            .ToListAsync();
    }
}
