using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace UserRegistrationUsingAnnotation
{
  public  class UserRegistrationFactory
    {
        public object CreateValidationObject(string className, string constructor)
        {
            string p = @"." + constructor + "$";
            Match result = Regex.Match(className, p);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (Exception)
                {
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }
        public object CreateParameterizedObject(string className, string constructor, string message)
        {
            Type type = typeof(Validation);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "No constructor found");

                }

            }

            else
            {
                throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");

            }
        }
        public string InvokeMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(Validation);

                MethodInfo methodInfo = type.GetMethod(methodName);
                UserRegistrationFactory factory = new UserRegistrationFactory();
                object moodAnalyserObject = factory.CreateParameterizedObject("UserRegistrationUsingAnnotation.Validation", "Validation", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.METHOD_NOT_FOUND, "Method not found");
            }
        }

        public string SetField(string message, string fieldName)
        {
            try
            {
                Validation moodAnalyser = new Validation();
                Type type = typeof(Validation);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_FIELD, "Feild is not found");
            }
        }

    }
}
