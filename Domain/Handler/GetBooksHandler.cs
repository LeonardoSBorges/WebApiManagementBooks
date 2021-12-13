using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class GetBooksHandler : IRequestHandler<GetAllBooksRequest, GetAllBooksResponse>
    {
        private readonly IBookRepositoryService _bookRepositoryService;
        public GetBooksHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }

        public Task<GetAllBooksResponse> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var collection = _bookRepositoryService.GetBooks();

            var response = new GetAllBooksResponse
            {
                Books = new List<GetAllBooksResponse.Book>()
            };

            foreach (var book in collection)
            {
                response.Books.Add(new GetAllBooksResponse.Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    Stats = book.Stats
                });
            }

            return Task.FromResult(response);
        }
    }
}
