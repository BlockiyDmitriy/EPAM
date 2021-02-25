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
using Task5.BLL.Services.Contract;
using Task5.DAL.Entities;
using Task5.DAL.UoW;

namespace Task5.BLL.Services
{
    public class ProductService : AbstructService, IProductService
    {
        public ProductService(IUnitOfWork uOW) : base(uOW)
        {

        }
        public IEnumerable<ProductDTO> Get()
        {
            return UOW.ProductRepository.Get().ProjectTo<ProductDTO>(MapperHelper.Config).ToList();
        }

        public IEnumerable<ProductDTO> Get(Expression<Func<ProductDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<ProductDTO, bool>>, Expression<Func<Product, bool>>>(predicate);
                return MapperHelper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(UOW.ProductRepository.Get(newPredicate)).ToList();
            }
            throw new ArgumentNullException();
        }
        public ProductDTO SingleOrDefault(Expression<Func<ProductDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<ProductDTO, bool>>, Expression<Func<Product, bool>>>(predicate);
                return MapperHelper.Mapper.Map<Product, ProductDTO>(UOW.ProductRepository.SingleOrDefault(newPredicate));
            }
            throw new ArgumentNullException();
        }
        public void Create(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                var product = MapperHelper.Mapper.Map<ProductDTO, Product>(productDTO);
                UOW.ProductRepository.Add(product);
                UOW.Save();
            }
        }

        public void Remove(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                var product = UOW.ProductRepository.SingleOrDefault(x => x.Id == productDTO.Id);
                product.Name = productDTO.Name;
                product.Sum = productDTO.Sum;
                UOW.ProductRepository.Update(product);
                UOW.Save();
            }
        }

        public void Update(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                var product = UOW.ProductRepository.SingleOrDefault(x => x.Id == productDTO.Id);
                UOW.ProductRepository.Remove(product);
                UOW.Save();
            }
        }
        public void Dispose()
        {
            base.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ProductService()
        {
            Dispose(false);
        }
    }
}
