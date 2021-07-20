using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using UserRegistrationUsingAnnotation;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void Test_Method_Create_Object()
        {
            Validation validation = new Validation();
            object obj = null;
            try
            {
                UserRegistrationFactory userRegistrationFactory = new UserRegistrationFactory();
                obj = userRegistrationFactory.CreateValidationObject("UserRegistrationUsingAnnotation.Validation", "Validation");
            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.message);
            }

        }
        [TestMethod]
        public void Reflection_Return_Parameterized_Constructor()
        {
            string message = "Validating user details";
            Validation expected = new Validation(message);
            object actual = null;
            try
            {
                UserRegistrationFactory factory = new UserRegistrationFactory();
                actual = factory.CreateParameterizedObject("UserRegistrationUsingAnnotation.Validation", "Validation", message);

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
            actual.Equals(expected);
        }
        [TestMethod]
        public void Reflection_Return_Set_Feild()
        {
            string expected = "Validating user details";
            UserRegistrationFactory factory = new UserRegistrationFactory();
            string actual = factory.SetField(expected, "message");
            Assert.AreEqual(expected, actual);


        }
    }
}
