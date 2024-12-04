
using System.ComponentModel.DataAnnotations;

namespace Hamburgueria.Api.Dto_s
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        public decimal Price { get; set; }
        public string BaseDescription { get; set; }
        public string FullDescription { get; set; }
        public Guid CategorieId { get; set; }
        public Guid? OrderId { get; set; }
       
    }

    public class ProductPostDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        public decimal Price { get; set; }
        public string BaseDescription { get; set; }
        public string FullDescription { get; set; }
        public Guid CategorieId { get; set; }
        public Guid? OrderId { get; set; }

    }
}
