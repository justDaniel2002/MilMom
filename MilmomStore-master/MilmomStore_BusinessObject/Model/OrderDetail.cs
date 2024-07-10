using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public double unitPrice { get; set; }
        public double promotionPrice { get; set; }
        public double TotalAmount { get; set; }

        //public int OrderID { get; set; }
        //[ForeignKey("OrderID ")]
        public Order? Order { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID ")]
        public Product Product { get; set; }

    }

}
