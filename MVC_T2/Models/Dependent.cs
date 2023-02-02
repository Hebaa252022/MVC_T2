using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_T2.Models
{
    public class Dependent
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public string? Relationship { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public Employee? Employee { get; set; }
    }
}
