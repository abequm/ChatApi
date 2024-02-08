using System.ComponentModel.DataAnnotations;

namespace Chat.Api.Domain.Users
{
    public class AuthorizeModel : Model
    {
        [Required(ErrorMessage = "Логин не должен быть пустым")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не должен быть пустым")]

        public string Password { get; set; }
    }
}
