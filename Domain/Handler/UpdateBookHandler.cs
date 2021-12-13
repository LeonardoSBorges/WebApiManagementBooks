using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        public readonly IBookRepositoryService _bookRepositoryService;

        public UpdateBookHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }

        public Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var collection = _bookRepositoryService.UpdateBook(request.Id, request.Title);

            var response = new UpdateBookResponse
            {
                Books = new List<UpdateBookResponse.Book>()
            };

            foreach (var book in collection)
            {
                response.Books.Add(new UpdateBookResponse.Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    Stats = book.Stats,
                });
            }

            return Task.FromResult(response);
        }
    }
}
