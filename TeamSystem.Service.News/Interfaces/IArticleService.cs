namespace TeamSystem.Service.News.Interfaces
{
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task CreateAsync(string title, string content, string thumbnailUrl);

        Task EditAsync(int id, string title, string content, string thumbnailUrl);

        Task DeleteAsync(int id);
    }
}
