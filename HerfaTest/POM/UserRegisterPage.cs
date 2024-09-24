using HerfaTest.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class UserRegisterPage
    {
        IWebDriver _driver;
        public UserRegisterPage(IWebDriver driver) {
        _driver = driver;
        }

        By firstName = By.XPath("//div/input[@id='Fname']");
        By lastName = By.XPath("//div/input[@id='Lname']");
        By male = By.XPath("//div/input[@value='M']");
        By Female = By.XPath("//div/input[@value='F']");
        By birthdate = By.XPath("//div/input[@id='Dateofbirth']");
        By phonenumber = By.XPath("//div/input[@name='Phonenumber']");
        By email = By.XPath("//div/input[@name='Email']");
        By image = By.XPath("//div/input[@name='ImageFileUser']");
        By password = By.XPath("//div/input[@id='myPass']");
        By confirmPassword = By.XPath("//div/input[@id='myPass2']");
        By SubmitButton = By.XPath("//div/button[@type='submit']");
        By loginLink = By.XPath("//p/a[@href='/Auth/Login']");


        public void EnterFirstName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(firstName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);

        }

        public void EnterLastName(string value)
        {

            IWebElement element = CommonMethods.WaitAndFindElement(lastName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickMaleButton()
        {
           IWebElement element = CommonMethods.WaitAndFindElement(male);
            CommonMethods.HighlightElement(element);
            element.Click();
        }        
        
        public void ClickFemaleButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(Female);
            CommonMethods.HighlightElement(element);
            element.Click();
        }

        public void EnterBirthdate(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(birthdate);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterPhoneNumber(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(phonenumber);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterImage(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(image);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(password);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterConfirmPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(confirmPassword);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickSubmitButton()
        {
          CommonMethods.WaitAndFindElement(SubmitButton).Click();
        }        
        
        public void ClickLoginLink()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(Female);
            CommonMethods.HighlightElement(element);
            element.Click();
        }

    }
}
