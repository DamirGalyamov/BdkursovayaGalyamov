using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Repositories
{
    public interface IEnter_valueRepository
    {
        Enter_value Create(DataContext dataContext, Enter_value entervalue);

        Enter_value Update(DataContext dataContext, Enter_value entervalue);

        void Delete(DataContext dataContext, Guid Id);

        Enter_value GetByID(DataContext dataContext, Guid Id);

    }
}
