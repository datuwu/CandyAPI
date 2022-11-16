using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Role;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_roleRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var catagory = _roleRepository.GetByPrimaryKey(id);

            if (catagory == null)
            {
                return NotFound();
            }

            return Ok(catagory);
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRoleVM updateRole)
        {
            if (id != updateRole.Id)
            {
                return BadRequest();
            }

            try
            {
                var role = _mapper.Map<Role>(updateRole);
                var result = _roleRepository.Update(role);
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(RoleVM roleVM)
        {
            var role = _mapper.Map<Role>(roleVM);
            _roleRepository.Add(role);
            return Ok(role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _roleRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
