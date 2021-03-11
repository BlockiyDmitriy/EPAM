using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.BLL.DTO;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Order;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Extensions
{
    public static class MapperHelper
    {
        private static MapperConfiguration _config;
        private static Mapper _mapper;

        public static Mapper Mapper => _mapper;

        public static MapperConfiguration Config => _config;


        public static void MapperConfig()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDTO, ClientViewModel>().ReverseMap();
                cfg.CreateMap<ClientDTO, EditClientViewModel>().ReverseMap();

                cfg.CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
                cfg.CreateMap<ProductDTO, EditProductViewModel>().ReverseMap();

                cfg.CreateMap<OrderDTO, HomeOrderViewModel>()
                .ForPath(x => x.Client.Name, y => y.MapFrom(x => x.Client.Name))
                .ForPath(x => x.Product.Name, y => y.MapFrom(x => x.Product.Name));
                cfg.CreateMap<OrderDTO, DetailsOrderViewModel>()
                .ForPath(x => x.Client.Name, y => y.MapFrom(x => x.Client.Name))
                .ForPath(x => x.Product.Name, y => y.MapFrom(x => x.Product.Name))
                .ForPath(x => x.Product.Sum, y => y.MapFrom(x => x.Product.Sum));
                cfg.CreateMap<OrderDTO, EditOrderViewModel>()
                .ForMember(x => x.ClientName, y => y.MapFrom(x => x.Client.Name))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.Name))
                .ForMember(x => x.Sum, y => y.MapFrom(x => x.Product.Sum));


                cfg.CreateMap<ClientViewModel, ClientDTO>();
                cfg.CreateMap<CreateClientViewModel, ClientDTO>();
                cfg.CreateMap<CreateProductViewModel, ProductDTO>();

                cfg.CreateMap<CreateOrderViewModel, OrderDTO>();
                cfg.CreateMap<HomeOrderViewModel, OrderDTO>()
                .ForPath(x => x.Client.Name, y => y.MapFrom(x => x.Client.Name))
                .ForPath(x => x.Product.Name, y => y.MapFrom(x => x.Product.Name));
                cfg.CreateMap<EditOrderViewModel, OrderDTO>()
                .ForPath(x => x.Client.Name, y => y.MapFrom(x => x.ClientName))
                .ForPath(x => x.Product.Name, y => y.MapFrom(x => x.ProductName))
                .ForPath(x => x.Product.Sum, y => y.MapFrom(x => x.Sum));
            });

            _mapper = new Mapper(_config);

        }
    }
}
