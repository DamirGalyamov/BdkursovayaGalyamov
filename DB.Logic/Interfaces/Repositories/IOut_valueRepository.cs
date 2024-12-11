using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Repositories
{
    public interface IOut_valueRepository
    {
        Out_value Create(DataContext dataContext, Out_value outvalue);

        Out_value Update(DataContext dataContext, Out_value outvalue);

        void Delete(DataContext dataContext, Guid Id);

        Out_value GetByID(DataContext dataContext, Guid Id);
    }
}
