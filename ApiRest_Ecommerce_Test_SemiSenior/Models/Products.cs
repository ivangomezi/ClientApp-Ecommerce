using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Ecommerce_Test_SemiSenior.Models
{
    public class Products
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_Product { get; set; }
        public string Cod_Product { get; set; }
        public string Name_Product { get; set; }
        public string Desc_Product { get; set; }
        public int Price_Product { get; set; }
        public string Img_Product { get; set; }
    }
}
