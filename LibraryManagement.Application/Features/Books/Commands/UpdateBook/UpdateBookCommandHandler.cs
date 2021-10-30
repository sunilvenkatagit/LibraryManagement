using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILibraryRepository libraryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetByIdAsync(request.BookId);
            if (bookToUpdate == null)
                throw new NotFoundException(nameof(Book), request.BookId);

            var validator = new UpdateBookCommandValidator(_bookRepository);
            var validatiobResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatiobResult.Errors.Count > 0)
                throw new ValidationException(validatiobResult);

            // checking that Library, Publisher & Author Id's are valid before creating a book
            var library = await _libraryRepository.GetByIdAsync(request.LibraryId);
            if (library == null)
                throw new BadRequestException($"There is no library with Id: {request.LibraryId}");

            var listOfAuthors = new List<Author>() { };
            foreach (var id in request.AuthorIds)
            {
                var author = await _authorRepository.GetByIdAsync(id);
                if (author == null)
                    throw new BadRequestException($"There is no author with Id: {id}");
                listOfAuthors.Add(author);
            }

            var publisher = await _publisherRepository.GetByIdAsync(request.PublisherId);
            if (publisher == null)
                throw new BadRequestException($"There is no publisher with Id: {request.PublisherId}");

            _mapper.Map(request, bookToUpdate, typeof(UpdateBookCommand), typeof(Book));
            //bookToUpdate.Authors = listOfAuthors;

            //var @book = _mapper.Map<Book>(request);
            //@book.Authors = listOfAuthors;

            await _bookRepository.UpdateAsync(bookToUpdate);
            return Unit.Value;
        }
    }
}
