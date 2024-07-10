using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace MilmomStore_BusinessObject.Model
{
    public class AccountApplication : IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string? Image { get; set; }

        //public bool Status { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        //
        
        public ICollection<CartItem> CartItems { get; set; }

        
        public ICollection<Report> Reports { get; set; }
        
        
        public ICollection<Order> Orders { get; set; }

        
        public ICollection<Blog> Blogs { get; set; }

        
        public ICollection<Review> Reviews { get; set; }


    }
}
