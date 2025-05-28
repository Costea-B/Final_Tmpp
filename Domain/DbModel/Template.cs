using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModel
{
     public class Template
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public Guid Id { get; set; }
          [Required]
          [Column(TypeName = "nvarchar(max)")]
          public string JsonTemplate {  get; set; }
          [Required]
          [Column(TypeName = "nvarchar(100)")]
          public string Type { get; set; } // ex: Lunch, Dinner, etc.
     }
}
