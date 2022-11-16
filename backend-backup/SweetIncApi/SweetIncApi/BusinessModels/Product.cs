using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Product
    {
        public Product()
        {
            BoxProducts = new HashSet<BoxProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }
        public int CatagoryId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Catagory Catagory { get; set; }
        public virtual ICollection<BoxProduct> BoxProducts { get; set; }
    }
}
