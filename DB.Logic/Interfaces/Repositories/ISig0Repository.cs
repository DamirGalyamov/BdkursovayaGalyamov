using DB.Storage.Database;
using DB.Storage.Models;

namespace DB.Logic.Interfaces.Repositories
{
    public interface ISig0Repository
    {
        Sig0 Create(DataContext dataContext, Sig0 sig0);
        Sig0 Update(DataContext dataContext, Sig0 sig0);
        void Delete(DataContext dataContext, Guid EnterId);

        Sig0 GetByID(DataContext dataContext, Guid EnterId);
    }
}
