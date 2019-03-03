﻿using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.ModelsNewData;
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
    public class CommentsController : ControllerBase
    {
        private ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        //POST api/comments
        [HttpPost]
        public ActionResult Post([FromBody] CommentData commentData)
        {
            if (commentData == null)
            {
                return BadRequest();
            }
            _service.Create(commentData);
            return Ok();
        }

        // PUT api/comments/{Id} 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CommentData commentData)
        {
            if (_service.Update(commentData, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE api/comments/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //GET api/awards/{id}/comments
        [Route("/api/awards/{id}/comments")]
        public ActionResult<IEnumerable<CommentData>> GetCommentsForAward(int id)
        {
            var comments = _service.GetCommentsForAward(id);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }
    }
}