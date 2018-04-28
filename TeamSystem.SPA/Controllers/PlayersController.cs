namespace TeamSystem.SPA.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Service.Player.Intefaces;
    using TeamSystem.Service.Player.Models;
    using TeamSystem.SPA.Infrastructure.Extensions;
    using TeamSystem.SPA.Infrastructure.Filters;
    using static WebConstants;

    public class PlayersController : BaseController
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players)
        {
            this.players = players;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => this.OkOrNotFound(await this.players.GetAllAsync());

        [HttpGet(PerPage)]
        public async Task<IActionResult> GetAllPlayersPerPageAsync(int itemsPerPage, int page = 1)
          => this.OkOrNotFound(await this.players.GetPerPageAsync(itemsPerPage, page));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
                => this.OkOrNotFound(await this.players.GetByIdAsync(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] PlayerModel model)
        {
            await this.players.CreateAsync(model.FirstName,
                                           model.SecondName,
                                           model.LastName,
                                           model.Ucn,
                                           model.BirthDate,
                                           model.TeamId,
                                           model.ModelRoleId,
                                           model.IsReserved);

            return Ok();
        }


        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var playerById = await this.players.GetByIdAsync(id);

            if (playerById == null)
            {
                return NotFound();
            }

            await this.players.DeleteAsync(id);

            return Ok();
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody] PlayerModel model)
        {
            var playerById = await this.players.GetByIdAsync(id);

            if (playerById == null)
            {
                return NotFound();
            }

            await this.players.EditAsync(id, model.FirstName, model.SecondName, model.LastName, model.Ucn, model.BirthDate, model.TeamId, model.ModelRoleId, model.IsReserved);

            return Ok();
        }
    }
}
