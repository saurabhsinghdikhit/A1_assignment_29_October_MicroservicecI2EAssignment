using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Data
{
    public class StudentContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Student> studentCollection)
        {
            bool existStudent = studentCollection.Find(p => true).Any();
            if (!existStudent)
            {
                studentCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        private static IEnumerable<Entities.Student> GetPreconfiguredProducts()
        {
            return new List<Entities.Student>()
            {
                new Entities.Student()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    FirstName = "Saurabh singh dikhit",
                    LastName = "Dikhit",
                    Mobile = "9621221615",
                    Email = "ss520553@gmail.com",
                    Avatar = "image1.png"
                },
                new Entities.Student()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    FirstName = "Ram singh",
                    LastName = "Dikhit",
                    Mobile = "9621221515",
                    Email = "ramdikhit@gmail.com",
                    Avatar = "image2.png"
                },
                new Entities.Student()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    FirstName = "Shyam singh",
                    LastName = "Dikhit",
                    Mobile = "9656221515",
                    Email = "shyamdikhit@gmail.com",
                    Avatar = "image3.png"
                },
                new Entities.Student()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    FirstName = "Maan singh",
                    LastName = "Dikhit",
                    Mobile = "9678221515",
                    Email = "shyamdikhit@gmail.com",
                    Avatar = "image4.png"
                }
            };
        }
    }
}
