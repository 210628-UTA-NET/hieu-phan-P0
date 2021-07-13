using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SSDModel
{
    public class Customers{
        private int _id;
        private string _fname;
        private string _lname;
        private string _address;
        private string _city;
        private string _state;
        private string _email;
        private string _phone;


        public Customers()
        {
        }

        public int Id { get => _id; set => _id = value; }

        // RegEx can be added here       
        public string Fname { 
            get
            {
                return _fname;
            }
            set 
            {
                if (!Regex.IsMatch(value,@"^[A-Za-z .']+$"))
                {
                    throw new Exception("This Field can only contain letters");
                }
                _fname = value;
            }
        }
        
        public string Lname { 
            get
            {
                return _lname;
            }
            set 
            {
                if (!Regex.IsMatch(value,@"^[A-Za-z .']+$"))
                {
                    throw new Exception("Input Was Not Valid");
                }
                _lname = value;
            } 
        }

        public string Address { get => _address; set => _address = value; }
        public string Email { get => _email; set => _email = value; }

        public string Phone { 
            get
            {
                return _phone;
            } 
            set 
            {
                if(!Regex.IsMatch(value,@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
                {
                    throw new Exception("Input Was Not Valid");
                }
                _phone = value;
            }
        }

        public string City { get => _city; set => _city = value; }
        public string State { 
            get => _state; 
            set 
            {
                if(!Regex.IsMatch(value,@"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$"))
                {
                    throw new Exception("Input Was Not Valid");
                }
                _state = value;
            }
        }

        public override string ToString()
        {
            return $"ID: {Id} ||| First Name: {Fname} ||| Last Name: {Lname} ||| Address: {Address} ||| City: {City} ||| State: {State} ||| Email: {Email} ||| Phone: {Phone}";
        }

        
        
    }
}
