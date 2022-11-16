using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Orderdetail
    {
        public int Id { get; set; }
        public int Boxid { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Box Box { get; set; }
        public virtual Order IdNavigation { get; set; }
    }
}
