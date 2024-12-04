using System.ComponentModel.DataAnnotations;

namespace Hamburgueria.Api.Dto_s
{
    public class CategorieDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Description { get; set; }
    }

    public class CategoriePostDto
    {
        
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string PathImage { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Description { get; set; }
    }
}
