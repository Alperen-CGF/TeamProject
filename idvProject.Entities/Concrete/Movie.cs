
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class Movie : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public int? Rating { get; set; }
        public int Year { get; set; }
        public int ImdbRate { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
