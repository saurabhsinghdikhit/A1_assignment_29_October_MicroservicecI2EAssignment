using MongoDB.Driver;
using Student.API.Data.Interfaces;
using Student.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IStudentContext _context;
        public StudentRepository(IStudentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateStudent(Entities.Student student)
        {
            await _context.Students.InsertOneAsync(student);
        }

        public async Task<bool> DeleteStudent(string id)
        {
            FilterDefinition<Entities.Student> filter = Builders<Entities.Student>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Students.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Entities.Student> GetStudent(string id)
        {
            return await _context.Students.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Student>> GetStudentByMobile(string mobile)
        {
            FilterDefinition<Entities.Student> filter = Builders<Entities.Student>.Filter.Eq(p => p.Mobile, mobile);
            return await _context.Students.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Student>> GetStudentByName(string name)
        {
            FilterDefinition<Entities.Student> filter = Builders<Entities.Student>.Filter.ElemMatch(p => p.FirstName, name);
            return await _context.Students.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Student>> GetStudents()
        {
            return await _context.Students.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateStudent(Entities.Student student)
        {
            var updateResult = await _context.Students.ReplaceOneAsync(filter: g => g.Id == student.Id, replacement: student);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
