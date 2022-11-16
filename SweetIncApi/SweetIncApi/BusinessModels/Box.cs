using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Box
    {
        public Box()
        {
            BoxProducts = new HashSet<BoxProduct>();
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? LowerAge { get; set; }
        public int? UpperAge { get; set; }
        public bool? Status { get; set; }
        public int? BoxPatternId { get; set; }

        public virtual BoxPattern BoxPattern { get; set; }
        public virtual ICollection<BoxProduct> BoxProducts { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
