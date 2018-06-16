using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        //có 2 trường đều là key(khóa chính) thì phải có Order 1, 2 để phân biệt
        [Key]
        [Column(Order = 1)] 
        public int OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { set; get; }

        public int Quantitty { set; get; }

        //Tạo khóa ngoại. OrderID chính là ID bên Order tham chiếu qua. Ta tạo khóa ngoại ở đây,
        //  rồi xác nhận bên Order.
        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
    }
}