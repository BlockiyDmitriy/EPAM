using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BLL.Services.Abstruct
{
    public interface IServiceGetFunction<TDTO> where TDTO : class
    {
        IEnumerable<TDTO> Get();

        IEnumerable<TDTO> Get(Expression<Func<TDTO, bool>> predicate);
        TDTO SingleOrDefault(Expression<Func<TDTO, bool>> predicate);
    }
}
