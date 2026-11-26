using Exercise3.Models;

namespace Exercise3.Controllers
{
    public class TeacherController : BaseController<Teacher>
    {
        protected override string EntityName => "Teacher";
    }
}
