using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Responses;

namespace WebBookManagement.Domain.Commands.Requests
{
    public class DeleteBookRequest : IRequest<DeleteBookResponse>
    {
        public int Id { get; set; }
        public DeleteBookRequest(int id)
        {
            Id = id; 
        }
    }
}
