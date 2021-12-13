using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebBookManagement.Services.Entities.Enums;

namespace WebBookManagement.Domain.Commands.Responses
{
    public class ReturnBookResponse
    {

        public List<Book> Books { get; set; }
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }

            [JsonConverter(typeof(JsonStringEnumConverter))]
            public Stats Stats { get; set; }
        }

    }
}
