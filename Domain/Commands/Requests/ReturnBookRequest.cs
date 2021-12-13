using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Responses;

namespace WebBookManagement.Domain.Commands.Requests
{
    public class ReturnBookRequest : IRequest<ReturnBookResponse>
    {
        public int Id { get; set; }

        public ReturnBookRequest(int id)
        {
            Id = id;
        }
    }
}
