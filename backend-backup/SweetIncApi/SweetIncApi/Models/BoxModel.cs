using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.Models
{
    public class BoxModel
    {  

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? LowerAge { get; set; }
        public int? UpperAge { get; set; }

    }
}
