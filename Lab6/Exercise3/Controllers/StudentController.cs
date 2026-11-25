using Exercise3.Models;
using Lab6.Exercise3.Controllers;

namespace Exercise3.Controllers
{
    public class StudentController : BaseController<Student>
    {
        protected override string EntityName => "Student";
    }
}
