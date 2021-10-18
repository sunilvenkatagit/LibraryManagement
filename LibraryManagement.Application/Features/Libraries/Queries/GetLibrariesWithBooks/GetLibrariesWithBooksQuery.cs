using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class GetLibrariesWithBooksQuery : IRequest<List<LibraryBookListVm>>
    {
    }
}
