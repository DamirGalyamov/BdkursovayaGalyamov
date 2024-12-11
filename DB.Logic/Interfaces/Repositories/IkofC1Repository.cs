using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Repositories
{
    public interface IkofC1Repository
    {
        kofC1 Create(DataContext dataContext, kofC1 kofc1);

        kofC1 Update(DataContext dataContext, kofC1 kofc1);

        void Delete(DataContext dataContext, Guid Id);

        kofC1 GetByID(DataContext dataContext, Guid Id);
    }
}
