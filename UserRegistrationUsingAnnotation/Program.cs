using System;
using UserRegistrationAnnotations;

namespace UserRegistrationUsingAnnotation
{
    class Program
    {
        static void Main(string[] args)
        {

            Validation validator = new Validation();
            validator.GetInput();
        }
    }
}
