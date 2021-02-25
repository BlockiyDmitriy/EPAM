using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Entities;

namespace Task5.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
