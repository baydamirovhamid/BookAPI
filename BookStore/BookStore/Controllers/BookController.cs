using BookStore.Handlers;
using BookStore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _mediator.Send(new GetAllBooksQuery());
        }

        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _mediator.Send(new GetBookByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<Book> Post([FromBody] CreateBook command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<Book> Put(int id, [FromBody] UpdateBook command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBook { Id = id });
            return NoContent();
        }
    }
}
