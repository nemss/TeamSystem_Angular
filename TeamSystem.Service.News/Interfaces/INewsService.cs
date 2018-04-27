namespace TeamSystem.Service.News.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Service.News.Models;

    public interface INewsService
    {
        Task<NewsModel> GetById(int id);

        Task<IEnumerable<NewsModel>> GetAllAsync();

        Task<IEnumerable<NewsModel>> GetPerPageAsync(int itemsPerPage, int page = 1);

        Task<IEnumerable<NewsModel>> FindAsync(string searchedText);
    }
}
