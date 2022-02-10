using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Ecommerce_Test_SemiSenior.Models
{
    public class Users
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_User { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Id_Rol { get; set; }
        public string Rol { get; set; }
        public int error { get; set; }
    }
}
