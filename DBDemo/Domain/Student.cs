using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        
        [MaxLength(120)]
        public string FirstName { get; set; } = null!;
        [MaxLength(120)]
        public string LastName { get; set; } = null!;
        
        public ICollection<Grade>? Grades { get; set; }

        public override string ToString()
        {
            return StudentId + " - " + FirstName + " " + LastName;
        }
    }
}