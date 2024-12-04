using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Models.Categorization
{
    public class Status : Entity
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
