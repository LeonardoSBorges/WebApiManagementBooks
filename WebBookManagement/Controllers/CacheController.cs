using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Services.Exceptions;

namespace WebApiBooks.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache memoryCache;
        public CacheController(IMemoryCache memoryCache, IMediator mediator)
        {
            this.memoryCache = memoryCache;
            this._mediator = mediator;
        }

        [HttpPost("SetCache")]
        public async Task<IActionResult> SetCache(BookRequest data)
        {
            var result = _mediator.Send(data);

            return Ok(await result);
        }

        [HttpDelete("RemoveBook")]
        public async Task<IActionResult> RemoveBook(DeleteBookRequest data)
        {
            try
            {
                
                var result = _mediator.Send(data);
                
                return Ok(await result);
            }
            catch(ExceptionMemoryCache ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {

            try
            {
                return Ok(await _mediator.Send(new GetAllBooksRequest()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateBook")]
        public async Task<IActionResult> UpdateBook(UpdateBookRequest data)
        {
            try
            {
                var result = _mediator.Send(data);

                return Ok(await result);
            }
            catch(ExceptionMemoryCache ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("LoanBook")]
        public async Task<IActionResult> LoanBook(LoanBookRequest data)
        {
            try
            {
                var retsult = _mediator.Send(data);

                return Ok(await retsult);
            }
            catch(ExceptionMemoryCache ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("ReturnBook")]
        public async Task<IActionResult> ReturnBook(ReturnBookRequest data)
        {
            try
            {
                var retsult = _mediator.Send(data);

                return Ok(await retsult);
            }
            catch(ExceptionMemoryCache ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
