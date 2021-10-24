using LibraryManagement.Application.Features.Libraries.Commands.CreateLibrary;
using LibraryManagement.Application.Features.Libraries.Commands.DeleteLibrary;
using LibraryManagement.Application.Features.Libraries.Commands.UpdateLibrary;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesByLocation;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/libraries")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibrariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllLibraries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LibraryListVm>>> GetAllLibraries()
        {
            var libraries = await _mediator.Send(new GetLibrariesListQuery());
            return Ok(libraries);
        }

        [HttpGet("allWithBooks", Name = "GetLibrariesWithBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LibraryBookListVm>>> GetLibrariesWithBooks()
        {
            var librariesWithBooks = await _mediator.Send(new GetLibrariesWithBooksQuery());
            return Ok(librariesWithBooks);
        }

        [HttpGet("allByLocation", Name = "GetLibrariesByLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LibraryListLocationVm>>> GetLibrariesByLocation(string location)
        {
            var requestQuery = new GetLibrariesByLocationQuery() { Location = location };

            var librariesByLocation = await _mediator.Send(requestQuery);
            return Ok(librariesByLocation);
        }

        [HttpPost(Name = "AddLibrary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLibraryCommand createLibraryCommand)
        {
            var id = await _mediator.Send(createLibraryCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateLibrary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateLibraryCommand updateLibraryCommand)
        {
            await _mediator.Send(updateLibraryCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteLibrary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var request = new DeleteLibraryCommand() { LibraryId = id };
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
