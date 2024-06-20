using ENOMVG_SOF_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_SOF_2023242.Repository
{
    public class SchoolRepository : Repository<School>, IRepository<School>
    {
        public SchoolRepository(SchollingDbContext _ctx) : base(_ctx)
        {

        }
        public override School Read(int _id)
        {
            return this.context.Schools.First(x => x.Id == _id);
        }

        public override void Update(School _item)
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
