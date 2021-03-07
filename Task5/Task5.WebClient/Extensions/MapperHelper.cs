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
                cfg.CreateMap<ClientDTO, ClientViewModel>();
                cfg.CreateMap<ProductDTO, ProductViewModel>();
                cfg.CreateMap<OrderDTO, HomeOrderViewModel>()
                .ForPath(x => x.Client.Name, y => y.MapFrom(x => x.Client))
                .ForPath(x => x.Product.Name, y => y.MapFrom(x => x.Product));

                cfg.CreateMap<CreateOrderViewModel, OrderDTO>();

            });

            _mapper = new Mapper(_config);

        }
    }
}
