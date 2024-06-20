using ENOMVG_SOF_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_SOF_2023242.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected SchollingDbContext context;
        public Repository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(T _item)
        {
            context.Set<T>().Add(_item);
            context.SaveChanges();
        }

        public void Delete(int _id)
        {
            context.Set<T>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract T Read(int _id);
        public abstract void Update(T _item);
    }
}
