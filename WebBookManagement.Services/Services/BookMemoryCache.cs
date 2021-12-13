using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebBookManagement.Services.Entities;
using WebBookManagement.Services.Exceptions;
using WebBookManagement.Services.Interfaces;


namespace WebBookManagement.Services.Services
{
    public class BookMemoryCache : IBookMemoryCache
    {
        private readonly IMemoryCache _memoryCache;

        public BookMemoryCache() { }
        public BookMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<InfoBook> CreateBook(string title)
        {
            var books = GetBooks();
            var id = books?.LastOrDefault()?.Id + 1;

            books.Add(new InfoBook(id ?? 1, title, Entities.Enums.Stats.Disponivel));
            
            var bookSerialize = JsonSerializer.Serialize(books);

            _memoryCache.Set("Books", bookSerialize);

            return books;
        }

        public List<InfoBook> GetBooks()
        {
            var bookDeserialize = new List<InfoBook>();
            
            if(_memoryCache.TryGetValue("Books", out string value))
            {
                bookDeserialize = JsonSerializer.Deserialize<List<InfoBook>>(value);
            }
               
            return bookDeserialize;
           
        }

        public List<InfoBook> DeleteBook(int id)
        {
            
            var books = GetBooks();

            if (id > books.Count )
            {
                throw new ExceptionMemoryCache("O Id informado nao foi localizado, por favor digite um id existente.");
            }
            else
            {
                books.Remove(books[id - 1]);
            }

            int value = books.Count;
            int i = 0;
            while (i < value)
            {
                if (books[i].Id != i)
                {
                    var aux = i + 1;
                    books[i].Id = aux;
                }

                i++;
            }
            var bookSerialize = JsonSerializer.Serialize(books);

            _memoryCache.Set("Books", bookSerialize);

            return books;
        }



        public List<InfoBook> LoanBook(int id)
        {
            var books = GetBooks();


            if (id > books.Count)
            {
                throw new ExceptionMemoryCache("O Id informado nao foi localizado, por favor digite um id existente.");
            }
            else if (books[id - 1].Stats == Entities.Enums.Stats.Indisponivel)
            {
                throw new ExceptionMemoryCache("O livro escolhido esta indisponivel no momento, por favor escolha outro.");
            }
            else if (books[id - 1].Stats == Entities.Enums.Stats.Disponivel)
            {
                books[id - 1].Stats = Entities.Enums.Stats.Indisponivel;
            }
            else
            {
                var serializeBook = JsonSerializer.Serialize(books);
                _memoryCache.Set("Books", serializeBook);
                return books;
            }
            
            var bookSerialize = JsonSerializer.Serialize(books);

            _memoryCache.Set("Books", bookSerialize);

            return books;
        }

        public List<InfoBook> ReturnBook(int id)
        {
            var books = GetBooks();

            if (id > books.Count)
            {
                throw new ExceptionMemoryCache("O Id informado nao foi localizado, por favor digite um id existente.");
            }
            else if (books[id - 1].Stats == Entities.Enums.Stats.Disponivel)
            {
                throw new ExceptionMemoryCache("O livro escolhido esta em estoque, verifique se o Id digitado esta correto e tente novamente");
            }
            else if (books[id - 1].Stats == Entities.Enums.Stats.Indisponivel)
            {
                books[id - 1].Stats = Entities.Enums.Stats.Disponivel;
            }
            else
            {
                var serializeBook = JsonSerializer.Serialize(books);
                _memoryCache.Set("Books", serializeBook);
                return books;
            }

            var bookSerialize = JsonSerializer.Serialize(books);

            _memoryCache.Set("Books", bookSerialize);

            return books;
        }

        public List<InfoBook> UpdateBook(int id, string title)
        {
            var books = GetBooks();

            if (id > books.Count)
            {
                throw new ExceptionMemoryCache("O Id informado nao foi localizado, por favor digite um id existente.");
            }

            books[id - 1].Title = title;
  
            var bookSerialize = JsonSerializer.Serialize(books);

            _memoryCache.Set("Books", bookSerialize);

            return books;

        }
    }
}
