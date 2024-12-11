using DB.Logic.Interfaces.Repositories;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Logic.Repositories
{
    public class Out_valueRepository : IOut_valueRepository
    {
        public Out_value Create(DataContext dataContext, Out_value Out_value)
        {
            //Out_value.IsnNode = new Guid();
            dataContext.Out_Values.Add(Out_value);

            return Out_value;

        }

        public Out_value Update(DataContext dataContext, Out_value Out_value)
        {
            var Out_valueDB = dataContext.Out_Values.FirstOrDefault(x => x.Id == Out_value.Id)
            ?? throw new Exception($"Запись с данным индификатором {Out_value.Id} не найдено");

            Out_valueDB.Id = Out_value.Id;
            Out_valueDB.Enter_valuesId = Out_value.Enter_valuesId;
            Out_valueDB.sigma0 = Out_value.sigma0;
            Out_valueDB.Q0 = Out_value.Q0;
            Out_valueDB.R = Out_value.R;
            Out_valueDB.teta = Out_value.teta;


            return Out_valueDB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var Out_valueDB = dataContext.Out_Values.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Out_Values.Remove(Out_valueDB);

        }

        public Out_value GetByID(DataContext dataContext, Guid Id)
        {
            var Out_valueDB = dataContext.Out_Values.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return Out_valueDB;
        }
    }
}
