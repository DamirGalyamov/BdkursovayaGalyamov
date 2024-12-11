using BD.Logic.Interfaces.Services;
using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class Enter_valueService : IEnter_valueService
    {
        public IQueryable<Enter_value> GetEnter_valueQueryable(DataContext dataContext, Enter_valueFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Enter_value> query = dataContext.Enter_Values;

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
