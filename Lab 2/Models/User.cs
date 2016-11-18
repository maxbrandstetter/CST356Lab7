using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(32)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(32)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(64)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Number of Siblings")]
        public string NumberOfSiblings { get; set; }

        public List<Group> Groups { get; set; }

        [NotMapped]
        public bool OnlyChild { get; set; }
    }
}