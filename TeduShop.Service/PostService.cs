using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Service
{
    /*Ta ko nhất thiết phải tạo mỗi service cho mỗi table, vì ta có thể tạo 1 service thao tác trên nhiều table gọi nhiều repository.
     * vd: Post và PostTag thao tác trên cùng service.
     * 
     * Mỗi hành động sẽ gọi đến service, sau đó service sẽ gọi đến Repository ở data để xử lý.
     * Bên prj Data, mỗi table có một Repository kế thừa các tác vụ chung và tạo thêm các tác vụ riêng.
     */
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        //IEnumerable: trả về 1 list
        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        /*Mặc dù có object, nhưng ta vẫn khai báo và khởi tạo qua Interface, đảm bảo quy tắc SOLID là các module tương tác qua abstraction. 
         */
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        /* Constructor:
         * Cơ chế dependence Injection giúp tiêm các object (đã implement interface) tương ứng vào constructor, 
         * ta chỉ cần cho nó biết dạng interface cần tiêm, truyền object implement nó vào thì interface sẽ tiêm object đó.
         * 
         * Khai báo bằng Interface để khi truyền object vào sẽ linh hoạt hơn, truyền vào object nào implement nó thì nó sẽ làm việc theo object đó.
         * Ở đây khi truyền vào ta sẽ truyền object của class PostRepository (đã implement IPostRepository), lúc này Dependence Injection sẽ tiêm theo obj của
         * class PostRepository truyền vào này.
         * 
         * => linh hoạt hơn rất nhiều nếu như có nhiều class cùng implement Interface đó.
         *
         * Cách viết này giúp có thể testing dễ dàng.
         * 
         */
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by tag
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);

        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}