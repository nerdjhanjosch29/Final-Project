using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace wow.Models
{
    public class Type
    {
        
     public int Id { get; set; }
     [Required]

     [StringLength(50)]
     [DisplayName("Type")]
     public string Name { get; set; }
     public Item Item { get; set; }
     public int Itemid { get; set; }

    }
}