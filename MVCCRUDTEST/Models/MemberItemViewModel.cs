using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUDTEST.Models
{
    public class MemberItemViewModel
    {
        public int Id { get; set; }

        [Display(Name="帳號")]
        [Required]
        public string Account { get; set; }
        
        [Display(Name = "姓名")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "電話")]
        public string Phone { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "性別")]
        public string Sex { get; set; }
        [Display(Name = "電子郵件信箱")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "生日")]
        public Nullable<System.DateTime> Birthdate { get; set; }
    }
}