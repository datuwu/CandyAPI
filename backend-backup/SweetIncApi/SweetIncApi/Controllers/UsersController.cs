using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.User;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var user = _userRepository.GetByPrimaryKey(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserVM updateUser)
        {
            if (id != updateUser.Id)
            {
                return BadRequest();
            }

            try
            {
                var user = _mapper.Map<User>(updateUser);
                var result = _userRepository.Update(user);
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(UserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _userRepository.Add(user);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Register(UserVM user)
        {
            #region Validation
            //var isPassed = ValidationController.Validate(Request, new List<string>
            //    {
            //        "Customer",
            //        "Staff",
            //        "Admin"
            //    });

            //if (!isPassed.Result) return BadRequest();
            #endregion

            var _user = _userRepository.Register(user);
            return Ok(_user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
