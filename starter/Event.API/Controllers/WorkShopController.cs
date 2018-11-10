using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Domain;
using Event.API.Dtos;
using Event.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopController : ControllerBase
    {
        private readonly IWorkShopService _workShopService;

        public WorkShopController(IWorkShopService workShopService)
        {
            _workShopService = workShopService;
        }

        [HttpGet]
        public async Task<ActionResult> GetWorkShops()
        {
            var workShops = await _workShopService.Get();
            if (!workShops.Any()) return NotFound();
            var workShopsDto = workShops.Select(w => new WorkshopDto()
            {
                Id = w.Id,
                IsFree = w.IsFree,
                Description = w.Description,
            });
            return Ok(workShopsDto);
        }

        [HttpPost]
        public async Task<ActionResult> SaveWorkShop([FromBody] WorkshopDto workshop)
        {
            var workShopToSave = new WorkShop
            {
                Id = Guid.NewGuid(),
                Description = workshop.Description,
                IsFree = workshop.IsFree
            };

            await _workShopService.SaveWorkshop(workShopToSave);
            return Ok(workShopToSave);
        }
    }
}