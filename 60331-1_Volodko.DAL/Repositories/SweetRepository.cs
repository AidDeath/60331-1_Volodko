using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace _60331_1_Volodko.DAL.Repositories
{
    public class SweetRepository : IRepository<Sweet>
    {
        private ApplicationDbContext context;
        private DbSet<Sweet> table;
        public SweetRepository(ApplicationDbContext context, DbSet<Sweet> table)
        {
            this.context = context;
            this.table = table;
        }
        public IEnumerable<Sweet> GetAll()
        {
            return table
                .Include(sweet => sweet.Manufacturer.City)
                .Include(sweet => sweet.Category);
        }

        public Sweet Get(int id)
        {
            return table
                .Include(sweet => sweet.Manufacturer.City)
                .Include(sweet => sweet.Category)
                .FirstOrDefault(sweet => sweet.SweetId == id);
        }

        public Task<Sweet> GetAsync(int id)
        {
            return context.Sweets.FindAsync(id);
        }

        public IEnumerable<Sweet> Find(Func<Sweet, bool> predicate)
        {
            return table
                .Include(sweet => sweet.Manufacturer.City)
                .Include(sweet => sweet.Category).AsEnumerable()
                .Where(predicate)
                .ToList();
        }

        public void Create(Sweet t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Update(Sweet t)
        {
            // если изображение не загружено,
            // то использовать изображение из базы данных
            if (t.Image == null)
            {
                var car = context.Sweets
                    .AsNoTracking()
                    .FirstOrDefault(ct => ct.SweetId == t.SweetId);
                t.Image = car.Image;
                t.MimeType = car.MimeType;
            }
            context.Entry<Sweet>(t).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
                .Entry(new Car { CarId = id })
                .State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
