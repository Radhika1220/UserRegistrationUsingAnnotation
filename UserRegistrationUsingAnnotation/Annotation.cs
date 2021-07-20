using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace UserRegistrationUsingAnnotation
{
    /// <summary>
    /// Annotation class
    /// </summary>
   public  class Annotation
    {
        [Required(ErrorMessage="{0} is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="First name should be minimum 3 characters")]
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Not Valid First Name")]
        [DataType(DataType.Text)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name should be minimum 3 characters")]
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Not Valid Last Name")]
        [DataType(DataType.Text)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression((@"^[a-zA-Z0-9]+([\.\+\-][a-zA-Z0-9]+)?@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,}(\.[a-zA-Z]+)?)$"), ErrorMessage = "Not Valid Email Id")]
        [DataType(DataType.EmailAddress)]
        public string emailId { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[91]+[\s]+[0-9]{10}$", ErrorMessage = "Not a valid Phone Number")]
        [Phone]
        public string phoneNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?!.*[<>`])(?=[^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*[.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\][^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*$).{8,}$", ErrorMessage = "Not Valid Passsword")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
