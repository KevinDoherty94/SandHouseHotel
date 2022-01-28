//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolTourProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.Activities = new HashSet<Activity>();
        }
    
        [Display(Name = "Booking ID")]
        public int BookingID { get; set; }

        [RegularExpression(@"[A-Za-z\s]*", ErrorMessage = "Only letters and spaces are allowed")]
        [Required(ErrorMessage = "You need to enter your name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You need to enter your phone number")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"[A-Za-z\s]*", ErrorMessage = "Only letters and spaces are allowed")]
        [Required(ErrorMessage = "You need to enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You need to enter your email address")]
        public string Email { get; set; }

        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        [Display(Name = "Class Size")]
        public int ClassSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
