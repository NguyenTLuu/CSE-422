using Exercise3.Models;
using Lab6.Exercise3.Controllers;

namespace Exercise3.Controllers
{
    public class TeacherController : BaseController<Teacher>
    {
        protected override string EntityName => "Teacher";
    }
}
