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
            User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(2);
         
            UserRegister_AssistantMethods.FillRegisterForm(user1);

                Thread.Sleep(2000);
                var expectedURL = "https://localhost:44349/Auth/Login";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");
                Console.WriteLine("TC3 Completed Successfully");


        }


        [TestMethod]
        public void TestFailedRegister_invalidEmail()
        {
            for (int i = 3; i <= 5; i++)
            {
                try
                {
                    CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
                    User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(i);
                    UserRegister_AssistantMethods.FillRegisterForm(user1);
                    Thread.Sleep(2000);
                    var expectedURL = "https://localhost:44349/Auth/RegisterUser";
                    var actualURL = ManageDriver.driver.Url;
                    Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC2");
                    Console.WriteLine("TC2 Completed Successfully");
                }
              catch (Exception ex)
                {
                    Console.WriteLine($"TC{i} Failed _ {ex.Message}");
                }
            }
           
        }


        [TestMethod]
        public void TestFaildRegister_InvalidBirthdate()
        {
            Worksheet worksheet = CommonMethods.ReadExcel("Register");

            for (int i = 6; i <= worksheet.NotEmptyRowMax; i++)
            {
                try
                {
                    CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
                    User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(i);
                    UserRegister_AssistantMethods.FillRegisterForm(user1);
                    Thread.Sleep(2000);

                    switch (i)
                    {
                        case 6:
                            var expectedValidation = (string)worksheet.Cell(i, 11).Value;
                            var actualValidation = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation);
                            Console.WriteLine($"TC{i} completed successfully");
                            break;
                        case 7:
                            var expectedValidation2 = "Age under the legal age";
                            var actualValidation2 = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;
                            Assert.AreEqual(expectedValidation2, actualValidation2);
                            Console.WriteLine($"TC{i} completed successfully");

                            break;
                        case 8:
                            var expectedResult = "https://localhost:44349/Auth/RegisterUser";
                            var actualResult = ManageDriver.driver.Url;
                            Assert.AreEqual(expectedResult, actualResult, "The actual result not equal the expected_TC3");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;
                    }
                   }

                catch (Exception ex)
                {
                    Console.WriteLine($"TC{i} failed _ {ex.Message}");
                }
            }
            
        }

       


    }
}
