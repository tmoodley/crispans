using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class Material
    {
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
    }
}
