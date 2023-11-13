using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Insert(T entity);
        void Update(T entity);
        void Remove(long ID);
        T GetByID(long ID);
        IList<T> GetAll();

    }
}
