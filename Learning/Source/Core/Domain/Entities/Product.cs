using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>    
    /// https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
    /// https://codewithmukesh.com/blog/cqrs-in-aspnet-core-3-1/
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }        
        public string Barcode { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }       
        public decimal BuyingPrice { get; set; }
        public string ConfidentialData { get; set; }
    }
}
