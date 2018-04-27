namespace TeamSystem.Service.News.Implementations
{
    using System;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Service.News.Interfaces;

    public class ArticleService : IArticleService
    {
        private readonly TeamSystemDbContext db;

        public ArticleService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string content, string thumbnailUrl)
        {
            var article = new Articles()
            {
                Title = title,
                Content = content,
                ThumbnailUrl = thumbnailUrl,
                PublishDate = DateTime.Now
            };

            await this.db.AddAsync(article);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var articleById = await this.db.Articles.FindAsync(id);

            if (articleById == null)
            {
                return;
            }

            this.db.Remove(articleById);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string content, string thumbnailUrl)
        {
            var articleById = await this.db.Articles.FindAsync(id);

            if (articleById == null)
            {
                return;
            }

            articleById.Title = title;
            articleById.Content = content;
            articleById.ThumbnailUrl = thumbnailUrl;
            articleById.PublishDate = DateTime.Now;

            await db.SaveChangesAsync();
        }
    }
}
