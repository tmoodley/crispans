using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace HelpingHands.Models
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Notes { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }     
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public List<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public bool isNda { get; set; }
        public Guid TermsDocumentId { get; set; }
        public Guid NdaDocumentId { get; set; }
        public Guid ContractDocumentId { get; set; }
        public Guid CadFileDocumentId { get; set; }
        public ICollection<PurchaseOrderCategory> PurchaseOrderCategories { get; set; }
    }
}
