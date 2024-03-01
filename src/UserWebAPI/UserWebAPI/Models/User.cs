using System.ComponentModel.DataAnnotations;

namespace UserWebAPI.Models
{
    //its not a good idea to use data anotation here we should use view model or something else later
    public class User
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [MaxLength(11,ErrorMessage ="تعداد ارقام تلفن همراه باید 11 رقم باشد")]
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? PictureUserPath { get; set; }
        public User(string mobile , string password)
        {
            Mobile = mobile;
            Password = password;
        }

    }
}
