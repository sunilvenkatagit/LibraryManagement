using MediatR;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList
{
    public class GetLibrariesListQuery : IRequest<List<LibraryListVm>>
    {
    }
}
