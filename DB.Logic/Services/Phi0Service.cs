using DB.Logic.DtoModels.Filters;
using DB.Logic.Interfaces.Services;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class Phi0Service : IPhi0Service
    {
        public IQueryable<Phi0> GetPhi0Queryable(DataContext dataContext, Phi0FilterDto filter, bool AsNoTraking)
        {
            IQueryable<Phi0> query = dataContext.Phi0s;

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
