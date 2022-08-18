using AutoMapper;
using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;
        
        public BookRepository(BookStoreContext bookStoreContext,IMapper mapper) 
        {
            _bookStoreContext = bookStoreContext;
            _mapper = mapper;
        }  
        public async Task<List<BookModel>> GetAllBookAsAsync()
        {
            //var records = await _bookStoreContext.Books.Select(data => new BookModel()
            //{
            //    Id = data.Id,
            //    Title = data.Title,
            //    Description = data.Description
            //}).ToListAsync();
            //return records;
            var books = await _bookStoreContext.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books); 
        }

        public async Task<BookModel> GetBookFromIdAsAsync(int id)
        {
            //var records = await _bookStoreContext.Books.Where(x => x.Id == id).Select(data => new BookModel()
            //{
            //    Id = data.Id,
            //    Title = data.Title,
            //    Description = data.Description
            //}).FirstOrDefaultAsync();
            //return records;
            var book = await _bookStoreContext.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBooksAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _bookStoreContext.Books.Add(book);
            await _bookStoreContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBookFromIdAsAsync(int id,BookModel bookModel)
        {
            var book = new Books()
            {
                Id = id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _bookStoreContext.Books.Update(book);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task UpdateBookFromPatchIdAsAsync(int id, JsonPatchDocument bookModel)
        {
            var book = await _bookStoreContext.Books.FindAsync(id);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBooksAsync(int id)
        {
            var book = new Books()
            {
                Id = id
            };
            if (book != null)
            {
                _bookStoreContext.Books.Remove(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }
    }
}
