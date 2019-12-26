using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class RegistrationBindingModel
    {
        [Required] // свойство является обязательнысы
        [StringLength (50)] //  длина своства 
        [Display(Name="Логин")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [UIHint("EmailAddress")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [UIHint("Password")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Телефон")]
        [UIHint("Phone")]
        public int Phone { get; set; }

        [Display(Name = "Согласен с условиями использования")]
        public bool TermsAccepted { get; set; }
    }
}
