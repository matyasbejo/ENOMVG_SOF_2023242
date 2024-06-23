using ENOMVG_SOF_2023242.Models;

namespace ENOMVG_SOF_2023242.Repository
{
    public interface ISchoolRepository
    {
        void Create(School _item);
        void Delete(int _id);
        School Read(int _id);
        School Read(string name);
        IQueryable<School> ReadAll();
        void Update(School _item);
    }
}