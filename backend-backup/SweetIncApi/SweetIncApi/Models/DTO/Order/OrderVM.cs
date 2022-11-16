using System;

namespace SweetIncApi.Models.DTO.Order
{
    public class OrderVM
    {
        public int Userid { get; set; }
        public DateTime? Datetime { get; set; } = DateTime.Now;
        public int Status { get; set; }
    }
}
