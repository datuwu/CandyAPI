namespace SweetIncApi.Models.DTO.Product
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }
        public int CatagoryId { get; set; }
        public int BrandId { get; set; }
    }
}
