using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var order = _orderRepository.GetByPrimaryKey(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateOrderVM updateOrder)
        {
            if (id != updateOrder.Id)
            {
                return BadRequest();
            }

            try
            {
                var order = _mapper.Map<Order>(updateOrder);
                var result = _orderRepository.Update(order);
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(OrderVM orderVM)
        {
            var order = _mapper.Map<Order>(orderVM);
            _orderRepository.Add(order);
            return Ok(order);

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
