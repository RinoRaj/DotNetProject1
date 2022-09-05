using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModel
{
    internal class Contact
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactManagerConstants.MaxFisrtNameLength)]
        public string FistName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactManagerConstants.MaxLastNameLength)]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(ContactManagerConstants.MaxEmailLength)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(ContactManagerConstants.MaxPhoneLength)]
        [Phone(ErrorMessage ="Invalid Phone number")]
        public string PhonePrimary { get; set; }
        [Display(Name = "Alternate Mobile Number")]
        [Required(ErrorMessage = "An alternate mobile number is required")]
        [StringLength(ContactManagerConstants.MaxPhoneLength)]
        [Phone(ErrorMessage ="Invalid phone number")]
        public string PhoneSecondary { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Street Address")]
        [StringLength(ContactManagerConstants.MaxAddressLength)]
        public string StreetAddress1 { get; set; }
        [Display(Name = "Street Address")]
        [StringLength(ContactManagerConstants.MaxAddressLength)]
        public string StreetAddress2 { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(ContactManagerConstants.MaxCityLength)]
        public string City { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zip Code")]
        [StringLength(ContactManagerConstants.MaxZipCodeLength)]
        public string Zip { get; set; }
        public int SateId { get; set; }
        public virtual State State { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FistName} {LastName}";
        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation} ,{Zip}" :
                                                        string.IsNullOrWhiteSpace(StreetAddress2) ? $"{StreetAddress1}  ,{City}, {State.Abbreviation} ,{Zip}"
                                                         : $"{StreetAddress1} , {StreetAddress2} ,{City}, {State.Abbreviation} ,{Zip}" ;
    }
}
