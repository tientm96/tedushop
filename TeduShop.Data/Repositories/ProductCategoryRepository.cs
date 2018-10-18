using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    //nếu tương tác table có nghiệp vụ riêng nằm ngoài các nghiệp vụ chung của RepositoryBase, thì sẽ viết thêm phương thức đó.
    //Bằng cách viết Interface, rồi viết gọi thêm bên dưới.
    // => ở đây viết thêm phương thức GetByAlias();
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        //phương thức viết thêm, ko nằm trong các phương thức có sẵn của IRepository
        //IEnumerable: sẽ trả về 1 list
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        //constructor
        //Ở đây sẽ kế thừa lại các nghiệp vụ chung đã đc define trong RepositoryBase, lúc này các nghiệp vụ chung sẽ đc dùng dễ dàng, ko duplicate code.
        
        //Nếu tương tác table có nghiệp vụ riêng nằm ngoài các nghiệp vụ chung của RepositoryBase, thì sẽ viết thêm phương thức đó.
        //Bằng cách viết Interface, rồi viết gọi thêm bên dưới => ở đây viết thêm phương thức GetByAlias();
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            //base(dbFactory): gọi đến hàm tạo của lớp cha và truyền vào 1 dbFactory để khởi tạo DbContext 
            //(vì mỗi lần DbContext ko dùng tới hoặc dùng xong ở 1 hành động của table nào đó sẽ được tự động hủy bằng Disposable gọi trong DbFactory)
        }

        //phương thức viết thêm, ko nằm trong các phương thức có sẵn của RepositoryBase
        //IEnumerable: sẽ trả về 1 list
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}