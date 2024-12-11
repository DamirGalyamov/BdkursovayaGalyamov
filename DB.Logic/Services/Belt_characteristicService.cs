using BD.Logic.Interfaces.Services;
using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Services
{
    public class Belt_characteristicService : IBelt_characteristicService
    {
        public IQueryable<Belt_characteristic> GetBelt_characteristicQueryable(DataContext dataContext, Belt_characteristicFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Belt_characteristic> query = dataContext.Belt_Characteristics;

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
