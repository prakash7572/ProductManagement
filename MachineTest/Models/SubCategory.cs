using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineTest.Models
{
    [Table("SubCategorys")]
    public class SubCategory
    {
        public int ID { get; set; }
        public int CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public bool Status { get; set; }
      
    }
}