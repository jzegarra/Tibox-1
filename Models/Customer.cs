using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tibox.Models
{    
    [Table("Customer")]    
    public class Customer
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(40,ErrorMessage ="The max lenght is 40 chars.")]
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [Computed]
        public IEnumerable<Order> Orders { get; set; }
    }
}
