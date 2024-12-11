using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace BD.Logic.Interfaces.Services
{
    public interface IBelt_characteristicService
    {
        IQueryable<Belt_characteristic> GetBelt_characteristicQueryable(DataContext dataContext, Belt_characteristicFilterDto filter, bool AsNoTraking);
    }
}