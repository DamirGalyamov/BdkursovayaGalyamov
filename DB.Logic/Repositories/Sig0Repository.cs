using DB.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class Sig0Repository : ISig0Repository
    {
        public Sig0 Create(DataContext dataContext, Sig0 Sig0)
        {
            //Sig0.IsnNode = new Guid();
            dataContext.Sig0s.Add(Sig0);

            return Sig0;

        }

        public Sig0 Update(DataContext dataContext, Sig0 Sig0)
        {
            var Sig0DB = dataContext.Sig0s.FirstOrDefault(x => x.Id == Sig0.Id)
            ?? throw new Exception($"Запись с данным индификатором {Sig0.Enter_ValueId} не найдено");

            Sig0DB.Id = Sig0.Id;
            Sig0DB.Enter_ValueId = Sig0.Enter_ValueId;
            Sig0DB.enter_sig0 = Sig0.enter_sig0;

            return Sig0DB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var Sig0DB = dataContext.Sig0s.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Sig0s.Remove(Sig0DB);

        }

        public Sig0 GetByID(DataContext dataContext, Guid Id)
        {
            var Sig0DB = dataContext.Sig0s.AsNoTracking().FirstOrDefault(x => x.Enter_ValueId == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return Sig0DB;
        }
    }
}
