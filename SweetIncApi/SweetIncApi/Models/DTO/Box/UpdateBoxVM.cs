namespace SweetIncApi.Models.DTO.Box
{
    public class UpdateBoxVM
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? LowerAge { get; set; }
        public int? UpperAge { get; set; }
        public bool? Status { get; set; }
        public int? BoxPatternId { get; set; }
    }
}
