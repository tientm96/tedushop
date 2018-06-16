using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        //-Với kiểu string, nếu không cho null thì phải có [Required];
        //      Nếu cho null thì KHÔNG có [Required].

        //-Còn đối với int, nếu CHO null thì phải public int? ID { set; get; }, có dấu ? sau int;
        //      nếu KHÔNG cho null thì cũng [Required] như string.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ID tự tăng
        public int ID { set; get; }

        [Required]
        [MaxLength(50)] //chỉ có string hoặc array mới dùng maxlength.
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string URL { set; get; }

        public int? DisplayOrder { set; get; } //cho phép null

        [Required]
        public int GroupID { set; get; }

        //vì GroupID là khóa ngoại, nên phải tham chiếu ở đây, và xác nhận ở class MenuGroup.
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { set; get; }

        [MaxLength(10)]
        public string Target { set; get; } //ko có [Required], cho phép null

        public bool Status { set; get; }
    }
}

