namespace MilmomStore_BusinessObject.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Cart
{
    [Key]
    public int CartID { get; set; }
    public string AccountID { get; set; }
    [ForeignKey("AccountID")]
    public AccountApplication AccountsApplication { get; set; }
    public ICollection<CartItem> CartItem { get; set; } = new List<CartItem>();
}