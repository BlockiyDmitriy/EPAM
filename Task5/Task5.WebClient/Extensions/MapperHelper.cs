using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.Domain;
using Task5.WebClient.Models.Order;

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
            _config = new MapperConfiguration(
                cfg => cfg.CreateMap<Order, HomeOrderViewModel>()
            .ForMember(x => x.DateTime, y => y.MapFrom(x => x.DateTime))
            .ForMember(x => x.Client, y => y.MapFrom(x => x.Client))
            .ForMember(x => x.Product, y => y.MapFrom(x => x.Product))
            );
            _mapper = new Mapper(_config);
        }
    }
}