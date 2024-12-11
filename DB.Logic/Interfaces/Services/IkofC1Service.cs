using DB.Logic.DtoModels.Filters;
using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Services
{
    public interface IkofC1Service
    {
        IQueryable<kofC1> GetkofC1Queryable(DataContext dataContext, kofC1FilterDto filter, bool AsNoTraking);
    }
}
