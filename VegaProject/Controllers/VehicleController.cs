using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VegaProject.Controllers.Resources_DTOs;
using VegaProject.Core;
using VegaProject.Core.DomainModels;

namespace VegaProject.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController( IMapper mapper, IVehicleRepository vehicleRepo, IUnitOfWork unitOfWork)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // [HttpGet("get")]
        // public async Task<IActionResult> GetVechicles()
        // {
        //     var vehicles = await _vegaDbContext.Vehicle.Include(v => v.Features)
        //                                                     .ThenInclude(vf => vf.Feature)
        //                                                .Include(m => m.Model)
        //                                                     .ThenInclude(m => m.Make)
        //                                                .ToListAsync();
                                                       
        //     var vehicleResource = _mapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);

        //     return Json(vehicleResource);
        // }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetVechicle(int id)
        {

            var vehicle = await _vehicleRepo.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateVechicle([FromBody] SaveVehicleResource vehicleResource)
        {
            throw new Exception();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var model = _vegaDbContext.Models.FindAsync(vehicleResource.ModelId);
            // if(model == null)
            // {
            //     ModelState.AddModelError("ModelId", "Invalid model id");
            //     return BadRequest(ModelState);
            // }

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _vehicleRepo.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            vehicle = await _vehicleRepo.GetVehicle(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVechicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _vehicleRepo.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await _unitOfWork.CompleteAsync();
            
            vehicle = await _vehicleRepo.GetVehicle(vehicle.Id);
            
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVechicle(int id)
        {

            var vehicle = await _vehicleRepo.GetVehicle(id,includeRelated:false);

            if (vehicle == null)
                return NotFound();

            _vehicleRepo.Remove(vehicle);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}