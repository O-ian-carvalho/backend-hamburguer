using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Models
{
    public class Product : Entity
    {
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        public decimal Price { get; set; }
        public string BaseDescription { get; set; }
        public string FullDescription { get; set; }


        public Guid CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public List<Order> Orders { get; set; }

    }
}
