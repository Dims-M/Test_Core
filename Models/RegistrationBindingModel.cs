using System.ComponentModel.DataAnnotations;

namespace DisplayAttributeSample.Models
{
    public class RegistrationBindingModel
    {
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

        [Display(Name = "Согласен с условиями использования")]
        public bool TermsAccepted { get; set; }
    }
}
