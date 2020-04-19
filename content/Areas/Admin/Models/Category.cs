using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class Category
    {
        // Primary Id
        public Guid Id { get; set; }

        // Foreign key relationship to parent category    
        public Guid? ParentId { get; set; }

        // Navigation property to parent category    
        public virtual Category Parent { get; set; }

        // Navigation property to child categories    
        public virtual ICollection<Category> Children { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<CustomerCategory> CustomerCategories { get; set; }
        public ICollection<JobCategory> JobCategories { get; set; }
        public ICollection<PurchaseOrderCategory> PurchaseOrderCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
