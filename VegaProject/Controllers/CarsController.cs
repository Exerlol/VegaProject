using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VegaProject.Controllers.Resources_DTOs;
using VegaProject.Core.DomainModels;
using VegaProject.DAL;

namespace VegaProject.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly VegaDbContext _db;
        private readonly IMapper _mapper;

        public CarsController(VegaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet("makes")]
         public async Task<IActionResult> Makes()
        {
            var makes = await _db.Makes.Include(m => m.Models).ToListAsync();

            var makeResource = _mapper.Map<List<Make>,List<MakeResource>>(makes);
            return Json(makeResource);
        }
        [HttpGet("features")]
        public async Task<IActionResult> Features(){

            var features = await _db.Features.ToListAsync();

            var featureResource = _mapper.Map<List<Feature>,List<KeyValuePairResource>>(features);

            return Json(featureResource);
        }

    }
}