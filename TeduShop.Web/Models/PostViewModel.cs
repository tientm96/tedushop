using System;
using System.Collections.Generic;

namespace TeduShop.Web.Models
{
    public class PostViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public int CategoryID { set; get; }

        public string Image { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public bool? HomeFlag { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

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

        //tạo khóa ngoại đến CategoryID, vì là viewModel nên đã bỏ dòng [ForeignKey("CategoryID")]
        public virtual PostCategoryViewModel PostCategory { set; get; }

        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}