    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRoll_Practies_Exam_2.Models
{
    public class EmployeModel
    {
        [Display(Name = "EmployeeId")]
        public int c_empid { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        public string c_empname { get; set; }
        [Display(Name = "Category Id")]
        public int c_categoryid { get; set; }

        [Display(Name = "Designation")]

        public string c_categoryname { get; set; }
        [Display(Name = "Gender")]
        [Required]

        public string c_gender { get; set; }
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [Required]

        public string c_hiredate { get; set; }
        [Display(Name = "Gross Salary")]
        [Required]

        public int c_salary { get; set; }
        [Display(Name = "Basic")]

        public int c_basic { get; set; }
        [Display(Name = "Da")]

        public int c_da { get; set; }
        [Display(Name = "Hra")]

        public int c_hra { get; set; }
        
        [DisplayName("Taxable")]
        [Display(Name = "Tax")]
        public int c_taxable { get; set; }
        public int c_tax { get; set; }
        [Display(Name = "Take Home")]

        public int c_takehome { get; set; }

    }
}