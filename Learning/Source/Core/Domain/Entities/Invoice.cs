using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/
    /// </summary>
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            this.InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public TaxType TaxType { get; set; }
        public double Tax { get; set; }
        public double AmountPaid { get; set; }
        public IList<InvoiceItem> InvoiceItems { get; set; }
    }
}
