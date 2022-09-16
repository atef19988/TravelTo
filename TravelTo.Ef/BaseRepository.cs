using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelTo.Core.InterFaces;
using TravelTo.Ef.Data;

namespace TravelTo.Ef
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        #region Declartion
        TrvelToDbContext _db;
        #endregion

        #region Ctor
        public BaseRepository(TrvelToDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Method
        public async Task<bool> Add(T table)
        {
            try
            {

                await _db.Set<T>().AddAsync(table);
                await _db.SaveChangesAsync();
                return true;
            }


            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(T table)
        {
            try
            {

                _db.Set<T>().Update(table);
                await _db.SaveChangesAsync();
                return true;
            }


            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var oT = _db.Set<T>().Find(id);
                if (oT != null)
                    _db.Set<T>().Remove(oT);
                await _db.SaveChangesAsync();
                return true;
            }


            catch (Exception)
            {
                return false;
            }
        }


        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByCriteria(Expression<Func<T, bool>> Criteria)
        {

            return await _db.Set<T>().Where(Criteria).FirstOrDefaultAsync();

        }

        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListByCriteria(Expression<Func<T, bool>> Criteria)
        {
            return await _db.Set<T>().Where(Criteria).ToListAsync();
        }

        #endregion

    }
}
