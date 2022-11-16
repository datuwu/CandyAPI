using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class BoxProduct
    {
        public int BoxId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Box Box { get; set; }
        public virtual Product Product { get; set; }
    }
}
