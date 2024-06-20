using ENOMVG_SOF_2023242.Data;
using ENOMVG_SOF_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ENOMVG_SOF_2023242.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        protected SchollingDbContext context;
        public SchoolRepository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(School _item)
        {
            context.Set<School>().Add(_item);
            context.SaveChanges();
        }

        public void Delete(int _id)
        {
            context.Set<School>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<School> ReadAll()
        {
            return context.Set<School>();
        }
        public School Read(int _id)
        {
            return this.context.Schools.First(x => x.Id == _id);
        }

        public void Update(School _item)
        {
            var old = Read(_item.Id);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(_item));
            }
            context.SaveChanges();
        }
    }
}
