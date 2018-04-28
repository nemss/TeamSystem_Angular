namespace TeamSystem.SPA.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Service.Player.Intefaces;
    using TeamSystem.Service.PlayerRole.Intefaces;
    using TeamSystem.SPA.Infrastructure.Extensions;
    using static WebConstants;

    public class PlayerRolesController : BaseController
    {
        private readonly IPlayerRoleService playerRoles;

        public PlayerRolesController(IPlayerRoleService playerRoles)
        {
            this.playerRoles = playerRoles;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => this.OkOrNotFound(await this.playerRoles.GetAllAsync());
    }
}
