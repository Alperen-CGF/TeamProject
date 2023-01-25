using idvProject.Core.Abstract;
using idvProject.Core.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class Actor : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string NameSurname { get; set; }
        public string? ImagePath { get; set; }
    }
}
