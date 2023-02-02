using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_T2.Models
{
    public class WorkOnProject
    {
        public int Hours { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public virtual Employee? Employees { get; set; }

        [ForeignKey("Project")]
        public int projNum { get; set; }
        public  Project? Project { get; set; }
    }
}
