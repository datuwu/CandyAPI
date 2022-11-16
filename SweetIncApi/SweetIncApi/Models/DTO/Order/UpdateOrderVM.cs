using System;

namespace SweetIncApi.Models.DTO.Order
{
    public class UpdateOrderVM
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime? Datetime { get; set; }
        public int Status { get; set; }
    }
}
