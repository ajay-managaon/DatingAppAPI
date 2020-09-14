using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using datingapp_service.datingapp.dtos;
using datingapp_service.datingapp.InterfaceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datingapp_service.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository datingRepo;
        private readonly IMapper mapper;

        public UsersController(IDatingRepository _datingRepo,IMapper _mapper)
        {
            datingRepo = _datingRepo;
            mapper = _mapper;
        }

        public IActionResult GetUsers()
        {
            
            return Ok(mapper.Map<IEnumerable<UserListDTO>>(datingRepo.GetUsers()));
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(mapper.Map<UserDetailsDTO>(datingRepo.GetUser(id)));
        }
    }
}
