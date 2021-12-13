using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IBookRepositoryService _bookRepositoryService;

        public DeleteBookHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }

        public Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {


            var collection = _bookRepositoryService.DeleteBook(request.Id);
            
                var response = new DeleteBookResponse
                {
                    Books = new List<DeleteBookResponse.Book>()
                };

                foreach (var book in collection)
                {
                    response.Books.Add(new DeleteBookResponse.Book
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
