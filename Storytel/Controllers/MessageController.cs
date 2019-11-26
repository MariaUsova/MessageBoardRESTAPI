using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storytel.Services;

namespace Storytel.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private IUserService _userService;
        private IMessagesService _messagesService;
        private IHttpContextAccessor _httpContextAccessor;

        public MessageController(IUserService userService, IMessagesService messagesService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _messagesService = messagesService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            return Ok(_messagesService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetMessage(Guid id)
        {
            var message = _messagesService.GetById(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageModel model)
        {
            var userId = _userService.GetCurrentUserId(this._httpContextAccessor);
            var message = _messagesService.Add(model.Message, userId);
            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateMessage(Guid id, UpdateMessageModel model)
        {
            var userId = _userService.GetCurrentUserId(this._httpContextAccessor);
            
            var message = _messagesService.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
           
            if (message.UserId != userId)
            {
                return Forbid();
            }

            _messagesService.Update(id, model.Message);

            return Ok(message);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteMessage(Guid id)
        {
            var userId = _userService.GetCurrentUserId(this._httpContextAccessor);
            
            var message = _messagesService.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            if (message.UserId != userId)
            {
                return Forbid();
            }

            _messagesService.Delete(message);

            return Ok();
        }

    }
}
