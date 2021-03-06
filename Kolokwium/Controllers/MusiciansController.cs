﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTOs.Requests;
using Kolokwium.DTOs.Responses;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IMusicDbService _dbService;
        public MusiciansController(IMusicDbService service)
        {
            _dbService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetMusician(int id)
        {
            MusicianResponseDto response = null;
            try
            {
                response = _dbService.GetMusicianInfo(id); ;
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddNewMusician(MusicianRequestDto musicianRequestDto)
        {

            try
            {
                _dbService.AddMusician(musicianRequestDto); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}