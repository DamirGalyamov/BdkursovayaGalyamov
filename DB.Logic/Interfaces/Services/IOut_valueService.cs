using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Services
{
    public interface IOut_valueService
    {
        IQueryable<Out_value> GetOut_valueQueryable(DataContext dataContext, Out_valueFilterDto filter, bool AsNoTraking);
    }
}
