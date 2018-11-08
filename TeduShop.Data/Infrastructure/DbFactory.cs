namespace TeduShop.Data.Infrastructure
{
    /*
     Factory: là giao tiếp để khởi tạo các object Entity (khởi tạo dbContext). 
     Các đối tượng Entity ta KHÔNG tạo trực tiếp mà phải thông qua Factory.

     +tạo DbFactory kế thừa từ Disposable và IDbFactory: Khởi tạo dbContext và hủy dbContext
     */

    public class DbFactory : Disposable, IDbFactory
    {
        private TeduShopDbContext dbContext;

        // triển khai từ interface IDbFactory
        public TeduShopDbContext Init()
        {
            return dbContext ?? (dbContext = new TeduShopDbContext());
        }


        //override từ Disposable
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}