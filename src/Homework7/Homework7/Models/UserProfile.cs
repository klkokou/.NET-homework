using System;
using System.ComponentModel.DataAnnotations;

namespace Homework7.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[A-ZА-Яa-zа-я]+$", ErrorMessage = "Unkonwn symbols in surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[A-ZА-Яa-zа-я]+$", ErrorMessage = "Unkonwn symbols in name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-ZА-Яa-zа-я]+$", ErrorMessage = "Unkonwn symbols in patronymic")]
        public string Patronymic { get; set; }

        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Required field, please enter a number")]
        [Range(0, 200,ErrorMessage = "Should be in range 0-200")]
        public int? Age { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Neutral
    }
}