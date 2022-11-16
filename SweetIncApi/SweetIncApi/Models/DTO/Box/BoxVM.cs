namespace SweetIncApi.Models.DTO.Box
{
    public class BoxVM
    {
        public int? Quantity { get; set; }
        public int? LowerAge { get; set; }
        public int? UpperAge { get; set; }
        public bool? Status { get; set; } = true;
        public int? BoxPatternId { get; set; }
    }
}
