namespace SweetIncApi.Models.DTO.BoxPattern
{
    public class UpdateBoxPatternVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; }
        public int Price { get; set; }
    }
}
