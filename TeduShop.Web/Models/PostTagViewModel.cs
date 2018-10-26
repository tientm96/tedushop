using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        //tạo khóa ngoại, vì là viewModel nên đã bỏ dòng [ForeignKey("PostID")]
        public virtual PostViewModel Post { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}