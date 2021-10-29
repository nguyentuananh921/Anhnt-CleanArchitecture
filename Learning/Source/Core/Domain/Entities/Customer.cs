using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://codewithmukesh.com/blog/razor-page-crud-in-aspnet-core/
    /// https://codewithmukesh.com/blog/jquery-datatable-in-aspnet-core/
    /// </summary>
    
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Company { get; set; }      
       
        public string Contact { get; set; }
      
        public DateTime DateOfBirth { get; set; }
    }
}
