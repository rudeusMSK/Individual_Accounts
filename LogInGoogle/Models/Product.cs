using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogInGoogle.Models
{
    [Table("Tb1_Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        
        // table
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}