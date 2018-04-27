using Microsoft.AspNetCore.Mvc;

namespace TeamSystem.SPA.Infrastructure.Extensions
{
  public static class ControllerExtensions
  {
    public static IActionResult OkOrNotFound(this Controller controller, object model)
    {
      if (model == null)
      {
        return controller.NotFound();
      }
      
      return controller.Ok(model);
    }
  }
}
