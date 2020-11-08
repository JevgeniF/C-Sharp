using System;
using DAL;

namespace DBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var db = new AppDbContext();
            foreach (var student in db.Students)
            {
                Console.WriteLine(student);
            }
        }
    }
}