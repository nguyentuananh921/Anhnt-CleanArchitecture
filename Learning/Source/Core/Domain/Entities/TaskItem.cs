using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://www.youtube.com/watch?v=liyhZW22WmQ&lc=UgwtXr4ghuC3wBsZYZ14AaABAg.9P0tGh3Ooul9P6a9S6z8FM
    /// https://github.com/itsdevkev/TaskList
    /// public class TaskItem : BaseEntity //For Audit
    /// </summary>    
    public class TaskItem    
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        [Display(Name = "Is completed?")]
        public bool IsCompleted { get; set; } = false;
    }
}
