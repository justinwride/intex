using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntexSample.Models
{
    public class CustomerAccount
    {
        //account info 
        //FK
        public int accountID { get; set; }

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
        [DataType(DataType.PhoneNumber)]
        public String custPhoneNumber { get; set; }

        public String custBalanceDue { get; set; }

    }
}