using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
        {
            private readonly IInventory _invetoryService;
            public InventoryController(IInventory invetoryService)
            {
                _invetoryService = invetoryService;
            }
            [HttpPost]
            public int AddInventories(Inventory inventory)
            {
                return _invetoryService.Create(inventory);
            }
        }
    }

