using System.Collections.Generic;

namespace WebMVC.Areas.Admin.Models
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public IList<RoleClaimsViewModel> RoleClaims { get; set; }
    }    
}