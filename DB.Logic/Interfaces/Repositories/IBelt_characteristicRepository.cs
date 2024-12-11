using DB.Storage.Database;
using DB.Storage.Models;

namespace BD.Logic.Interfaces.Repositories
{
    public interface IBelt_characteristicRepository
    {
        Belt_characteristic Create(DataContext dataContext, Belt_characteristic beltch);

        Belt_characteristic Update(DataContext dataContext, Belt_characteristic beltch);

        void Delete(DataContext dataContext, Guid Id);

        Belt_characteristic GetByID(DataContext dataContext, Guid Id);
    }
}
