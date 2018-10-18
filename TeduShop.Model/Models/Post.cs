using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        //string có  thể là varchar hay nvarchar. Ở đây chỉ ra chính xác kdl của nó là varchar.
        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")] 
        public string Alias { set; get; }

        [Required] //cần thiết, ko đc null
        public int CategoryID { set; get; }

        [MaxLength(256)] //string: null thì ko cần Required. cần có độ dài nhất định, nếu ko default sẽ là nvarchar(max).
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Content { set; get; }

        public bool? HomeFlag { set; get; } //?: cho phép null
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }


        //tạo khóa ngoại.
        //  CategoryID chính là ID từ PostCategory tham chiếu qua. Ở đây ta tạo khóa ngoại, và
        //      tại class PostCategory ta phải xác nhận khóa ngoại đó.
        [ForeignKey("CategoryID")]
        public virtual PostCategory PostCategory { set; get; }


        //Xác nhận khóa ngoại, từ Post tham chiếu đến PostTag.
        public virtual IEnumerable<PostTag> PostTags { set; get; }
    }
}