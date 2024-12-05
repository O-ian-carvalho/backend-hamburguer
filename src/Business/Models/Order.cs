using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Models
{
    public class Order : Entity
    {
        public Order()
        {
            CalculateValue();
        }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Value { get; set; }


        public List<Product> Products { get; set; }

        public void CalculateValue()
        {
            Value = 0;
            if(Products == null) return;
            foreach (var item in Products)
            {
                Value += item.Price;
            }
        }
        
       
    }
}
