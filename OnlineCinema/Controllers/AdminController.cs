using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Models;
using System.Text.Json;

namespace OnlineCinema.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {

        private readonly UserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(UserService userService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;   
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers()
        {
            var users = (await _userService.GetAllUsers()).ToList();
            var usersViewModel = new List<UserViewModel>();
            var rolesList = _roleManager.Roles.Select(x => x.Name).ToList();


            foreach (var user in users)
            {
                var userViewModel = new UserViewModel() { Roles = rolesList };
                var identityUser = await _userManager.FindByIdAsync(user.Id);

                userViewModel.Login = identityUser.UserName;
                userViewModel.Id = identityUser.Id;
                //TODO .
                usersViewModel.Add(userViewModel);
            }

            return View(usersViewModel);
        }
        public async void SetRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, role);
        }

        public IActionResult NewSeasonForm()
        {
            return View();
        }

        public IActionResult NewMovieForm()
        {
            return View();
        }
    }
}
