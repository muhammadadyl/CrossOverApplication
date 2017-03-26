using CrossOverApplication.Core.Data.Interfaces;

namespace CrossOverApplication.Core.Interfaces.Services
{
    public interface IGenericService
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
