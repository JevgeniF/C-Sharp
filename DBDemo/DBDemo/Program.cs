using System;
using System.Linq;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var db = new AppDbContext();

            db.Database.EnsureDeleted();
            
            db.Database.Migrate();

            var grade = new Grade()
            {
                GradeValue = 5,
                Student = new Student()
                {
                    FirstName = "Jevgeni",
                    LastName = "Fenko",
                },
                Homework = new Homework()
                {
                    Description = "Battleships work!"
                }
            };
            Console.WriteLine(grade);
            
            db.Grades.Add(grade);
            db.SaveChanges();
            
            Console.WriteLine(grade);

            foreach (var dbGrade in db.Grades
                .Include(g => g.Student)
                .Include(g => g.Homework)
                .Where(g => g.GradeId > 2 && g.GradeId < 5)
                .OrderByDescending(g => g.GradeId))
            {
                Console.WriteLine(dbGrade);
            }
        }
    }
}