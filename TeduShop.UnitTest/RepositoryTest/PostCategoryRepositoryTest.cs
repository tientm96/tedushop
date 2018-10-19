using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        //thiết lập method chạy đầu tiên của class, để khởi tạo các đối tượng của class test
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList(); // với linq có tolist() hay toarray... thì mới bắt đầu truy vấn trả về list.
            Assert.AreEqual(5, list.Count); //vào db xem sl đang bao nhiêu, 5 là số giả định
            //test case này đặt trước nên sẽ chạy trước.
            //rồi mới test phần cre bên dưới.
        }

        // method này viết sau nên sẽ đc test sau.
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();


            //Các dạng so sánh AreEqual: so sánh bằng
            //NotAreEqual: ss không bằng... tùy mình chọn tương ứng cho các test.

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.ID); // so sánh 2 giá trị, mỗi lần
                                //test giá trị tăng lên 1, do db thêm vô 1
        }


        /*Debug Test: nếu có method test việc debug đơn giản hơn nhiều, ko cần phải build solution(F5).
         * +gán breakPoint vào bên trái như bt
         * +kích phải lên màn hình chọn debug tests
         * 
         * Nếu muốn runtest ngay, ko debug thì vào: thanh công cụ Test->window->testExplore: click phải chon run select test
         * kết quả ra dấu tích xanh thì test ok.
         */

    }
}