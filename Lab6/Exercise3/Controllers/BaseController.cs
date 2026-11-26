using Exercise3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase
        where T : class, IEntity
    {
        protected abstract string EntityName { get; }

        [HttpPost]
        public IActionResult Create([FromBody] T? entity)
        {
            if (entity == null ||
                string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest("Invalid data");
            }

            return Ok(
                $"{EntityName} {entity.Name} created successfully."
            );
        }
    }
}