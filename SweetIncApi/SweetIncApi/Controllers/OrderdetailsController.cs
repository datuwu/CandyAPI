using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Models.DTO.OrderDetail;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderdetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderdetailsController(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        // GET: api/Orderdetails
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderDetailRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Orderdetails/5
        [HttpGet("{orderId}/{boxId}")]
        public IActionResult GetByPrimaryKey(int orderId, int boxId)
        {
            var orderDetail = _orderDetailRepository.GetByPrimaryKey(orderId,boxId);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetByOrderId(int orderId)
        {
            var orderedItems = _orderDetailRepository.GetByOrderId(orderId);

            if (orderedItems == null)
            {
                return NotFound();
            }

            return Ok(orderedItems);
        }

        // PUT: api/Orderdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderId}/{boxId}")]
        public IActionResult Update(int orderId, int boxId, OrderDetailVM orderdetailVM)
        {
            if (boxId != orderdetailVM.BoxId || orderId != orderdetailVM.id)
            {
                return BadRequest();
            }

            try
            {

                var orderDetail = _mapper.Map<Orderdetail>(orderdetailVM);
                var result = _orderDetailRepository.Update(orderDetail);
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

        // POST: api/Orderdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(OrderDetailVM orderDetailVM)
        {
            Orderdetail orderDetail = _mapper.Map<Orderdetail>(orderDetailVM);

            var order = _orderDetailRepository.Add(orderDetail);
            return Ok(order);
        }

        // DELETE: api/Orderdetails/5
        [HttpDelete("{orderId}/{boxId}")]
        public IActionResult Delete(int orderId, int boxId)
        {
            try
            {
                _orderDetailRepository.DeleteByPrimaryKey(orderId, boxId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
