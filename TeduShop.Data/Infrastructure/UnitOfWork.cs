using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
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
            //toán tử ??: nếu dbContext != null thì trả về dbContext.
            //      nếu dbContext == null thì trả về dbFactory.Init().
            //          Câu lệnh dưới còn đồng thời gán dbContext = dbFactory.Init()
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
