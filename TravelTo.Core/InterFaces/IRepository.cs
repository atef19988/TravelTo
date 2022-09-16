using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelTo.Core.InterFaces
{
    public interface IRepository<T> where T : class
    {
       Task<bool> Add(T table);
        Task<bool> Update(T table);
        Task<bool> Delete(int id);

        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByCriteria(Expression<Func<T, bool>> Criteria);
        Task<List<T>> GetListByCriteria(Expression<Func<T, bool>> Criteria);





    }
}
