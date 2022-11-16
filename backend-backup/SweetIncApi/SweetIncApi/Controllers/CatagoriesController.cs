using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Catagory;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatagoriesController : ControllerBase
    {
        private readonly ICatagoryRepository _catagoryRepository;
        private readonly IMapper _mapper;

        public CatagoriesController(ICatagoryRepository catagoryRepository, IMapper mapper)
        {
            _catagoryRepository = catagoryRepository;
            _mapper = mapper;
        }

        // GET: api/Catagories
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_catagoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Catagories/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var catagory = _catagoryRepository.GetByPrimaryKey(id);

            if (catagory == null)
            {
                return NotFound();
            }

            return Ok(catagory);
        }

        // PUT: api/Catagories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCatagoryVM updateCatagory)
        {
            if (id != updateCatagory.Id)
            {
                return BadRequest();
            }

            try
            {
                var catagory = _mapper.Map<Catagory>(updateCatagory);
                var result = _catagoryRepository.Update(catagory);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Catagories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(CatagoryVM catagoryVM)
        {
            var catagory = _mapper.Map<Catagory>(catagoryVM);
                _catagoryRepository.Add(catagory);
            return Ok(catagory);
        }

        // DELETE: api/Catagories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _catagoryRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
