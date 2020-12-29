using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace BLL.Models.Resources
{
    public class ForgetPasswordModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
