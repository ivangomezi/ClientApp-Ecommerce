using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Ecommerce_Test_SemiSenior.Models
{
    public class Buys
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_Buy { get; set; }
        public int Id_User { get; set; }
        public int Id_Product { get; set; }
        public int Quantity { get; set; }
        public int Total_Buy { get; set; }
        public string Code_Buy { get; set; }
    }
}
