using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Origin
    {
        public Origin()
        {
            Brands = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
