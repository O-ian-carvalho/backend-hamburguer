using Hamurgueria.Business.Models.Categorization;
using Hamurgueria.Business.Models;

namespace Hamburgueria.Api.Dto_s
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Value { get; set; }

        public List<Product> Products { get; set; }

    }


    public class OrderPostDto
    {
        public Guid Id { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Value { get; set; }

    }
}
