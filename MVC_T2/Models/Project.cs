using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_T2.Models
{
    public class Project
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        [ForeignKey("Department")]
        public int DeptNum { get; set; }
        public  Department? Department { get; set; }
        public  List<WorkOnProject> WorkOnProjects { get; set; }
        
    }
}
