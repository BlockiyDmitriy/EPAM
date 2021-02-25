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
    public class ClientService : AbstructService, IServiceFunction<ClientDTO>
    {
        public ClientService(UnitOfWork uOW) : base(uOW)
        {

        }
        public IEnumerable<ClientDTO> Get()
        {
            return UOW.ClientRepository.Get().ProjectTo<ClientDTO>(MapperHelper.Config).ToList();
        }

        public IEnumerable<ClientDTO> Get(Expression<Func<ClientDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<ClientDTO, bool>>, Expression<Func<Client, bool>>>(predicate);
                return MapperHelper.Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(UOW.ClientRepository.Get(newPredicate)).ToList();
            }
            throw new ArgumentNullException();
        }
        public ClientDTO SingleOrDefault(Expression<Func<ClientDTO, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate = MapperHelper.Mapper.Map<Expression<Func<ClientDTO, bool>>, Expression<Func<Client, bool>>>(predicate);
                return MapperHelper.Mapper.Map<Client, ClientDTO>(UOW.ClientRepository.SingleOrDefault(newPredicate));
            }
            throw new ArgumentNullException();
        }
        public void Create(ClientDTO clientDTO)
        {
            if (clientDTO != null)
            {
                var client = MapperHelper.Mapper.Map<ClientDTO, Order>(clientDTO);
                UOW.OrderRepository.Add(client);
                UOW.Save();
            }
        }

        public void Remove(ClientDTO clientDTO)
        {
            if (clientDTO != null)
            {
                var client = UOW.OrderRepository.SingleOrDefault(x => x.Id == clientDTO.Id);
                UOW.OrderRepository.Update(client);
                UOW.Save();
            }
        }

        public void Update(ClientDTO clientDTO)
        {
            if (clientDTO != null)
            {
                var client = UOW.OrderRepository.SingleOrDefault(x => x.Id == clientDTO.Id);
                UOW.OrderRepository.Remove(client);
                UOW.Save();
            }
        }
        public void Dispose()
        {
            base.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ClientService()
        {
            Dispose(false);
        }
    }
}
