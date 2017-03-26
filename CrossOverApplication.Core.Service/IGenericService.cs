using CrossOverApplication.Core.Data.Interfaces;

namespace CrossOverApplication.Core.interfaces.Services
{
    public interface IGenericService
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
