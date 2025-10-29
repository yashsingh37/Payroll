using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRoll_Practies_Exam_2.Models
{
    public class tblUser
    {
        [Display(Name = "User Id")]
        public int c_userid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username can't be blank!")]
        public string c_username { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address!")]
        public string c_email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender can't be blank!")]
        public string c_gender { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password can't be blank!")]
        public string c_password { get; set; }

    }
}