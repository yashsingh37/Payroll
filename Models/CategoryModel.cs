using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRoll_Practies_Exam_2.Models
{
    public class CategoryModel
    {
        [Display(Name = "Category Id")]
        public int c_categoryid { get; set; }

        [Display(Name = "Designation ")]

        public string c_categoryname { get; set; }
    }
}