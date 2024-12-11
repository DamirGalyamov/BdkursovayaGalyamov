using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Repositories
{
    public interface IPhi0Repository
    {
        Phi0 Create(DataContext dataContext, Phi0 phi0);

        Phi0 Update(DataContext dataContext, Phi0 phi0);

        void Delete(DataContext dataContext, Guid EnterId);

        Phi0 GetByID(DataContext dataContext, Guid EnterId);
    }
}
