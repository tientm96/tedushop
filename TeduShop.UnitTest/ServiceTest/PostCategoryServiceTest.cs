using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    //Test nghiệp vụ (service): Test bằng kỹ thuật MOCK đối tượng, giả lập đối tượng:
    //Trong extension moq có đối tượng ảo MOCK, đối tượng này sẽ cho biết mình đang test cho dạng repository nào.

    //DÙNG MOCK ĐỂ TEST NGHIỆP VỤ: giả lập đối tượng
    [TestClass]
    public class PostCategoryServiceTest
    {
        //Mock: tạo đối tượng giả, chưa cần hoàn thiện xong class thì ta đã test đc method trong class đó rồi,
        //  nhờ vào việc dùng Mock.
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;


        //thiết lập method chạy đầu tiên của class, để khởi tạo các đối tượng của class test
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID =1 ,Name="DM1",Status=true },
                new PostCategory() {ID =2 ,Name="DM2",Status=true },
                new PostCategory() {ID =3 ,Name="DM3",Status=true },
            };
        }

        //bắt đầu test thì test method này đầu.
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count); //list có 3 ptu add ở trên. vậy nên so sánh với 5 sẽ ra kq test này faild
        }

        // method này viết sau nên sẽ đc test sau.
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            int id =1;
            category.Name = "Test";
            category.Alias = "test";
            category.Status = true;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID); //mỗi lần create thì số này tăng lên

        }
    }
}
