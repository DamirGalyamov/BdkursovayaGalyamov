using DB.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class Phi0Repository : IPhi0Repository
    {
        public Phi0 Create(DataContext dataContext, Phi0 Phi0)
        {
            //Phi0.IsnNode = new Guid();
            dataContext.Phi0s.Add(Phi0);

            return Phi0;

        }

        public Phi0 Update(DataContext dataContext, Phi0 Phi0)
        {
            var Phi0DB = dataContext.Phi0s.FirstOrDefault(x => x.Enter_ValueId == Phi0.Enter_ValueId)
            ?? throw new Exception($"Запись с данным индификатором {Phi0.Enter_ValueId} не найдено");

            Phi0DB.Id = Phi0.Id;
            Phi0DB.Enter_ValueId = Phi0.Enter_ValueId;
            Phi0DB.enter_phi0 = Phi0.enter_phi0;

            return Phi0DB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var Phi0DB = dataContext.Phi0s.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Phi0s.Remove(Phi0DB);

        }

        public Phi0 GetByID(DataContext dataContext, Guid Id)
        {
            var Phi0DB = dataContext.Phi0s.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return Phi0DB;
        }
    }
}
