using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _60331_1_Volodko.DAL
{
    public class EFCarRepository : IRepository<Car>
    {
        private ApplicationDbContext context;
        private DbSet<Car> table;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public EFCarRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Cars;
        }
        public void Create(Car c)
        {
            table.Add(c);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context
            .Entry(new Car { CarId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }
        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }
        public Car Get(int id)
        {
            return table.Find(id);
        }
        public IEnumerable<Car> GetAll()
        {
            return table;
        }
        public Task<Car> GetAsync(int id)
        {
            return context.Cars.FindAsync(id);
        }

        public void Update(Car c)
        {
            // если изображение не загружено,
            // то использовать изображение из базы данных
            if (c.Image==null)
            {
                var car = context.Cars
                    .AsNoTracking()
                    .Where(ct => ct.CarId == c.CarId)
                    .FirstOrDefault();
                c.Image = car.Image;
                c.MimeType = car.MimeType;
            }
            context.Entry<Car>(c).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
