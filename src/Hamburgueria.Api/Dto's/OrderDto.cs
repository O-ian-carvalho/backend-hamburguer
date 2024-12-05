using Hamurgueria.Business.Models.Categorization;
using Hamurgueria.Business.Models;

namespace Hamburgueria.Api.Dto_s
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid StatusId { get; set; }
        public Guid UserId { get; set; }
        public decimal Value { get; set; }

    }


    public class OrderPostDto
    {
        public Guid StatusId { get; set; }
        public Guid UserId { get; set; }

    }
}
