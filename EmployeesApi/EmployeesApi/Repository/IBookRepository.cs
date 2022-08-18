using BookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBookAsAsync();
        Task<BookModel> GetBookFromIdAsAsync(int id);
        Task<int> AddBooksAsync(BookModel bookModel);
        Task UpdateBookFromIdAsAsync(int id, BookModel bookModel);
        Task UpdateBookFromPatchIdAsAsync(int id, JsonPatchDocument bookModel);
        Task DeleteBooksAsync(int id);
    }
}
