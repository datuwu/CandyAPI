using AutoMapper;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Box;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Models.DTO.Brand;
using SweetIncApi.Models.DTO.Catagory;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.Models.DTO.OrderDetail;
using SweetIncApi.Models.DTO.Origin;
using SweetIncApi.Models.DTO.Product;
using SweetIncApi.Models.DTO.Role;
using SweetIncApi.Models.DTO.User;

namespace SweetIncApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateBoxMap();
            CreateBoxPatternMap();
            CreateBoxProductMap();
            CreateBrandMap();
            CreateCatagoryMap();
            CreateOrderMap();
            CreateOrderDetailMap();
            CreateOriginMap();
            CreateProductMap();
            CreateRoleMap();
            CreateUserMap();
        }

        private void CreateBoxMap()
        {
            CreateMap<BoxVM, Box>().ReverseMap();
            CreateMap<UpdateBoxVM, Box>().ReverseMap();
        }
        private void CreateBoxPatternMap()
        {
            CreateMap<BoxPatternVM, BoxPattern>().ReverseMap();
            CreateMap<UpdateBoxPatternVM, BoxPattern>().ReverseMap();
        }
        private void CreateBoxProductMap()
        {
            CreateMap<BoxProductVM, BoxProduct>().ReverseMap();
        }
        private void CreateBrandMap()
        {
            CreateMap<BrandVM, Brand>().ReverseMap();
            CreateMap<UpdateBrandVM, Brand>().ReverseMap();
        }
        private void CreateCatagoryMap()
        {
            CreateMap<CatagoryVM, Catagory>().ReverseMap();
            CreateMap<UpdateCatagoryVM, Catagory>().ReverseMap();
        }
        private void CreateOrderMap()
        {
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<UpdateOrderVM, Order>().ReverseMap();
        }
        private void CreateOrderDetailMap()
        {
            CreateMap<OrderDetailVM, Orderdetail>().ReverseMap();
        }
        private void CreateOriginMap()
        {
            CreateMap<OriginVM, Origin>().ReverseMap();
            CreateMap<UpdateOriginVM, Origin>().ReverseMap();
        }
        private void CreateProductMap()
        {
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<UpdateProductVM, Product>().ReverseMap();
        }
        private void CreateRoleMap()
        {
            CreateMap<RoleVM, Role>().ReverseMap();
            CreateMap<UpdateRoleVM, Role>().ReverseMap();
        }
        private void CreateUserMap()
        {
            CreateMap<UserVM, User>().ReverseMap();
            CreateMap<UpdateUserVM, User>().ReverseMap();
            CreateMap<UserForLogin, User>().ReverseMap();
        } 
    }
}
