using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaListRazor.Model
{
    public class Emp
    {
        [Key]
        public int EmpID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string EmpName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string PassWd { get; set; }
        
    }
}
