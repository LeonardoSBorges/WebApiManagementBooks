using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class CreateBookHandler : IRequestHandler<BookRequest, BookResponse>
    {
        private readonly IBookRepositoryService _bookRepositoryService;
        public CreateBookHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }
        public Task<BookResponse> Handle(BookRequest request, CancellationToken cancellationToken)
        {

            var collection = _bookRepositoryService.CreateBook(request.Title);

            var response = new BookResponse
            {
                Books = new List<BookResponse.Book>()
            };

            foreach (var book in collection)
            {

                response.Books.Add(new BookResponse.Book
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
