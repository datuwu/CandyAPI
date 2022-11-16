using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Origin;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly IOriginRepository _originRepository;
        private readonly IMapper _mapper;

        public OriginsController(IOriginRepository originRepository, IMapper mapper)
        {
            _originRepository = originRepository;
            _mapper = mapper;
        }

        // GET: api/Origins
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_originRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Origins/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var origin = _originRepository.GetByPrimaryKey(id);

            if (origin == null)
            {
                return NotFound();
            }

            return Ok(origin);
        }

        // PUT: api/Origins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateOriginVM updateOrigin)
        {
            if (id != updateOrigin.Id)
            {
                return BadRequest();
            }

            try
            {
                var origin = _mapper.Map<Origin>(updateOrigin);
                var result = _originRepository.Update(origin);
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

            return NoContent();
        }

        // POST: api/Origins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(OriginVM originVM)
        {
            var origin = _mapper.Map<Origin>(originVM);
            var entity = _originRepository.Add(origin);
            return Ok(entity);
        }

        // DELETE: api/Origins/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _originRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
