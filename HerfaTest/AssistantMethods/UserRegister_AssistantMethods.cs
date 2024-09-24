using HerfaTest.Data;
using HerfaTest.Helpers;
using HerfaTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.AssistantMethods
{
    public class UserRegister_AssistantMethods
    {
        public static void FillRegisterForm(User user)
        { 
            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);
            userRegisterPage.EnterFirstName(user.firstName);
            userRegisterPage.EnterLastName(user.lastName);
            userRegisterPage.EnterEmail(user.email);
            userRegisterPage.EnterBirthdate(user.Birthdate);
            userRegisterPage.EnterPhoneNumber(user.phoneNumber);
            if (user.gender == Gender.Male)
            {
                userRegisterPage.ClickMaleButton();
            }
            else if (user.gender == Gender.Female)
            {
                userRegisterPage.ClickFemaleButton();
            }
            userRegisterPage.EnterPassword(user.password);
            userRegisterPage.EnterConfirmPassword(user.confirmPassword);
            userRegisterPage.ClickSubmitButton();
        }
    }
}
