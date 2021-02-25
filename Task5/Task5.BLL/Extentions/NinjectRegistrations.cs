using Ninject.Modules;
using Task5.DAL.UoW;

namespace Task5.BLL.Extentions
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
