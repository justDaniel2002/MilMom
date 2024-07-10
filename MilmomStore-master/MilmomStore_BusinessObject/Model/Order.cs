using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
        public double Total { get; set; }
        
        public int? ReportID { get; set; }
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public AccountApplication AccountApplication { get; set; }

        public string? transactionID { get; set; }
        public int? ShippingInforID { get; set; }
        
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
        //
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Transaction? Transaction { get; set; }
        public ShippingInfor ShippingInfor { get; set; } = null!;
        public Report? Report { get; set; }
        
    }

    public enum PaymentMethod
    {
        Cod = 0,
        VnPay = 1
    }

    public enum OrderStatus
    {
        ToPay = 0,
        ToConfirm = 1,
        ToShip = 2,
        ToReceive = 3,
        Completed = 4,
        Cancelled = 5,
        ReturnRefund = 6,
        RequestReturn = 7
    }

}
