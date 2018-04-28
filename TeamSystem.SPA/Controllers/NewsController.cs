namespace TeamSystem.SPA.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Service.News.Interfaces;
    using TeamSystem.Service.News.Models;
    using TeamSystem.SPA.Infrastructure.Extensions;
    using TeamSystem.SPA.Infrastructure.Filters;
    using static WebConstants;

    public class NewsController : BaseController
    {
        private readonly INewsService news;
        private readonly IArticleService article;

        public NewsController(INewsService news,
                              IArticleService article)
        {
            this.news = news;
            this.article = article;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNewsAsync()
          => this.OkOrNotFound(await this.news.GetAllAsync());

        [HttpGet(PerPage)]
        public async Task<IActionResult> GetAllNewsPerPageAsync(int itemsPerPage, int page = 1)
          => this.OkOrNotFound(await this.news.GetPerPageAsync(itemsPerPage, page));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
                => this.OkOrNotFound(await this.news.GetById(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] NewsModel model)
        {
            await this.article.CreateAsync(model.Title, model.Content, model.ThumbnailUrl);

            return Ok();
        }


        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var articleById = await this.news.GetById(id);

            if (articleById == null)
            {
                return NotFound();
            }

            await this.article.DeleteAsync(id);

            return Ok();
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody] NewsModel model)
        {
            var articleById = await this.news.GetById(id);

            if (articleById == null)
            {
                return NotFound();
            }

            await this.article.EditAsync(id, model.Title, model.Content, model.ThumbnailUrl);

            return Ok();
        }
    }
}
