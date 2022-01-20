using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string middlename = "";
        private string nickname = "";
        private string title = ""; 
        private string company = "";
        private string fax = "";
    
        private string homepage = "www.default_homepage_for_all_contacts.ru";
        private string bday = "";

       // private string bday_path = "";
        private string bmonth = "";
       // private string bmonth_path = "";

        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string new_group = "";


        private string ayear = "";

        private string address2 = "";
        private string phone2 = "";
        private string notes = "";


        private string allPhones;
        private string allEmails; 

        public ContactData (string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {

            if (Object.ReferenceEquals(other, null))
            {
                return false;

            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;

            }

            
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname+Lastname).GetHashCode();
        }


        public override string ToString()
        {
            return (Firstname + ' ' + Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;

            }

            return (Firstname+Lastname).CompareTo(other.Firstname+other.Lastname);
        }


        public string Firstname { get; set; }

        public string Middlename
        {

            get
            {
                return middlename;
            }

            set
            {
                middlename = value;
            }

        }
        public string Lastname         { get; set; }

        public string Address        { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }
        public string Work { get; set; }

        public string AllPhones

        {

            get
            {

                if (allPhones != null)
                {

                    return allPhones;
                }
                else

                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
            }

            set
            {
                allPhones = value; 
            }

        }

        
        
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ ()-]", "") + "\r\n"; 

            //   return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")","")+ "\r\n";
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }


        public string AllEmails

        {

            get
            {

                if (allEmails != null)
                {

                    return allEmails;
                }
                else

                    return (CleanUp_email(Email) + CleanUp_email(Email2) + CleanUp_email(Email3)).Trim();
            }

            set
            {
                allEmails = value;
            }

        }



        public string CleanUp_email(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }

            return email + "\r\n";
        }

        public string Nickname
        {

            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }

        }
        public string Title
        {

            get
            {
                return title;
            }

            set
            {
                title = value;
            }

        }
        public string Company
        {

            get
            {
                return company;
            }

            set
            {
                company = value;
            }

        }
   
       
        public string Fax
        {

            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }

        }
        
     
        public string Homepage
        {

            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }

        }

     
        public string Bday
        {

            get
            {
                return bday;
            }

            set
            {
                bday = value;
            }

        }
     
       

        public string Bmonth
        {

            get
            {
                return bmonth;
            }

            set
            {
                bmonth = value;
            }

        }

    

        public string Byear
        {

            get
            {
                return byear;
            }

            set
            {
                byear = value;
            }

        }
        public string Aday
        {

            get
            {
                return aday;
            }

            set
            {
                aday = value;
            }

        }

        public string Amonth
        {

            get
            {
                return amonth;
            }

            set
            {
                amonth = value;
            }

        }

        public string New_group
        {

            get
            {
                return new_group;
            }

            set
            {
                new_group = value;
            }

        }

        public string Ayear
        {

            get
            {
                return ayear;
            }

            set
            {
                ayear = value;
            }

        }



        public string Address2
        {

            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }

        }

        public string Phone2
        {

            get
            {
                return phone2;
            }

            set
            {
                phone2 = value;
            }

        }

        public string Notes
        {

            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }

        }

    }
}
