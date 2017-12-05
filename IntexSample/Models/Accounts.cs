using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexSample.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [DisplayName("Username")]
        [StringLength(30)]
        public String AccountName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DisplayName("Password")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        public String AccountPassword { get; set; }

        public String AccountType { get; set; }
    }
}