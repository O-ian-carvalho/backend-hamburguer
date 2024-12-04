using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Models
{
    public class User : Entity
    {
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Password { get; set; }


        public List<Order> Orders { get; set; }
    }
}
