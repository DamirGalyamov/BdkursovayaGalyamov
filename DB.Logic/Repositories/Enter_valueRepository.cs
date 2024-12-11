using DB.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class Enter_valueRepository : IEnter_valueRepository
    {
        public Enter_value Create(DataContext dataContext, Enter_value entervalue)
        {
            //Enter_value.IsnNode = new Guid();
            dataContext.Enter_Values.Add(entervalue);

            return entervalue;

        }

        public Enter_value Update(DataContext dataContext, Enter_value Enter_value)
        {
            var Enter_valueDB = dataContext.Enter_Values.FirstOrDefault(x => x.Id == Enter_value.Id)
            ?? throw new Exception($"Запись с данным индификатором {Enter_value.Id} не найдено");

            Enter_valueDB.Id = Enter_value.Id;
            Enter_valueDB.belt_type = Enter_value.profile_type;
            Enter_valueDB.profile_type = Enter_value.profile_type;
            Enter_valueDB.Z = Enter_value.Z;
            Enter_valueDB.C3 = Enter_value.C3;
            Enter_valueDB.F = Enter_value.F;
            Enter_valueDB.xi = Enter_value.xi;
            Enter_valueDB.alpha1 = Enter_value.alpha1;

            return Enter_valueDB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var Enter_valueDB = dataContext.Enter_Values.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Enter_Values.Remove(Enter_valueDB);

        }

        public Enter_value GetByID(DataContext dataContext, Guid Id)
        {
            var Enter_valueDB = dataContext.Enter_Values.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return Enter_valueDB;
        }
    }
}
