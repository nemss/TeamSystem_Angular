namespace TeamSystem.SPA.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;
  using TeamSystem.Service.Match.Interfaces;
  using TeamSystem.Service.Match.Models;
  using TeamSystem.SPA.Infrastructure.Extensions;
  using TeamSystem.SPA.Infrastructure.Filters;
  using static WebConstants;

  public class MatchesController : BaseController
  {
    private readonly IMatchService matches;

    public MatchesController(IMatchService matches)
    {
      this.matches = matches;
    }

    [HttpPost]
    [ValidateModelState]
    public async Task<IActionResult> Post([FromBody] MatchModel model)
    {
      await this.matches.CreateAsync(model.HomeTeamId,
                                     model.GuestTeamId,
                                     model.MatchDate);

      return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
      => this.OkOrNotFound(await this.matches.AllAsync());

    [HttpGet(WithId)]
    public async Task<IActionResult> Get(int id)
      => this.OkOrNotFound(await this.matches.GetByIdAsync(id));

    [HttpGet(PerPage)]
    public async Task<IActionResult> GetAllMatchesPerPageAsync(int itemsPerPage, int page = 1)
      => this.OkOrNotFound(await this.matches.GetPerPageAsync(itemsPerPage, page));

    [HttpDelete(WithId)]
    public async Task<IActionResult> Delete(int id)
    {
      var matchById = await this.matches.GetByIdAsync(id);

      if (matchById == null)
      {
        return NotFound();
      }

      await this.matches.DeleteAsync(id);

      return Ok();
    }

    [HttpPut(WithId)]
    [ValidateModelState]
    public async Task<IActionResult> Put(int id, [FromBody] MatchModel model)
    {
      var playerById = await this.matches.GetByIdAsync(id);

      if (playerById == null)
      {
        return NotFound();
      }

      await this.matches.EditAsync(id,
                                   model.HomeTeamId,
                                   model.GuestTeamId,
                                   model.HomeTeamScore,
                                   model.GuestTeamScore);

      return Ok();
    }
  }
}
