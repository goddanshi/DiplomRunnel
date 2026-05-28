using Microsoft.AspNetCore.Identity;

namespace Diplom.Models
{
    public class AppUser : IdentityUser
    {
        // Дополнительные поля
        public string? FullName { get; set; }   // ФИО сотрудника
        public string? Position { get; set; }   // Должность (Мастер смены, Кладовщик и т.п.)
        // Можно добавить дату создания, фото, но для диплома хватит
    }
}