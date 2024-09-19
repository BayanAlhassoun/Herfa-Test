using HerfaTest.Helpers;
using HerfaTest.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.TestMethods
{
    [TestClass]
    public class UserRegister_TestMethods
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            ManageDriver.CloseDriver();
        }

        [TestMethod]
        public void TestSuccessRegister()
        {


            CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
            Thread.Sleep(5000);
            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);
            userRegisterPage.EnterFirstName("Rinad");
            userRegisterPage.EnterLastName("Mohammad");
            userRegisterPage.EnterEmail("Rinad123@gmail.com");
            userRegisterPage.EnterBirthdate("02-02-1999");
            userRegisterPage.EnterPhoneNumber("07828392333");
            userRegisterPage.ClickFemaleButton();
            userRegisterPage.EnterPassword("Ba@123456");
            userRegisterPage.EnterConfirmPassword("Ba@123456");
            userRegisterPage.ClickSubmitButton();

                Thread.Sleep(2000);
                var expectedURL = "https://localhost:44349/Auth/Login";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");
                Console.WriteLine("TC3 Completed Successfully");


        }


        [TestMethod]
        public void TestFailedRegister_invalidEmail()
        {

            CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
            Thread.Sleep(5000);

            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);
            userRegisterPage.EnterFirstName("Rinad");
            userRegisterPage.EnterLastName("Mohammad");
            userRegisterPage.EnterEmail("Rinad123gmail.com");
            userRegisterPage.EnterBirthdate("02-02-1999");
            userRegisterPage.EnterPhoneNumber("0782839233312");
            userRegisterPage.ClickFemaleButton();
            userRegisterPage.EnterPassword("Ba@123456");
            userRegisterPage.EnterConfirmPassword("Ba@123456");
            userRegisterPage.ClickSubmitButton();
            Thread.Sleep(2000);
            var expectedURL = "https://localhost:44349/Auth/RegisterUser";
            var actualURL = ManageDriver.driver.Url;
            Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC2");
            Console.WriteLine("TC2 Completed Successfully");
        }


        [TestMethod]
        public void TestFaildRegister_InvalidBirthdate()
        {
            CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
            Thread.Sleep(5000);
            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);
            userRegisterPage.EnterFirstName("Rinad");
            userRegisterPage.EnterLastName("Mohammad");
            userRegisterPage.EnterEmail("Rinad1234@gmail.com");
            userRegisterPage.EnterBirthdate("02-02-2010");
            userRegisterPage.EnterPhoneNumber("07828326633312");
            userRegisterPage.ClickFemaleButton();
            userRegisterPage.EnterPassword("Ba@123456");
            userRegisterPage.EnterConfirmPassword("Ba@123456");
            userRegisterPage.ClickSubmitButton();
            Thread.Sleep(2000);

            var expectedResult = "https://localhost:44349/Auth/RegisterUser";
            var actualResult = ManageDriver.driver.Url;
            Assert.AreEqual(expectedResult, actualResult, "The actual result not equal the expected_TC3");
            Console.WriteLine("TC3 Completed Successfully");
        }



    }
}
