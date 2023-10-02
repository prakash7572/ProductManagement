using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineTest.Models
{
    [Table("Products")]
    public class Product
    {
        public int ID { get; set; }
        public int CategoryName { get; set; }
        public int SubCategoryName { get; set; }
        public string ProductName { get; set; }
        public string ShorDescription { get; set; }
        public string FullDescription { get; set; }
        public bool Status { get; set; }
    }
}