using DB.Logic.DtoModels.Filters;
using DB.Logic.Interfaces.Services;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class Out_valueService : IOut_valueService
    {
        public IQueryable<Out_value> GetOut_valueQueryable(DataContext dataContext, Out_valueFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Out_value> query = dataContext.Out_Values;

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
