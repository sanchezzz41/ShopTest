using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

namespace ShopTest.Web.Controllers
{
    /// <summary>
    /// Контроллер для регистрации и авторизации
    /// </summary>
    [Route("Account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Регистрация пользователя
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<object> Register([FromBody] RegisterModel model)
        {
            var user = new User(model.UserName, model.Email, model.PhoneNumber);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var resultId = await _userManager.GetUserIdAsync(user);
                await _signInManager.PasswordSignInAsync(user, "admin", true, false);
                return new {id = resultId};
            }
            return "ERROR";
        }

        //Вход на сайт
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
            if (result.Succeeded)
            {
                return new {response = "Вы успешно авторизировались."};
            }
            return new {response = "Вы что то ввели неправильно."};
        }

        //Выход с сайта
        [Authorize]
        [HttpDelete]
        public async Task<object> LotOut()
        {
            await _signInManager.SignOutAsync();
            return new {response = "Вы успешно вышли с аккаунта."};
        }
    }
}
