using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface INewsRepository
    {
        IQueryable<NewsBlock> GetAllNews();
        NewsBlock GetNewsById(Guid ID);
        void AddAndSaveNewNew(NewsBlock newNewsBlock);
        void DeleteNew(Guid id);
    }
}
