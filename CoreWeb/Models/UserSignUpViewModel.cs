using System.ComponentModel.DataAnnotations;

namespace CoreWeb.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string UserName { get; set; }

    }
}
