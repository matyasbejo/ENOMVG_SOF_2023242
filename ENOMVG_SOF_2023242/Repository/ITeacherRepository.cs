using ENOMVG_SOF_2023242.Models;

namespace ENOMVG_SOF_2023242.Repository
{
    public interface ITeacherRepository
    {
        void Create(Teacher _item);
        void Delete(int _id);
        Teacher Read(int _id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher _item);
    }
}