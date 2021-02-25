using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.Domain;
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
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<Order, HomeOrderViewModel>()
                    .ForMember(x => x.DateTime, y => y.MapFrom(x => x.DateTime))
                    .ForMember(x => x.ClientName, y => y.MapFrom(x => x.Client.Name))
                    .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.Name));

            });

            _mapper = new Mapper(_config);

        }
    }
}
