using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using WebBookManagement.Domain.Commands.Responses;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Domain.Handler
{
    public class LoanBookHandler : IRequestHandler<LoanBookRequest, LoanBookResponse>
    {
        private readonly IBookRepositoryService _bookRepositoryService;
        public LoanBookHandler(IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
        }
        public Task<LoanBookResponse> Handle(LoanBookRequest request, CancellationToken cancellationToken)
        {

            var collection = _bookRepositoryService.LoanBook(request.Id);

            var response = new LoanBookResponse
            {
                Books = new List<LoanBookResponse.Book>()
            };
            
            foreach (var book in collection)
            {
                response.Books.Add(new LoanBookResponse.Book
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
