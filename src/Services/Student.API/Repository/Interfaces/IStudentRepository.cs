using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.API.Entities;

namespace Student.API.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Entities.Student>> GetStudents();
        Task<Entities.Student> GetStudent(string id);
        Task<IEnumerable<Entities.Student>> GetStudentByName(string name);
        Task<IEnumerable<Entities.Student>> GetStudentByMobile(string mobile);

        Task CreateStudent(Entities.Student student);
        Task<bool> UpdateStudent(Entities.Student student);
        Task<bool> DeleteStudent(string id);
    }
}
