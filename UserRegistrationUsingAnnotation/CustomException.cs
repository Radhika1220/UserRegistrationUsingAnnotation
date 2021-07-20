using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistrationUsingAnnotation
{
   
        public class CustomException : Exception
        {
            ExceptionType type;
            public string message;

            public enum ExceptionType
            {
                CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND, METHOD_NOT_FOUND, NO_SUCH_FIELD, EMPTY_MESSAGE
            }
            public CustomException(ExceptionType type, string message) : base(message)
            {
                this.type = type;
            }
        }
    }


