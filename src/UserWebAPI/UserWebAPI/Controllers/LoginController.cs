using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UserWebAPI.Data.Repository;
using UserWebAPI.Models;
using XSystem.Security.Cryptography;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("Login")]
        public bool Login(string mobile , string password)
        {
            var user = _userRepository.GetByMobile(mobile);
            if(user == null )
            {
                throw new Exception("کاربر یافت نشد لطفا دوباره شماره همراه خود را وارد نمایید");
            }
            //encryot passsword later 
            if (password == user.Password)
            {
                user.LastLoginDate = DateTime.Now;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public IEnumerable<User> ForgotPassword(string mobile, string password)
        {
            //hash password later
            var user = _userRepository.GetByMobile(mobile);
            if (user == null)
            {
                throw new Exception("کاربر یافت نشد لطفا دوباره شماره همراه خود را وارد نمایید");
            }
            user.Password= password;
            _userRepository.Update(user);
            var users = _userRepository.GetAll();
            return users;
        }
    }
}
