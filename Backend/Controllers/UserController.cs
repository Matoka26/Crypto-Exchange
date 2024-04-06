using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_binance_api.Models;
using test_binance_api.Models.DTOs.User;
using test_binance_api.Models.Errors;
using test_binance_api.Service.UserService;
using test_binance_api.Service.UserWalletHistoryService;
using User.Mailing.Service.Models;
using User.Mailing.Service.Services;

namespace test_binance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IUserWalletHistoryService _userWalletHistoryService;
        private readonly IEmailService _emailService;

        public UserController(UserManager<User> userManager, IUserService userService,
            IUserWalletHistoryService userWalletHistoryService, IEmailService emailService)
        {
            _userManager = userManager;
            _userService = userService;
            _userWalletHistoryService = userWalletHistoryService;
            _emailService = emailService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDTO user)
        {
            var subject = "Test";
            var content = "SignUp successfull";
            var message = new Message(new string[] { user.Email }, subject, content);


            _emailService.SendEmail(message);
            return Ok(await _userService.SignUp(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            return Ok(await _userService.Login(user));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok();
        }

        [HttpGet("confirm_email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            return Ok(await _userService.ConfirmEmail(email, token));
        }

        [HttpPatch("device-token/{deviceToken}")]
        public async Task<IActionResult> StoreDeviceToken(string deviceToken)
        {
            string userId = _userManager.GetUserId(User);

            try
            {
                await _userService.StoreDeviceToken(userId, deviceToken);
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Device token stored"
            });
        }


        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync(UserCreateDTO user)
        {
            return Ok(await _userWalletHistoryService.CreateAsync(user));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDTO user)
        {
            return Ok(await _userService.Update(user));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
