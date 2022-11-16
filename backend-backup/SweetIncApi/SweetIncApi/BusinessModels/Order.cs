using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime? Datetime { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
