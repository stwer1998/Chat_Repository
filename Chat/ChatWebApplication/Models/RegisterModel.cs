using System.ComponentModel.DataAnnotations;

namespace ChatWebApplication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }
    }
}
