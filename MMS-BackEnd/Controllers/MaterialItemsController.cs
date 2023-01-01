using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api/materialItems")]
    [ApiController]
    public class MaterialItemsController : ControllerBase
    {
        private readonly IMaterialItem _materialItemService;
        public MaterialItemsController(IMaterialItem materialItemService)
        {
            _materialItemService = materialItemService;
        }
        [HttpPost]
        public int AddInventories(MaterialItem materialItem)
        {
            return _materialItemService.Create(materialItem);
        }
        [HttpGet]
        public List<MaterialItem> GetInventories()
        {
            return _materialItemService.GetAll();
        }
    }
}

