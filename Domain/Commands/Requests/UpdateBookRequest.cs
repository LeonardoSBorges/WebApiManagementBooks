using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Responses;

namespace WebBookManagement.Domain.Commands.Requests
{
    public class UpdateBookRequest : IRequest<UpdateBookResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public UpdateBookRequest(int id, string title)
        {
            Id = id;
            Title = title;
        }
        
    }
}
