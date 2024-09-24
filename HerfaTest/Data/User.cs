using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.Data
{
    public class User
    {
        public User() { }
        public User(string firstName, string lastName, string email, string phoneNumber, string password, string confirmPassword, Gender gender, string birthdate, string image = null)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.image = image;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.gender = gender;
            Birthdate = birthdate;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string image { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public Gender gender { get; set; }
        public string Birthdate { get; set; }

    }
}
