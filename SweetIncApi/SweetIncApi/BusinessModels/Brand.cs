using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Originid { get; set; }

        public virtual Origin Origin { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
