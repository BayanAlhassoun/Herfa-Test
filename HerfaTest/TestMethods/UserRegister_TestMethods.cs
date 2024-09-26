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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace HerfaTest.TestMethods
{
    [TestClass]
    public class UserRegister_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\");
      
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            extentReports.Flush();
            ManageDriver.CloseDriver();
        }

        [TestMethod]
        public void TestSuccessRegister()
        {
            var test = extentReports.CreateTest("TestSuccessRegister", "verify that on passing valid data to register form, the data added correctly");

            try
            {
                CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
                User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(2);

                UserRegister_AssistantMethods.FillRegisterForm(user1);

                Thread.Sleep(2000);

                Assert.IsTrue(UserRegister_AssistantMethods.CheckSuccessRegister(user1.email));


                var expectedURL = "https://localhost:44349/Auth/Login";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");
                Console.WriteLine("TC3 Completed Successfully");
                test.Pass("Registered Successfully");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }

        }


        [TestMethod]
        public void TestFailedRegister_invalidEmail()
        {
            var test = extentReports.CreateTest("TestFailedRegister_invalidEmail", "TestFailedRegister_invalidEmail");
            for (int i = 3; i <= 5; i++)
            {
                try
                {
                    CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
                    test.Log(Status.Info, "Navigate to register page done successfully");
                    User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(i);
              
                    UserRegister_AssistantMethods.FillRegisterForm(user1);
                    Thread.Sleep(2000);
                    var expectedURL = "https://localhost:44349/Auth/RegisterUser";
                    var actualURL = ManageDriver.driver.Url;
                    Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC2");
                    Console.WriteLine("TC2 Completed Successfully");
                    test.Pass($"TC{i} Passed");
                }
              catch (Exception ex)
                {
                    test.Fail(ex.Message) ;
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }
           
        }


        [TestMethod]
        public void TestFaildRegister_InvalidBirthdate()
        {
            Worksheet worksheet = CommonMethods.ReadExcel("Register");
            var test = extentReports.CreateTest("TestFaildRegister_InvalidBirthdate", "TestFaildRegister_InvalidBirthdate");

            for (int i = 6; i <= 8; i++)
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
                
                            var expectedResult1 = "https://localhost:44349/Auth/RegisterUser";
                            var actualResult1 = ManageDriver.driver.Url;
                            Assert.AreEqual(expectedResult1, actualResult1, "The actual result not equal the expected_TC3");

                            test.Log(Status.Info, "First Assert Passed");

                            var expectedValidation = (string)worksheet.Cell(i, 11).Value;
                            var actualValidation = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation);

                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;
                        case 7:
                            var expectedValidation2 = "Age under the legal age";
                            var actualValidation2 = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;
                            Assert.AreEqual(expectedValidation2, actualValidation2);
                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");

                            break;
                        case 8:
                            var expectedResult = "https://localhost:44349/Auth/RegisterUser";
                            var actualResult = ManageDriver.driver.Url;
                            Assert.AreEqual(expectedResult, actualResult, "The actual result not equal the expected_TC3");
                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;
                    }
                   }

                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }
            
        }

       


    }
}
