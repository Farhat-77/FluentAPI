using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Models
{
    public class Dish : Entity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
