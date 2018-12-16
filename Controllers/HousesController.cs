using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiWithTesting.Domain.Converters;
using WebApiWithTesting.Domain.Repositories;
using WebApiWithTesting.Domain.ViewModels;

namespace WebApiWithTesting.API.Controllers
{
    [Route("api/[controller]")]
    public class HousesController : Controller
    {
        private readonly IHouseRepository _houseRepository;

        public HousesController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        [HttpGet]
        [Produces(typeof(List<HouseViewModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _houseRepository.GetAllAsync();
                return new ObjectResult(new HouseConverter().Convert(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(HouseViewModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var house = await _houseRepository.GetByIdAsync(id);
                if (house == null)
                {
                    return NotFound();
                }

                return Ok(new HouseConverter().Convert(house));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(HouseViewModel))]
        public async Task<IActionResult> Post([FromBody] HouseViewModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _houseRepository.AddAsync(new HouseConverter().FromViewModel(input)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(HouseViewModel))]
        public async Task<IActionResult> Put(int id, [FromBody] HouseViewModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                var entity = await _houseRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _houseRepository.UpdateAsync(new HouseConverter().Update(entity, input)))
                {
                    return Ok(input);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(void))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                if (await _houseRepository.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }

                if (await _houseRepository.DeleteAsync(id))
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}