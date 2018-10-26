using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostCategoryViewModel
    {
        //copy từ Models của pr Model qua. 
        // Ở đây chỉ là các class bt, ko sử dụng để gen ra, nên bỏ hết các [key] hay [Required] đi.
        //Tên thuộc tính trong viewModel phải giống với dataModel, thì nó mới map được(ko tính những tên mới đc add trong viewModel).
        public int ID { set; get; }
        public string Name { set; get; }

        public string Alias { set; get; }
        public string Description { set; get; }

        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        public string Image { set; get; }

        public bool? HomeFlag { set; get; }


        /*-Cơ chế này ngoài ra còn giúp mapper các đối tượng con, vd:
            ta chỉ cần tạo mapper với PostCategory, mà PostCategory là cha của Post, 
            nên lúc này khi map trong PostCategory nó cũng sẽ tự động map cho đối tượng con là Post.
         */
        //xác nhận khóa ngoại
        public virtual IEnumerable<PostViewModel> Posts { set; get; }


        //các thuộc tính dùng chung trong abstract class IAuditable tại pr Model, 
        //nhưng ở ViewModel này ko tạo IAuditable, nên sẽ đưa hết các thuộc tính dùng chung này vào trong luôn.  
        //  vì nó có liên quan đến, nên cần copy qua.
        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }


        public string UpdatedBy { set; get; }


        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}