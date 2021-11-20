using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Data.Interfaces
{
    public interface IStudentContext
    {
        IMongoCollection<Entities.Student> Students { get; }
    }
}
