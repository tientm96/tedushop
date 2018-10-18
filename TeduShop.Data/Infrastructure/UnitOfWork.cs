using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    //UnitOfWork cũng là design pattern có sẵn, nên copy vào dùng thôi.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TeduShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        //vì không có () nên đây chỉ là Property, KHÔNG phải method()
        public TeduShopDbContext DbContext 
        {
            //toán tử ??: nếu dbContext != null thì trả về dbContext(bên trái sát return).
            //      nếu dbContext == null thì trả về dbContext=dbFactory.Init().
            //          Câu lệnh dưới còn đồng thời gán dbContext = dbFactory.Init()
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            //với DbContext là property của dbContext, nên DbContext cũng như 1 đối tượng.
            //dbContext là 1 đối tượng của TeduShopDbContext:DbContext
            DbContext.SaveChanges();
        }
    }
}
