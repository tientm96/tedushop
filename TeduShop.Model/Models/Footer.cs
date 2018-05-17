using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    //nhớ sửa thành public class thì mới dùng entity đc.
    [Table("Footers")] //để dùng đc entity, tạo ra table Footers trong db

    public class Footer
    {
        //Tạo từng thuộc tính theo từng cột của table Footers
        [Key] //chỉ ra đây là thuộc tính key, để khi generate ra db nó phù hợp.
        [MaxLength(50)]
        public string ID { set; get; }

        [Required] //cần thiết, nghĩa ko cho phép null
        public string Content { set; get; }
    }
}
