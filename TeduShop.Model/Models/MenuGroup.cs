using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        //-Với kiểu string, nếu không cho null thì phải có [Required] (CẦN THIẾT);
        //      Nếu cho null thì KHÔNG có [Required].
        //-Còn đối với int, nếu cho null thì phải public int? ID { set; get; }, có dấu ? sau int;
        //      nếu không cho null thì cũng [Required] như string.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required] //cần thiết, ko đc null
        [MaxLength(50)] // nếu ko default sẽ là nvarchar(max).
        public string Name { set; get; }

        //Vì table Menus có tham chiếu đến table MenuGroup bằng khóa ngoại GroupID.
        //  Nên ở trong Menu.cs, ta đã khai báo khóa ngoại. Còn ở MenuGroup.cs này, ta phải xác
        //      nhận, để MenuGroups có thể lấy các Menus thông qua Foreignkey.

        //Quan hệ 1-n: 1 menugroup có nhiều menu, thông qua khóa ngoại GroupID được tạo bên menu.
        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}