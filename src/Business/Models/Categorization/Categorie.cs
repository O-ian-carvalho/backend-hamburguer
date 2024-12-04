using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Models.Categorization
{
    public class Categorie : Entity
    {
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Description { get; set; }


        public List<Product> Products { get; set; }
    }
}
