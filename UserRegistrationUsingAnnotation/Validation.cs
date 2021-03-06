using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserRegistrationUsingAnnotation
{
    public class Validation
    {
        public string message;
        public Validation()
        {
            Console.WriteLine("Default constructor");
        }
        public Validation(string message)
        {
            this.message = message;
        }
        Annotation annotation = new Annotation();
        //Getting user details
        public void GetInput()
        {
            Console.WriteLine("Enter first name :");
            annotation.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name : ");
            annotation.lastName = Console.ReadLine();
            Console.WriteLine("Enter Email Id : ");
            annotation.emailId = Console.ReadLine();
            Console.WriteLine("Enter Phone Number :");
            annotation.phoneNum = Console.ReadLine();
            Console.WriteLine("Enter Password : ");
            annotation.password = Console.ReadLine();
            TestAnnotationFields(annotation);

        }
        public void TestMethod()
        {
            Console.WriteLine("Validating the user details......");
        }
        public void TestAnnotationFields(Annotation annotation)
        {
            ValidationContext validationContext = new ValidationContext(annotation, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(annotation, validationContext, validationResults, true);
            if (!valid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine("{0}", validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Satisfied all validations");
            }

        }

    }
}