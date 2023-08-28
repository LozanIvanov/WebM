using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Dal.Models.Admin;
using Web.Database.Models;

namespace WebM.Controllers.Admin
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("Admin/Users")]
        public async Task< IActionResult> Index()
        {
            List<User> userList = await userManager.Users.ToListAsync();
            List<UserViewModel> userListModel = new List<UserViewModel>();

            foreach (var user in userList)
            {
                var roles = await userManager.GetRolesAsync(user);
                userListModel.Add(new UserViewModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Roles = roles.ToList()
                });
            }

            return View("~/Views/Admin/Users/Index.cshtml", userListModel);
        }
    }
}
