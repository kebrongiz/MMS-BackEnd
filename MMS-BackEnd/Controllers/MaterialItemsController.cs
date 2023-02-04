using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class MaterialItemsController : ControllerBase
    {
        private readonly IMaterialItem _materialItemService;
        public MaterialItemsController(IMaterialItem materialItemService)
        {
            _materialItemService = materialItemService;
        }
        [HttpPost("employees/{employeeId}/materialItems")]
        public IActionResult AddMaterialItems([FromRoute] int employeeId, [FromBody] MaterialItem materialItem)
        {
            try
            {
                if (materialItem == null)
                {

                    return BadRequest("materialItem object is null");
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var employee = _materialItemService.GetEmployeeById(employeeId);
                if (employee == null)

                {
                    return NotFound();
                }

                _materialItemService.CreateMaterialItemForImployee(employeeId, materialItem);
                return CreatedAtRoute("GetEmployeeById", new { employeeId, id = materialItem.id });

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetAllMaterialItems()
        {
            try
            {
                var materials = _materialItemService.GetAllMaterialItems();

                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpGet("{id}", Name = "GetMaterialItemsForEmployee")]
        //public IEnumerable<MaterialItem> GetMaterialItemsForEmployee(int employeeId, int id)
        //{
        //    return _materialItemService.GetMaterialItemForEmployee(employeeId, id);
        //}
    }
}

