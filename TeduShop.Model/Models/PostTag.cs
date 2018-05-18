using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 1)] //có 2 trường đều là key thì phải có Order 1, 2 để phân biệt
        public int PostID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order =2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        //tạo khóa ngoại
        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}