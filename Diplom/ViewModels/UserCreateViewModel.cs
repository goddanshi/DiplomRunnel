using System.ComponentModel.DataAnnotations;

namespace Diplom.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль обязателен")]
        [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "ФИО обязательно")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Должность обязательна")]
        public string? Position { get; set; }

        [Required(ErrorMessage = "Выберите роль")]
        public string Role { get; set; } = string.Empty;
    }
}