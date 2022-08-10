using AutoMapper;
using BookStoreApi.Data;
using BookStoreApi.Models;

namespace BookStoreApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
