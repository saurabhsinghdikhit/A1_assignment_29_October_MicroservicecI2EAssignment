using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Student.API.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Data
{
    public class StudentContext : IStudentContext
    {
        public StudentContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Students = database.GetCollection<Entities.Student>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            StudentContextSeed.SeedData(Students);
        }

        public IMongoCollection<Entities.Student> Students { get; }
    }
}
