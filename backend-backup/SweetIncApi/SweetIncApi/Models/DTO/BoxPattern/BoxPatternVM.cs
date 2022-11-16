namespace SweetIncApi.Models.DTO.BoxPattern
{
    public class BoxPatternVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; } = true;
        public int Price { get; set; }
    }
}