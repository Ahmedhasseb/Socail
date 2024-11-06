using BLL.IRepository;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly dbContext _dbContext;
        private GenericRepository<Post> _PostRepository;
        private GenericRepository<UesrProfile> _UserProfileRepository;

        public IGenericRepository<Post> PostGenericRepository => _PostRepository??new GenericRepository<Post>(_dbContext);

        public IGenericRepository<UesrProfile> UserGenericRepository => _UserProfileRepository ?? new GenericRepository<UesrProfile>(_dbContext);

        public UniteOfWork(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
           await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
