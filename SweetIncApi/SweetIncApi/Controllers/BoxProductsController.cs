using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoxProductsController : ControllerBase
    {
        private readonly IBoxProductRepository _boxProductRepository;
        private readonly IMapper _mapper;

        public BoxProductsController(IBoxProductRepository boxProductRepository, IMapper mapper)
        {
            _boxProductRepository = boxProductRepository;
            _mapper = mapper;
        }

        // GET: api/BoxProducts
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_boxProductRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/BoxProducts/5
        [HttpGet("{boxId}/{productId}")]
        public IActionResult GetByPrimaryKey( int boxId, int productId)
        {
            var boxProduct = _boxProductRepository.GetByPrimaryKey(boxId, productId);

            if (boxProduct == null)
            {
                return NotFound();
            }

            return Ok(boxProduct);
        }

        [HttpGet("{boxId}")]
        public IActionResult GetByBoxId(int boxId)
        {
            var boxProduct = _boxProductRepository.GetByBoxId(boxId);

            if (boxProduct == null)
            {
                return NotFound();
            }

            return Ok(boxProduct);
        }

        // PUT: api/BoxProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{boxId}/{productId}")]
        public IActionResult Update(int boxId, int productId, BoxProductVM boxProductVM)
        {
            if (boxId != boxProductVM.BoxId || productId != boxProductVM.ProductId)
            {
                return BadRequest();
            }

            try
            {
                var boxProduct = _mapper.Map<BoxProduct>(boxProductVM);
                var result = _boxProductRepository.Update(boxProduct);
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

        [HttpPut("{boxId}")]
        public IActionResult AddRandomProducts(int boxId)
        {
            var randomizedBox = _boxProductRepository.AddRandomProducts(boxId);
            return Ok(randomizedBox);
        }

        // POST: api/BoxProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(BoxProductVM boxProductVM)
        {
            var boxProduct = _mapper.Map<BoxProduct>(boxProductVM);

            var box = _boxProductRepository.Add(boxProduct);
            return Ok(box);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int boxId, int productId)
        {
            try
            {
                _boxProductRepository.DeleteByPrimaryKey(boxId, productId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
