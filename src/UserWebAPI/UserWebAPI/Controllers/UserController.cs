using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserWebAPI.Common;
using UserWebAPI.Data;
using UserWebAPI.Data.Enums;
using UserWebAPI.Data.Repository;
using UserWebAPI.Models;
using XSystem.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

       

        public UserController(IUserRepository userRepository , IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            webHostEnvironment = _hostingEnvironment;
        }
        
        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        [HttpPost]
        [Route("Insert")]
        public IEnumerable<User> Insert(string mobile , string password)
        {
            //hash password later
            var passwordScore = PasswordAdvisor.CheckStrength(password);
            if (passwordScore < PasswordScore.Strong) throw new Exception("کلمه عبور امن نیست");
            var user = new User(mobile, password);
            _userRepository.Insert(user);
            var users = _userRepository.GetAll();
            return users;
        }
        [HttpPut]
        [Route("Update")]
        public IEnumerable<User> Update([FromBody] User user)
        {
            _userRepository.Update(user);
            var users = _userRepository.GetAll();
            return users;
        }

        [HttpDelete]
        [Route("Remove")]
        public IEnumerable<User> Remove([FromBody] int id)
        {
            _userRepository.Remove(id);
            var users = _userRepository.GetAll();
            return users;
        }

        [HttpGet]
        [Route("GetUser")]
        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        [HttpPost]
        [Route("AssignPictureToProfile")]
        public void AssignPictureToProfile([FromBody] IFormFile file , [FromBody] int id)
        {
           var user = _userRepository.Get(id);
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "Features");
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            var filePath = Path.Combine(uploadFolder, fileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));
            user.PictureUserPath= filePath;
        }
    }
}
