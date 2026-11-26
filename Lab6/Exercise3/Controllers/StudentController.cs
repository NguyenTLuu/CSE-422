using Exercise3.Models;

namespace Exercise3.Controllers
{
    public class StudentController : BaseController<Student>
    {
        protected override string EntityName => "Student";
    }
}
