using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Services
{
    public interface ISig0Service
    {
        IQueryable<Sig0> GetSig0Queryable(DataContext dataContext, Sig0FilterDto filter, bool AsNoTraking);
    }
}
