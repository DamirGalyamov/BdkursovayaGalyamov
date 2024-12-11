using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Services
{
    public interface IPhi0Service
    {
        IQueryable<Phi0> GetPhi0Queryable(DataContext dataContext, Phi0FilterDto filter, bool AsNoTraking);
    }
}
