using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relationships
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
