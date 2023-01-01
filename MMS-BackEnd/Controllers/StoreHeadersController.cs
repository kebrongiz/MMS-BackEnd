using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api/storeHeaders")]
    [ApiController]
    public class StoreHeadersController : ControllerBase
    {
        private readonly IStoreHeader _headerService;
        public StoreHeadersController(IStoreHeader headerService)
        {
            _headerService = headerService;
        }
        [HttpPost]
        public IActionResult CreateStoreHeader([FromBody] StoreHeader header)
        {
            try
            {
                if (header == null)
                {

                    return BadRequest("StoreHeader object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _headerService.CreateStoreHeader(header);

                return CreatedAtRoute("StoreHeaderById", new { id = header.id }, header);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetAllStoreHeader()
        {
            try
            {
                var storeheaders = _headerService.GetAllStoreHeaders();

                return Ok(storeheaders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "storeHeaderById")]
        public IActionResult GetStoreHeaderById(int id)
        {
            try
            {
                var store = _headerService.GetStoreHeaderById(id);

                if (store == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(store);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }
        [HttpGet("{id}/materialItems")]
        public IActionResult GetStoreHeaderWithDetails(int id)
        {
            try
            {
                var header = _headerService.GetStoreHeaderWithDetails(id);

                if (header == null)
                {

                    return NotFound();
                }
                else
                {
                    return Ok(header);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
