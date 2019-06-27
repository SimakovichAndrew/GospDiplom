using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class LoginModel
    {
        //  [Required]
        public string Email/*UserName*/ { get; set; }
        // [Required]
        //  [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}