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
            _driver.FindElement(firstName).SendKeys(value);
        }

        public void EnterLastName(string value)
        {
            _driver.FindElement(lastName).SendKeys(value);
        }

        public void ClickMaleButton()
        {
            _driver.FindElement(male).Click();
        }        
        
        public void ClickFemaleButton()
        {
            _driver.FindElement(Female).Click();
        }

        public void EnterBirthdate(string value)
        {
            _driver.FindElement(birthdate).SendKeys(value);
        }

        public void EnterPhoneNumber(string value)
        {
            _driver.FindElement(phonenumber).SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            _driver.FindElement(email).SendKeys(value);
        }

        public void EnterImage(string value)
        {
            _driver.FindElement(image).SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            _driver.FindElement(password).SendKeys(value);
        }

        public void EnterConfirmPassword(string value)
        {
            _driver.FindElement(confirmPassword).SendKeys(value);
        }

        public void ClickSubmitButton()
        {
            _driver.FindElement(SubmitButton).Click();
        }        
        
        public void ClickLoginLink()
        {
            _driver.FindElement(loginLink).Click();
        }

    }
}
