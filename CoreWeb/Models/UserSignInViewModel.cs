using System.ComponentModel.DataAnnotations;

namespace CoreWeb.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string password { get; set; }
    }
}
