using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILibraryRepository libraryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator(_bookRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            // checking that Library, Publisher & Author Id's are valid before creating a book
            var library = await _libraryRepository.GetByIdAsync(request.LibraryId);
            if (library == null)
                throw new BadRequestException($"There is no library with Id: {request.LibraryId}");

            var listOfAuthors = new List<Author>() {  };
            
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

            var @book = _mapper.Map<Book>(request);
            @book.Authors = listOfAuthors;

            @book = await _bookRepository.AddAsync(@book);

            return @book.BookId;
        }
    }
}
