using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BodyStyle
    {
        public int Id { get; set; }

        [MaxLength(64)] public string Name { get; set; } = default!;

        public ICollection<Car>? Cars { get; set; } = default!;
    }
}