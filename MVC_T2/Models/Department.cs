using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_T2.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public  List<DepartmentLocation>? DepartmentLocations { get; set; }
        public  List<Project>? Projects { get; set; }

    }
}
