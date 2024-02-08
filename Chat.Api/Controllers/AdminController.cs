using Chat.Api.Domain.Logs;
using Chat.Database.MsSql.Context;
using Chat.Database.MsSql.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly ChatContext ChatContext;
        public AdminController(ChatContext chatContext)
        {
            ChatContext = chatContext;
        }
        [HttpGet("up")]
        public async Task<IActionResult> Up()
        {
            await ChatContext.Database.EnsureCreatedAsync();
            return Problem("success", statusCode: StatusCodes.Status201Created);
        }
        [HttpGet("down")]
        public async Task<IActionResult> Down()
        {
            await ChatContext.Database.EnsureDeletedAsync();
            return Problem("success", statusCode: StatusCodes.Status200OK);
        }

        [HttpGet("sharedlogs")]
        public async Task<IActionResult> Logs(bool errors = false) => Ok(
                await (
                    from log in ChatContext.Logs
                    where !errors || (log.IsError == errors)
                    orderby log.Date descending
                    select log
                ).ToListAsync());

        [HttpGet("sharedlogs/{logId}")]
        public async Task<IActionResult> Logs(Guid logId)
        {
            var logDTO = await (from log in ChatContext.Logs
                             where log.Id == logId
                             select new LogDTO(log)).ToListAsync();
            return Ok(logDTO);
        }
    }

}
