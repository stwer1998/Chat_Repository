using System.ComponentModel.DataAnnotations;

namespace ChatWebApplication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }
    }
}
