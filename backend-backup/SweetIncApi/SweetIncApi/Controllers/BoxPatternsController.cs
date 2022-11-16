using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoxPatternsController : ControllerBase
    {
        private readonly IBoxPatternRepository _boxPatternRepository;
        private readonly IMapper _mapper;

        public BoxPatternsController(IBoxPatternRepository boxPatternRepository, IMapper mapper)
        {
            _boxPatternRepository = boxPatternRepository;
            _mapper = mapper;
        }

        // GET: api/BoxPatterns
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_boxPatternRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/BoxPatterns/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var boxPattern = _boxPatternRepository.GetByPrimaryKey(id);

            if (boxPattern == null)
            {
                return NotFound();
            }

            return Ok(boxPattern);
        }

        // PUT: api/BoxPatterns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateBoxPatternVM boxPatternVM)
        {
            if (id != boxPatternVM.Id)
            {
                return BadRequest();
            }
            try
            {
                var boxPattern = _mapper.Map<BoxPattern>(boxPatternVM);
                var result = _boxPatternRepository.Update(boxPattern);
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

        // POST: api/BoxPatterns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(BoxPatternVM boxPatternVM)
        {
            var boxPattern = _mapper.Map<BoxPattern>(boxPatternVM);
            _boxPatternRepository.Add(boxPattern);
            return Ok(boxPattern);
        }

        // DELETE: api/BoxPatterns/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _boxPatternRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
