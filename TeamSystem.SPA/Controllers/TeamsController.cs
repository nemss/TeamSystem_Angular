namespace TeamSystem.SPA.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Service.Team.Interfaces;
    using TeamSystem.Service.Team.Models;
    using TeamSystem.SPA.Infrastructure.Extensions;
    using TeamSystem.SPA.Infrastructure.Filters;
    using static WebConstants;

    public class TeamsController : BaseController
    {
        private readonly ITeamService teams;

        public TeamsController(ITeamService teams)
        {
            this.teams = teams;
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] TeamModel model)
        {
            await this.teams.CreateAsync(model.TeamName, model.ThumbnailUrl);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => this.OkOrNotFound(await this.teams.GetAllAsync());

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
          => this.OkOrNotFound(await this.teams.GetByIdAsync(id));

        [HttpGet(PerPage)]
        public async Task<IActionResult> GetAllTeamsPerPageAsync(int itemsPerPage, int page = 1)
          => this.OkOrNotFound(await this.teams.GetPerPageAsync(itemsPerPage, page));

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody] TeamModel model)
        {
            await this.teams.EditAsync(model.Id, model.TeamName, model.ThumbnailUrl);

            return Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var teamById = await this.teams.GetByIdAsync(id);

            if (teamById == null)
            {
                return NotFound();
            }

            await this.teams.DeleteAsync(id);

            return Ok();
        }
    }
}
