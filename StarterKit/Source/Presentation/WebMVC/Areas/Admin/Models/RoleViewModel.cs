using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Role Name is Required")]
        public string Name { get; set; }
        public string Id { get; set; }
    }
}