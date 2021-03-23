using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
