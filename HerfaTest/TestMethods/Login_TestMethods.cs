using HerfaTest.AssistantMethods;
using HerfaTest.Data;
using HerfaTest.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.TestMethods
{
    [TestClass]
    internal class Login_TestMethods
    {
        [ClassInitialize]
        public static void ClassInitializeLogin(TestContext testContext)
        {
            ManageDriver.MaximizeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            ManageDriver.CloseDriver();
        }

        [TestMethod]
        public void TestValidLogingForUser_TC1()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);
            Login_AssistantMethods.FillLoginForm("batoolshurman23@gmail.com", "BATool20*");
            var expectedURL = "https://localhost:44349/User";
            var actualURL = ManageDriver.driver.Url;
            Assert.AreEqual(expectedURL, actualURL, "Actual URL not the same with expected URLTC1");
            Console.WriteLine("TC1 Completed Successfully.");
        }

        [TestMethod]
        public void TestInvalidLoging_InvalidEmail_TC2()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);

            Login_AssistantMethods.FillLoginForm("batools@gmail.com", "BAtool20*");

            var expectedAlert = ManageDriver.driver.FindElement(By.XPath("//ul/li[contains(text(),'The email entered is not registered in the system')]")).GetAttribute("innerText");
            var actualAlert = "The email entered is not registered in the system";
            Assert.AreEqual(expectedAlert, actualAlert, "The message will not appear when user enter invalid email-TC2.A");

            Thread.Sleep(3000);

            var expectedURL = "https://localhost:44349/Auth/Login";
            var actualURL = ManageDriver.driver.Url;

            Thread.Sleep(3000);
            Assert.AreEqual(expectedURL, actualURL, "Actual URL not the same with expected URL-TC2.B");
            Console.WriteLine("TC2 Completed Successfully.");
        }

        [TestMethod]
        public void TestInvalidLoging_InvalidPaaword_TC3()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);


            Login_AssistantMethods.FillLoginForm("batoolshurman23@gmail.com", "12.4ahsb");

            Thread.Sleep(3000);
            var expectedAlert = ManageDriver.driver.FindElement(By.XPath("//ul/li[contains(text(),'Wrong Password')]")).Text;
            var actualAlert = "Wrong Password";

            Thread.Sleep(3000);
            Assert.AreEqual(expectedAlert, actualAlert, "The message will not appear when user enter invalid password-TC3.A");

            Thread.Sleep(3000);
            var expectedURL = "https://localhost:44349/Auth/Login";
            var actualURL = ManageDriver.driver.Url;

            Thread.Sleep(3000);
            Assert.AreEqual(expectedURL, actualURL, "Actual URL not the same with expected URL-TC3.B");
            Console.WriteLine("TC3 Completed Successfully.");
        }


        [TestMethod]
        public void TestValidLogingForVendor_TC4()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);
            Login_AssistantMethods.FillLoginForm("batoolshurman2@gmail.com", "BAtool20***");
            Thread.Sleep(3000);

            var expectedURL = "https://localhost:44349/User";
            var actualURL = ManageDriver.driver.Url;

            Thread.Sleep(3000);

            Assert.AreEqual(expectedURL, actualURL, "Actual URL not the same with expected URL-TC4");
            Console.WriteLine("TC4 Completed Successfully.");
        }


        [TestMethod]
        public void TestValidLogingForAdmin_TC5()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);


            Login_AssistantMethods.FillLoginForm("AhmOmarii@outlook.com", "Ah123456*");

            Thread.Sleep(3000);

            var expectedURL = "https://localhost:44349/Admin";
            var actualURL = ManageDriver.driver.Url;

            Thread.Sleep(3000);

            Assert.AreEqual(expectedURL, actualURL, "Actual URL not the same with expected URL.");
            Console.WriteLine("TC1 Completed Successfully.");

        }
    }
}