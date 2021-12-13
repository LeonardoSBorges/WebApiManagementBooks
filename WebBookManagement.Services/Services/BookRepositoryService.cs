using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Services.Entities;
using WebBookManagement.Services.Interfaces;

namespace WebBookManagement.Services.Services
{
    public class BookRepositoryService : IBookRepositoryService
    {
        private readonly IBookMemoryCache _bookMemoryCache;

        public BookRepositoryService(IBookMemoryCache bookMemoryCache)
        {
            _bookMemoryCache = bookMemoryCache;
        }

        public BookRepositoryService()
        {
        }

        public List<InfoBook> CreateBook(string title)
        {
            return _bookMemoryCache.CreateBook(title);    
        }
        public List<InfoBook> GetBooks()
        {
            return _bookMemoryCache.GetBooks();
        }

        public List<InfoBook> DeleteBook(int id)
        {
            return _bookMemoryCache.DeleteBook(id);
        }

        public List<InfoBook> LoanBook(int id)
        {
            return _bookMemoryCache.LoanBook(id);
        }

        public List<InfoBook> ReturnBook(int id)
        {
            return _bookMemoryCache.ReturnBook(id);
        }

        public List<InfoBook> UpdateBook(int id, string title)
        {
            return _bookMemoryCache.UpdateBook(id, title);
        }
    }
}
