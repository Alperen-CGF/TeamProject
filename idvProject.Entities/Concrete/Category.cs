
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class Category : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set;}
    }
}
