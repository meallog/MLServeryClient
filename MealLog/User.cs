using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealLog
{
    class User
    {
        private string _firstName;
        private string _lastName;
        private int _userId;
        private string _emailAddress;
        
        public User(string firstName, string lastName, int userId, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _userId = userId;
            _emailAddress = email;
        }

        public string getFirstName()
        {
            return _firstName;
        }

        public string getLastName()
        {
            return _lastName;
        }

        public int getID()
        {
            return _userId;
        }

        public string getEmail()
        {
            return _emailAddress;
        }

        public override string ToString()
        {
            return ("Name: " + _firstName + " " + _lastName + " ID: " + _userId.ToString() + " Email: " + _emailAddress);
        }

    }
}
