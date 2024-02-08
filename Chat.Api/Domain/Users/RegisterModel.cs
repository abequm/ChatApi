using System.ComponentModel.DataAnnotations;
using Chat.Api.Core.Attributes;

using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Domain.Users
{
    public class RegisterModel : Model
    {
        [FromForm]
        [Required(ErrorMessage = "Логин не должен быть пустым")]
        [MinLength(8, ErrorMessage = $"Логин не может содержать менее 8 символов")]
        [MaxLength(32, ErrorMessage = "Логин не может содержать более 32 символов")]
        public string Login { get; set; }
        [FromForm]
        [Required(ErrorMessage = "Пароль не должен быть пустым")]
        [MinLength(8, ErrorMessage = "Пароль не может содержать менее 8 символов")]
        [MaxLength(32, ErrorMessage = "Пароль не может содержать более 32 символов")]
        [Pattern("[0-9]", "Пароль должен содержать цифры",false)]
        [Pattern("[a-z]", "Пароль должен содержать строчные(нижнего регистра) буквы латинского алфавита", false)]
        [Pattern("[A-Z]", "Пароль должен содержать прописные(вержнего регистра) буквы латинского алфавита", false)]
        [Pattern("[!?/\\-=+_]", @"Пароль должен содержать спецсимволы !?/\-=+_", false)]
        public string Password { get; set; }
        [FromForm]
        [Required(ErrorMessage ="Псевдоним не должен быть пустым")]
        [MinLength(1, ErrorMessage = "Псевдоним не может содержать менее 1 символа")]
        [MaxLength(32, ErrorMessage = "Псевдоним не может содержать более 32 символов")]
        public string Nickname { get; set; }
    }
}
