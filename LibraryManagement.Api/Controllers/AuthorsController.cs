using LibraryManagement.Application.Features.Authors.Commands.CreateAuthor;
using LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            var id = await _mediator.Send(createAuthorCommand);
            return Ok(id);
        }

        [HttpDelete("{id}", Name = "DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAuthorCommand() { AuthorId = id });
            return NoContent();
        }
    }
}
