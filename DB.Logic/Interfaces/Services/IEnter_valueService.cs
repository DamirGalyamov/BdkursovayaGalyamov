using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace BD.Logic.Interfaces.Services
{
    public interface IEnter_valueService
    {
        IQueryable<Enter_value> GetEnter_valueQueryable(DataContext dataContext, Enter_valueFilterDto filter, bool AsNoTraking);
    }
}
