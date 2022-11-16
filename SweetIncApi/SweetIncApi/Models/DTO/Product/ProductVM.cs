namespace SweetIncApi.Models.DTO.Product
{
    public class ProductVM
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; } = true;
        public string Image { get; set; }
        public int CatagoryId { get; set; }
        public int BrandId { get; set; }
    }
}
