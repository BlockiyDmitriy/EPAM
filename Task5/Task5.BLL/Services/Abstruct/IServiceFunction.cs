using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BLL.Services.Abstruct
{
    public interface IServiceFunction<TDTO> where TDTO : class
    {
        void Create(TDTO tDTO);
        void Update(TDTO tDTO);
        void Remove(TDTO tDTO);
    }
}
