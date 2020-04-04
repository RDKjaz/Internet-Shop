using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstSite.Models
{
    public class Order { 

    [BindNever]
    public int id { get; set; }
    [Display(Name = "Введите имя")]
    [StringLength(25)]
    [Required(ErrorMessage = "Длина имени не более 20 символов")]
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Adress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    [BindNever]
    public DateTime OrderTime { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
}
