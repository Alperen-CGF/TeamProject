using idvProject.Core.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
