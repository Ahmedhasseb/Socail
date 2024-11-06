using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IUniteOfWork:IDisposable
    {
        IGenericRepository<Post> PostGenericRepository { get; }
        IGenericRepository<UesrProfile> UserGenericRepository { get; }
        Task Commit();
    }
}
