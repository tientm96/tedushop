using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TeduShop.Data.Infrastructure
{

    // dùng Generic<T>  để có thể dùng cho cho tất cả class. IRepository<T> where T : class chỉ đơn giản là cách khai báo class của Generic

    //Generic<T> đại diện cho kdl chưa biết, có thể làm việc với  bất cứ kdl nào.
    //Interface này là khuôn mẫu của design pattern IRepository, cứ copy qua mà dùng.
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        T Delete(T entity);

        T Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int id
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);


        //includes: thêm các table con vào.
        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}