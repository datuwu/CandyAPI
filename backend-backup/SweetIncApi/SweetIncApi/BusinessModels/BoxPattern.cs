using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class BoxPattern
    {
        public BoxPattern()
        {
            Boxes = new HashSet<Box>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Box> Boxes { get; set; }
    }
}
