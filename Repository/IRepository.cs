using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity, bool isEncrypt = false);
        void Insert(IEnumerable<T> entities, bool isEncrypt = false);
    }
}
