using DB.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class kofC1Repository : IkofC1Repository
    {
        public kofC1 Create(DataContext dataContext, kofC1 kofC1)
        {
            //kofC1.IsnNode = new Guid();
            dataContext.KofC1s.Add(kofC1);

            return kofC1;

        }

        public kofC1 Update(DataContext dataContext, kofC1 kofC1)
        {
            var kofC1DB = dataContext.KofC1s.FirstOrDefault(x => x.Id == kofC1.Id)
            ?? throw new Exception($"Запись с данным индификатором {kofC1.Id} не найдено");

            kofC1DB.Id = kofC1.Id;
            kofC1DB.alpha1 = kofC1.alpha1;
            kofC1DB.C1 = kofC1.C1;

            return kofC1DB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var kofC1DB = dataContext.KofC1s.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.KofC1s.Remove(kofC1DB);

        }

        public kofC1 GetByID(DataContext dataContext, Guid Id)
        {
            var kofC1DB = dataContext.KofC1s.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return kofC1DB;
        }
    }
}
