using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexSample.Models
{
    [Table("Customer_Personal_Information")]
    public class Customer
    {
        //customer info 
        [Key]
        public int customerID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("First Name")]
        [StringLength(30)]
        public String custFirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DisplayName("Last Name")]
        [StringLength(30)]
        public String custLastName { get; set; }

        [Required(ErrorMessage = "Please enter street address")]
        [DisplayName("Address")]
        [StringLength(30)]
        public String custAddress { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [DisplayName("City")]
        [StringLength(30)]
        public String custCity { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        [DisplayName("State")]
        [StringLength(30)]
        public String custState { get; set; }

        [Required(ErrorMessage = "Please enter zipcode")]
        [DisplayName("Zipcode")]
        [StringLength(30)]
        public String custZip { get; set; }

        [Required(ErrorMessage = "Please enter area code")]
        [DisplayName("Area code")]
        [StringLength(30)]
        public String custAreaCode { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [DisplayName("Phone Number")]
        [StringLength(30)]
        public String custPhoneNumber { get; set; }

        public String custBalanceDue { get; set; }
    }
}