using HerfaTest.Helpers;
using HerfaTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.AssistantMethods
{
    public class Login_AssistantMethods
    {
        public static void FillLoginForm(string email, string password)
        {
            LoginPage loginPage = new LoginPage(ManageDriver.driver);
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            Thread.Sleep(2000);
            loginPage.ClickLoginButton();

        }
    }
}
