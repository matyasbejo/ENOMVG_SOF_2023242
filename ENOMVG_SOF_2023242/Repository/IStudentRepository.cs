using ENOMVG_SOF_2023242.Models;

namespace ENOMVG_SOF_2023242.Repository
{
    public interface IStudentRepository
    {
        void Create(Student _item);
        void Delete(int _id);
        Student Read(int _id);
        IQueryable<Student> ReadAll();
        void Update(Student _item);
    }
}