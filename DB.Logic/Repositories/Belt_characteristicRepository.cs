using BD.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class Belt_characteristicRepository : IBelt_characteristicRepository
    {
        public Belt_characteristic Create(DataContext dataContext, Belt_characteristic Belt_characteristic)
        {
            //Belt_characteristic.IsnNode = new Guid();
            dataContext.Belt_Characteristics.Add(Belt_characteristic);

            return Belt_characteristic;

        }

        public Belt_characteristic Update(DataContext dataContext, Belt_characteristic Belt_characteristic)
        {
            var Belt_characteristicDB = dataContext.Belt_Characteristics.FirstOrDefault(x => x.Id == Belt_characteristic.Id)
            ?? throw new Exception($"Запись с данным индификатором {Belt_characteristic.Id} не найдено");

            Belt_characteristicDB.Id = Belt_characteristic.Id;
            Belt_characteristicDB.profile_type = Belt_characteristic.profile_type;
            Belt_characteristicDB.sectional_area = Belt_characteristic.sectional_area;
            Belt_characteristicDB.Loginlinear_density = Belt_characteristic.Loginlinear_density;

            return Belt_characteristicDB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var Belt_characteristicDB = dataContext.Belt_Characteristics.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Belt_Characteristics.Remove(Belt_characteristicDB);

        }

        public Belt_characteristic GetByID(DataContext dataContext, Guid Id)
        {
            var Belt_characteristicDB = dataContext.Belt_Characteristics.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return Belt_characteristicDB;
        }
    }
}
