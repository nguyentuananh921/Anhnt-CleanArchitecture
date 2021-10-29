using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    /// <summary>
    /// https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/?fbclid=IwAR0u06OATyHRIRRccJD7bexRvy1plpeWR_mffKd_2XVk88C5MZY1XCPY_Tw
    /// </summary>   
    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }

    #region
    /// <summary>
    /// https://www.youtube.com/watch?v=liyhZW22WmQ&lc=UgwtXr4ghuC3wBsZYZ14AaABAg.9P0tGh3Ooul9P6a9S6z8FM
    /// https://github.com/itsdevkev/TaskList
    /// public class TaskItem : BaseEntity //For Audit 
    /// The other way to do audit here
    /// </summary>    
    
    //public class BaseEntity
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime DateCreated { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime LastModified { get; set; }

    //    [ScaffoldColumn(false)]
    //    [StringLength(255)]
    //    public string CreatedById { get; set; }

    //    [ScaffoldColumn(false)]
    //    [StringLength(255)]
    //    public string ModifiedById { get; set; } //User Modify the Entity

    //    [ScaffoldColumn(false)]
    //    public bool IsDeleted { get; set; } = false; //Just mark that record is deleted.
    //}
    #endregion
}
