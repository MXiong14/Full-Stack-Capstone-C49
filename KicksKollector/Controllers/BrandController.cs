using KicksKollector.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KicksKollector.Models;

namespace KicksKollector.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var brands = _brandRepository.GetAll();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var brand = _brandRepository.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            if (string.IsNullOrWhiteSpace(brand.SubBrand))
            {
                brand.SubBrand = null;
                return NoContent();
            }

            _brandRepository.Add(brand);

            return CreatedAtAction("Get", new { id = brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            _brandRepository.Edit(brand);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandRepository.Delete(id);
            return NoContent();
        }
    }
}
