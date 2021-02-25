using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BLL.DTO;
using Task5.BLL.Services.Abstruct;

namespace Task5.BLL.Services.Contract
{
    public interface IOrderService : IServiceFunction<OrderDTO>
    {
    }
}
