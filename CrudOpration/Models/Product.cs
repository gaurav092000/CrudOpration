using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOpration.Models
{

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "please enter Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="please enter desc")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "please enter price")]
        public string ProductPrice { get; set; }

        [Required(ErrorMessage = "please Select Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

      
    }
}