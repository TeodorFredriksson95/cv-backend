using CV.Api;
using CV.Application.Services;
using CV_backend.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace CV_backend.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(ApiEndpoints.User.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var users = await _userService.GetAllAsync(token);
            return Ok(users.MapToUsersResponse());

        }
    }
}