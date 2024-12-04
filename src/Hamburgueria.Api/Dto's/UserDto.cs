using System.ComponentModel.DataAnnotations;

namespace Hamburgueria.Api.Dto_s
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Password { get; set; }
    }

    public class UserPostDto
    {
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
        public string Password { get; set; }
    }
}
