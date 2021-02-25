using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.BLL.DTO;
using Task5.BLL.Extentions;
using Task5.BLL.Services.Abstruct;
using Task5.DAL.Entities;
using Task5.DAL.UoW;

namespace Task5.BLL.Services
{
    public class OrderService : AbstructService, IServiceFunction<OrderDTO>
    {
        public OrderService(UnitOfWork uOW) : base(uOW)
        {

        }
        public IEnumerable<OrderDTO> Get()
        {
            return UOW.ProductRepository.Get().ProjectTo<OrderDTO>(MapperHelper.Config).ToList();
        }

        public IEnumerable<OrderDTO> Get(Expression<Func<OrderDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<OrderDTO, bool>>, Expression<Func<Product, bool>>>(predicate);
                return MapperHelper.Mapper.Map<IEnumerable<Product>, IEnumerable<OrderDTO>>(UOW.ProductRepository.Get(newPredicate)).ToList();
            }
            throw new ArgumentNullException();
        }
        public OrderDTO SingleOrDefault(Expression<Func<OrderDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<OrderDTO, bool>>, Expression<Func<Product, bool>>>(predicate);
                return MapperHelper.Mapper.Map<Product, OrderDTO>(UOW.ProductRepository.SingleOrDefault(newPredicate));
            }
            throw new ArgumentNullException();
        }
        public void Create(OrderDTO OrderDTO)
        {
            if (OrderDTO != null)
            {
                var order = MapperHelper.Mapper.Map<OrderDTO, Order>(OrderDTO);
                UOW.OrderRepository.Add(order);
                UOW.Save();
            }
        }

        public void Remove(OrderDTO OrderDTO)
        {
            if (OrderDTO != null)
            {
                var order = UOW.OrderRepository.SingleOrDefault(x => x.Id == OrderDTO.Id);
                order.ClientId = OrderDTO.ClientId;
                order.ProductId= OrderDTO.ProductId;
                UOW.OrderRepository.Update(order);
                UOW.Save();
            }
        }

        public void Update(OrderDTO OrderDTO)
        {
            if (OrderDTO != null)
            {
                var order = UOW.OrderRepository.SingleOrDefault(x => x.Id == OrderDTO.Id);
                UOW.OrderRepository.Remove(order);
                UOW.Save();
            }
        }
        public void Dispose()
        {
            base.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~OrderService()
        {
            Dispose(false);
        }
    }
}
