using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public decimal Price { set; get; }

    }
}
