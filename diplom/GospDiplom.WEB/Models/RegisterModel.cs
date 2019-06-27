using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class RegisterModel
    {
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        // [DataType(DataType.Password)]
        //[Compare("Password")]
        public string ConfirmPassword { get; set; }
        // [Required]
        public string Address { get; set; }
        //[Required]
        public string UserName { get; set; }
    }
}