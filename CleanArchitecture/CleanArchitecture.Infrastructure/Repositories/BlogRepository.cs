using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs.Where(m => m.id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<int> UpdateAsync(int id,Blog blog)
        {
            return await _blogDbContext.Blogs
                .Where(m => m.id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.id, blog.id)
                .SetProperty(m => m.name, blog.name)
                .SetProperty(m => m.description, blog.description)
                .SetProperty(m => m.auther, blog.auther)
                .SetProperty(m => m.url, blog.url)
                );
        }
    }
}
