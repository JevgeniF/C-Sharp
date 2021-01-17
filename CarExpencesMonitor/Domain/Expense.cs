using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Expense
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public DateTime? DateTime { get; set; }

        [MaxLength(4096)] public string Description { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public double Price { get; set; }
    }
}