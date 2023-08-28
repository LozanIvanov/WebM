using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebM.Controllers.Admin
{
    [Route("/Admin/Dashboard")]
    [Authorize(Roles="Admin")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Dashboard/Index.cshtml");
        }
    }
}
