using HerfaTest.Helpers;
using HerfaTest.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerfaTest.Data;
using HerfaTest.AssistantMethods;
using Bytescout.Spreadsheet;

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
            User user = new User("Batool", "Shurman", "Batool@yahoo.com", "077452462", "Bat123**", "Bat123**", Gender.Female, "01-01-2000");
            UserRegister_AssistantMethods.FillRegisterForm(user);

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
            User user = new User("Batool", "Shurman", "Batool@yahoocom", "077452462", "Bat123**", "Bat123**", Gender.Female, "01-01-2000");
            UserRegister_AssistantMethods.FillRegisterForm(user);
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
            //User user = new User("Batool", "Shurman", "Batool@yahoo.com", "077452462", "Bat123**", "Bat123**", Gender.Female, "01-01-2011");
            Worksheet worksheet = CommonMethods.ReadExcel("TestFaildRegister_InvalidBirthd");
         
            User user1 = new User();
            user1.firstName = Convert.ToString(worksheet.Cell(1, 0).Value);
            user1.lastName= (string)worksheet.Cell(1,1).Value;
            user1.email = (string)worksheet.Cell(1, 2).Value;
            user1.phoneNumber = Convert.ToString(worksheet.Cell(1, 3).Value);
            user1.gender = (Gender)Enum.Parse(typeof(Gender), (string)worksheet.Cell(1,4).Value);
            user1.Birthdate = Convert.ToString(worksheet.Cell(1, 5));
            user1.password = Convert.ToString(worksheet.Cell(1,6).Value); 
            user1.confirmPassword = Convert.ToString(worksheet.Cell(1,7).Value);
            UserRegister_AssistantMethods.FillRegisterForm(user1);
            Thread.Sleep(2000);

            var expectedResult = "https://localhost:44349/Auth/RegisterUser";
            var actualResult = ManageDriver.driver.Url;
            Assert.AreEqual(expectedResult, actualResult, "The actual result not equal the expected_TC3");
            Console.WriteLine("TC3 Completed Successfully");
        }



    }
}
