using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Car
    {
        public int Id { get; set; }

        public int MarkId { get; set; }
        public Mark Mark { get; set; } = default!;

        [MaxLength(128)] public string Model { get; set; } = default!;

        public int YearOfBuilt { get; set; }

        public int? FuelTypeId { get; set; }
        public FuelType? FuelType { get; set; }

        public string RegNumber { get; set; } = default!;

        public float? EngineDisplacement { get; set; }

        public int? TransmissionId { get; set; }
        public Transmission? Transmission { get; set; }

        public int? BodyStyleId { get; set; }
        public BodyStyle? BodyStyle { get; set; }

        [MaxLength(64)] public string? Vin { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Expense>? Expenses { get; set; }
    }
}