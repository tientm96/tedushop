using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    //xem giải thích cụ thể trong: ProductCategoryRepository 
    public interface IErrorRepository : IRepository<Error>
    {
        //những nghiệp vụ riêng đc abstract trong này, 
        // cũng giống như RepositoryBase, ở đây cũng kế thừa từ IRepository.
    }

    //kế thừa những nghiệp vụ chung ở trong RepositoryBase,
    // implement các nghiệp vụ riêng trong IErrorRepository ở trên.
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        //base(dbFactory): gọi và truyền param đến hàm tạo của lớp cha.
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}