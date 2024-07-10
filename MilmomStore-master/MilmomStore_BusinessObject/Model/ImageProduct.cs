using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    [Table("ImageProduct")]
    public class ImageProduct
    {
        [Key]
        public int ImageProductsID { get; set; }
        [Required]
        public string Image { get; set; }
        //
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Products { get; set; }
    }

}
