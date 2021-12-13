using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class ReturnBookHandler : IRequestHandler<ReturnBookRequest, ReturnBookResponse>
    {
        private readonly IBookRepositoryService _bookRepositoryService;
        public ReturnBookHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }

        public Task<ReturnBookResponse> Handle(ReturnBookRequest request, CancellationToken cancellationToken)
        {
            var collection = _bookRepositoryService.ReturnBook(request.Id);

            var response = new ReturnBookResponse
            {
                Books = new List<ReturnBookResponse.Book>()
            };

            foreach (var book in collection)
            {
                response.Books.Add(new ReturnBookResponse.Book
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
