using DB.Logic.DtoModels.Filters;
using DB.Logic.Interfaces.Services;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class kofC1Service : IkofC1Service
    {
        public IQueryable<kofC1> GetkofC1Queryable(DataContext dataContext, kofC1FilterDto filter, bool AsNoTraking)
        {
            IQueryable<kofC1> query = dataContext.KofC1s;

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
