using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; } = null!;
        
        public ICollection<Grade>? Grades { get; set; }

        public override string ToString()
        {
            return $"{HomeworkId} - {Description}";
        }
    }
}