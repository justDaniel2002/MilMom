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
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public int Quantity { get; set; }
        //
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        //
        public int CartID { get; set; }
        [ForeignKey("CartID")]
        public Cart Cart { get; set; }

    }
}
