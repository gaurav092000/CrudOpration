using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOpration.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage ="please enter Name")]
        public string CategoryName { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage ="please enter description")]
        public string Description { get; set; }
        [DisplayName("Status")]
        //[ScaffoldColumn(false)]
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}