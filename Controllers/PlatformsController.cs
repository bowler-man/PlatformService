using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private IPlatformRepo _repository;
        private IMapper _mapper;
            public PlatformsController(IPlatformRepo repo,IMapper mapper)
            {
                _repository = repo;
                _mapper = mapper;
            }

            [HttpGet]
            public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
            {
                Console.WriteLine("Getting Platforms");
                var platforms = _repository.GetAllPlatforms();
                return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));

            }
           [HttpGet("{id}",Name="GetPlatformById")]      
            public ActionResult<PlatformReadDto> GetPlatformById(int id)
            {
                Console.WriteLine("Getting Platform by Id");
                var platform = _repository.GetPlatformById(id);
                if (platform!=null)
                {
                      return Ok(_mapper.Map<PlatformReadDto>(platform));
                }
                return NotFound();

            }

            [HttpPost(Name="CreatePlatform")]      
            public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
            {
                Console.WriteLine("Creating Platform ");
                 var platform = _mapper.Map<Platform>(platformCreateDto);
                 _repository.CreatePlatform(platform);
                 _repository.SaveChanges();
                 var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
                
                 return CreatedAtRoute(nameof(GetPlatformById),new {Id = platformReadDto.Id},platformReadDto);

            }

      
    }
}