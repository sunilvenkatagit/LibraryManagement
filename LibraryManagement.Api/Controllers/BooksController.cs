using LibraryManagement.Application.Features.Books.Commands.CreateBook;
using LibraryManagement.Application.Features.Books.Queries.GetBooksByGenre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{genre}", Name = "GetAllBooksByGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BookListGenreVm>>> GetAllBooksByGenre(string genre)
        {
            var request = new GetBooksByGenreQuery() { Genre = genre };

            var books = await _mediator.Send(request);
            return Ok(books);
        }

        [HttpPost(Name = "AddBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookCommand createBookCommand)
        {
            var id = await _mediator.Send(createBookCommand);
            return Ok(id);
        }
    }
}
