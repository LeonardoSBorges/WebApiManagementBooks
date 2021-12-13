using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Responses;

namespace WebBookManagement.Domain.Commands.Requests
{
    public class LoanBookRequest : IRequest<LoanBookResponse>
    {
        public int Id { get; set; }
        public LoanBookRequest(int id)
        {
            Id = id;
        }
    }
}
