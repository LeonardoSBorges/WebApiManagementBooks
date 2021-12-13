using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Services.Entities;

namespace WebBookManagement.Services.Interfaces
{
    public interface IBookMemoryCache
    {
        List<InfoBook> CreateBook(string title);
        List<InfoBook> GetBooks();
        List<InfoBook> DeleteBook(int id);
        List<InfoBook> UpdateBook(int id, string title);
        List<InfoBook> LoanBook(int id);
        List<InfoBook> ReturnBook(int id);
    }
}
