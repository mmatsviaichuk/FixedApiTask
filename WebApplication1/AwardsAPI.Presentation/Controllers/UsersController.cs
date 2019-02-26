﻿using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        //public UsersController()
        //{
        //    _repository = new UserRepository();
        //    repository = new Repository<User>();
        //}

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _service.Create(user);
            return Ok();
        }
        // PUT api/users/{Id} 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User userData)
        {
            //var user = _repository.Read().FirstOrDefault(u => u.Id == id); 
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //user.FirstName = userData.FirstName;
            //user.LastName = userData.LastName;
            //user.Email = userData.Email;
            //user.Phone = userData.Phone;
            //_repository.Update(user);
            //return Ok();
            if (_service.Update(userData, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
             return _service.Read();
        }

        //GET api/users/{Id}/userbyid
        [HttpGet("{id}/userbyid")]
        public ActionResult<User> GetById(int id)
        {
            //var user = _repository.Read().FirstOrDefault(u => u.Id == id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return user;
            var user = _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //GET api/users/{Email}/userbyemail
        [HttpGet("{Email}/userbyemail")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = _service.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //DELETE api/users/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            //var user = _repository.Read().FirstOrDefault(u => u.Id == id);
            //if (user==null)
            //{
            //    return NotFound();
            //}
            //_repository.Delete(user);
            //return Ok();
            if (_service.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
