using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostCategoryViewModel
    {
        //copy từ Models của pr Model qua. 
        // Ở đây chỉ là các class bt, ko sử dụng để gen ra, nên bỏ hết các
        //      key hay Required làm gì.
        public int ID { set; get; }
        public string Name { set; get; }


        public string Alias { set; get; }
        public string Description { set; get; }

        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        public string Image { set; get; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<PostViewModel> Posts { set; get; }



        //các tham số trong abstract class IAuditable, tại pr Model.  
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