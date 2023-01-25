using idvProject.Core.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string? NameSurname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
