using System.ComponentModel.DataAnnotations;

namespace CoreWeb.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string name { get; set; }
    }
}
