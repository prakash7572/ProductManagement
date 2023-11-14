using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
    public class CategoryDrop
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
     public class SubCategoryDrop
    {
        public int ID { get; set; }
        public string SubCategoryName { get; set; }
    }
}