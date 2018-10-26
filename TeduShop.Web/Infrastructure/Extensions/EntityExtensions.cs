using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    //class static là class mà chỉ có static method mà thôi.
    //Xem lại lý thuyết về Extensions method trong file lý thuyết ctdlgt
    public static class EntityExtensions
    {
        /*Method UpdatePostCategory sẽ update class PostCategory.
         *Khi đó all object của PostCategory sẽ có thêm method UpdatePCatego này.
         * Nếu gọi method UpdatePostCategory thì truyền vào model(=postCategoryVm). 
         * Khi đó ở đây sẽ tự động copy toàn bộ giá trị của postCategoryVm bên phải đẩy vào this postCategory bên trái.*/

        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            //copy từ Web.Models.PostCategoryViewModel vào, lấy mẫu để viết 
            //  lại các lệnh update.

            //public int ID { set; get; } //copy vào để đây, nhìn và viết tương tự bên dưới, viết xong r xóa những cái này cũng đc.
            //public string Name { set; get; }

            //public string Alias { set; get; }
            //public string Description { set; get; }

            //public int? ParentID { set; get; }
            //public int? DisplayOrder { set; get; }...

            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            //các tham số trong abstract class IAuditable, tại pr Model.  
            //  vì nó có liên quan đến, nên cần copy qua.
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            //các tham số trong abstract class IAuditable, tại pr Model.  
            //  vì nó có liên quan đến, nên cần copy qua.
            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }
    }
}