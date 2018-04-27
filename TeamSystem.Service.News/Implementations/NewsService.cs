namespace TeamSystem.Service.News.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Service.News.Interfaces;
    using TeamSystem.Service.News.Models;

    public class NewsService : INewsService
    {
        private readonly TeamSystemDbContext db;

        public NewsService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<NewsModel> GetById(int id)
            => await db.Articles
                .Where(a => a.Id == id)
                .Select(a => new NewsModel()
                {
                    Id = id,
                    Title = a.Title,
                    Content = a.Content,
                    ThumbnailUrl = a.ThumbnailUrl,
                    PublishDate = a.PublishDate
                })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<NewsModel>> GetAllAsync()
        {
            var articles = await db.Articles
                .OrderByDescending(a => a.PublishDate)
                .Select(a => new NewsModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    ThumbnailUrl = a.ThumbnailUrl,
                    PublishDate = a.PublishDate
                })
                .ToListAsync();

            return articles;
        }

        public async Task<IEnumerable<NewsModel>> GetPerPageAsync(int itemsPerPage, int page = 1)
            => await db.Articles
            .OrderByDescending(a => a.PublishDate)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .Select(a => new NewsModel()
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                ThumbnailUrl = a.ThumbnailUrl,
                PublishDate = a.PublishDate
            })
            .ToListAsync();

        public async Task<IEnumerable<NewsModel>> FindAsync(string searchedText)
        {
            searchedText = searchedText ?? string.Empty;

            return await db.Articles
                .OrderByDescending(c => c.Id)
                .Where(a => a.Title.ToLower().Contains(searchedText.ToLower()))
                .Select(a => new NewsModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    ThumbnailUrl = a.ThumbnailUrl,
                    PublishDate = a.PublishDate
                })
                .ToListAsync();
        }
    }
}
