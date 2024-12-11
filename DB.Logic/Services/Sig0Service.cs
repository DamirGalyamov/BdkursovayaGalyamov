using DB.Logic.DtoModels.Filters;
using DB.Logic.Interfaces.Services;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class Sig0Service : ISig0Service
    {
        public IQueryable<Sig0> GetSig0Queryable(DataContext dataContext, Sig0FilterDto filter, bool AsNoTraking)
        {
            IQueryable<Sig0> query = dataContext.Sig0s;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.Id);
            }
            return query;
        }
    }
}
