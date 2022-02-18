using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WebAddressbookTests


{


    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string allInfo;
        private string allInfoEdit;
        private string allInfoFIO;
        private string bdates;
        private string adates;
        private string bnumber;
        private string anumber;
        private string alldates;
        public string allmails;
        public string allphonesfax;
        public string allnames;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {

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


            return (Firstname == other.Firstname) && (Lastname == other.Lastname) && (Id == other.Id);
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }


        public override string ToString()
       {
            //    return "Firstname = " + Firstname + "\nMiddlename = " + Middlename + "\nLastname= " + Lastname;
                return Firstname + " " + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;

            }

            return (Firstname + Lastname).CompareTo(other.Firstname + other.Lastname);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();

            }
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }


        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        
        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

   //     [Column(Name = "middlename")]
        public string New_group { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        public string AllInfo

        {

            get
            {

                if (allInfo != null)
                {

                    return allInfo;
                }
                else

                    return allInfo + "1";
            }

            set
            {
                allInfo = value;
            }


        }


        public string AllInfoEditForm

        {

            get
            {

                if (allInfoEdit != null)
                {

                    return allInfoEdit;
                }
                else

                    return
                        (AllNames
                        + CleanUp_2RN(AllPhonesFax)
                        + CleanUp_2RN(Allmails)
                        + CleanUp_2RN(Alldates)
                        + CleanUp_2RN(Address2)
                        + CleanUp_Phone2(Phone2)
                        + CleanUp_2RN(Notes)).Trim();

            }

            set
            {
                allInfoEdit = value;
            }


        }

        public string AllInfoFIO

        {

            get
            {

                if (allInfoFIO != null)
                {

                    return allInfoFIO;
                }
                else

                    return
                        CleanUp_FIO(Firstname) + CleanUp_FIO(Middlename) + CleanUp_allInfo(Lastname);

            }

            set
            {
                allInfoEdit = value;
            }


        }

        public string CleanUp_allInfo(string contactInfo)
        {
            if (contactInfo == null || contactInfo == "")
            {
                return "";
            }

            else
            {


                return contactInfo + "\r\n";
            }


        }




        public string GetDay(string day)
        {

            if (day == null || day == "" || day == "0")
            {
                return "";
            }

            else
            {


                return day;
            }



        }

        public string GetYear(string year)
        {

            if (year == null || year == "")
            {
                return "0";
            }

            else
            {


                return year;
            }



        }

        public string GetBMonth(string month) // to get numbers from text names
        {



            switch (month)
            {

                default:
                    return "";


                case null:
                    return "";


                case "-":
                    return "";

                case "January":
                    return "01";

                case "February":
                    return "02";

                case "March":
                    return "03";

                case "April":
                    return "04";

                case "May":
                    return "05";

                case "June":
                    return "06";

                case "July":
                    return "07";

                case "August":
                    return "08";

                case "September":
                    return "09";

                case "October":
                    return "10";

                case "November":
                    return "11";

                case "December":
                    return "12";


            }



        }

        public string GetAMonth(string month)
        {



            switch (month)
            {

                default:
                    return "";


                case null:
                    return "";


                case "-":
                    return "";

                case "january":
                    return "01";

                case "february":
                    return "02";

                case "march":
                    return "03";

                case "april":
                    return "04";

                case "may":
                    return "05";

                case "june":
                    return "06";

                case "july":
                    return "07";

                case "august":
                    return "08";

                case "september":
                    return "09";

                case "october":
                    return "10";

                case "november":
                    return "11";

                case "december":
                    return "12";


            }



        }

        public int CheckBMonth(string month)
        {
            if (month == null || month == "" || month == "-") //if Month is empty -> it shouldn't be used in age calculating
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(GetBMonth(month));
            }

        }

        public int CheckAMonth(string month)
        {
            if (month == null || month == "" || month == "-")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(GetAMonth(month));
            }

        }

        public int CheckDay(string day) //if Day is empty -> it shouldn't be used in age calculating
        {
            if (day == null || day == "" || day == "-" || day == "0")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(day);
            }

        }

        public string GetBdates(string bnum) // to calculate age and convert it to string
        {

            string checkY = GetYear(Byear);
            int bMonth = CheckBMonth(Bmonth);
            int bDay = CheckDay(Bday);


            string ageStr;


            int bYear = Convert.ToInt32(GetYear(Byear));

            // if Year is empty -> age isn't displayed
            // but Day and Month can be empty

            if (checkY == null || checkY == "")
            {
                ageStr = "";

            }

            else
            {


                DateTime nDate = DateTime.Now;

                int nYear = nDate.Year;
                int nMonth = nDate.Month;
                int nDay = nDate.Day;


                int age = nYear - bYear;
                // to get real age

                // age above 149 isn't displayed on the page for some reasons





                if ((nMonth < bMonth && bMonth != 0) || (nMonth == bMonth && nDay < bDay))
                {
                    age--;
                    if (age >= 150)

                    {

                        ageStr = "";
                    }
                    else
                    {
                        ageStr = " (" + Convert.ToString(age) + ")";
                    }
                }
                else
                {
                    if (age >= 150)

                    {

                        ageStr = "";
                    }
                    else
                    {
                        ageStr = " (" + Convert.ToString(age) + ")";
                    }
                }






            }

            return ageStr;

        }

        public string BNumber
        {

            get
            {

                if (bnumber != null)
                {

                    return bnumber;
                }
                else


                    return GetBdates(bnumber);
            }

            set
            {
                bnumber = value;
            }

        }

        public string GetAdates(string anum)
        {

            string checkY = GetYear(Ayear);
            int aMonth = CheckAMonth(Amonth);
            int aDay = CheckDay(Aday);


            string ageStr;


            int aYear = Convert.ToInt32(GetYear(Ayear));


            if (checkY == null || checkY == "")
            {
                ageStr = "";

            }

            else
            {


                DateTime nDate = DateTime.Now;

                int nYear = nDate.Year;
                int nMonth = nDate.Month;
                int nDay = nDate.Day;


                int age = nYear - aYear;

                if (age >= 150)
                {
                    ageStr = "";

                }
                else
                {
                    // Anniversary doesn't depend on Day and Month 
                    ageStr = " (" + Convert.ToString(age) + ")";
                }

            }

            return ageStr;

        }

        public string ANumber
        {

            get
            {

                if (anumber != null)
                {

                    return anumber;
                }
                else


                    return GetAdates(anumber);
            }

            set
            {
                anumber = value;
            }

        }

        public string CheckBDates(string bday, string bmonth, string byear)
        {
            if (bday == "0" && bmonth == "-" && byear == "")
            {
                return "";
            }

            else
            {
                return "Birthday ";

            }

        }

        public string CheckADates(string aday, string amonth, string ayear)
        {
            if (aday == "0" && amonth == "-" && ayear == "")
            {
                return "";
            }

            else
            {
                return "Anniversary ";

            }

        }

        public string Alldates //because we need two \r\n before Dates block but don't know how many lines exist

        {

            get
            {

                if (alldates != null)
                {

                    return alldates;
                }
                else

                    if (Bdates == "" || Bdates == null)
                { return Adates; }
                else
                {
                    if (Adates == "" || Adates == null)
                    { return Bdates; }
                    else
                    { return Bdates + "\r\n" + Adates; }
                }


            }
            set
            {
                alldates = value;
            }

        }



        public string AllNames

        {
            get
            {
                if (allnames != null)
                {

                    return allnames;
                }
                else

                {
                    if (AllInfoFIO != "" && AllInfoFIO != null)
                    {
                        allnames = AllInfoFIO.Trim();
                    }
                    if (Nickname != "" && Nickname != null)
                    {
                        if (allnames != "" && allnames != null)
                        {
                            allnames = allnames.Trim() + "\r\n" + Nickname.Trim();


                        }
                        else
                        { allnames = Nickname.Trim(); }

                    }
                    if (Title != "" && Title != null)

                        if (allnames != "" && allnames != null)
                        {
                            allnames = allnames.Trim() + "\r\n" + Title.Trim();


                        }
                        else
                        { allnames = Title.Trim(); }

                    if (Company != "" && Company != null)

                        if (allnames != "" && allnames != null)
                        {
                            allnames = allnames.Trim() + "\r\n" + Company.Trim();


                        }
                        else
                        { allnames = Company.Trim(); }

                    if (Address != "" && Address != null)
                        if (allnames != "" && allnames != null)
                        {
                            allnames = allnames.Trim() + "\r\n" + Address.Trim();


                        }
                        else
                        { allnames = Address.Trim(); }


                }
                return allnames;


            }

            set
            {
                allnames = value;
            }


        }

        public string Allmails

        {
            get
            {
                if (allmails != null)
                {

                    return allmails;
                }
                else

                {
                    if (Email != "" && Email != null)
                    {
                        allmails = Email.Trim();
                    }
                    if (Email2 != "" && Email2 != null)
                    {
                        if (allmails != "" && allmails != null)
                        {
                            allmails = allmails.Trim() + "\r\n" + Email2.Trim();


                        }
                        else
                        { allmails = Email2.Trim(); }

                    }
                    if (Email3 != "" && Email3 != null)

                        if (allmails != "" && allmails != null)
                        {
                            allmails = allmails.Trim() + "\r\n" + Email3.Trim();


                        }
                        else
                        { allmails = Email3.Trim(); }
                    if (Homepage != "" && Homepage != null)
                        if (allmails != "" && allmails != null)
                        {
                            allmails = allmails.Trim() + "\r\n" + "Homepage:\r\n" + Homepage.Trim();


                        }
                        else
                        { allmails = "Homepage:\r\n" + Homepage.Trim(); }


                }
                return allmails;


            }

            set
            {
                allmails = value;
            }


        }

        public string AllPhonesFax

        {
            get
            {
                if (allphonesfax != null)
                {

                    return allphonesfax;
                }
                else

                {
                    if (Home != "" && Home != null)
                    {
                        allphonesfax = "H: " + Home.Trim();
                    }
                    if (Mobile != "" && Mobile != null)
                    {
                        if (allphonesfax != "" && allphonesfax != null)
                        {
                            allphonesfax = allphonesfax.Trim() + "\r\n" + "M: " + Mobile.Trim();


                        }
                        else
                        { allphonesfax = Mobile.Trim(); }

                    }
                    if (Work != "" && Work != null)

                        if (allphonesfax != "" && allphonesfax != null)
                        {
                            allphonesfax = allphonesfax.Trim() + "\r\n" + "W: " + Work.Trim();


                        }
                        else
                        { allphonesfax = Work.Trim(); }

                    if (Fax != "" && Fax != null)
                        if (allphonesfax != "" && allphonesfax != null)
                        {
                            allphonesfax = allphonesfax.Trim() + "\r\n" + "F: " + Fax.Trim();


                        }
                        else
                        { allphonesfax = "F: " + Fax.Trim(); }


                }
                return allphonesfax;


            }



            set
            {
                allphonesfax = value;
            }


        }


        public string Bdates

        {

            get
            {

                if (bdates != null)
                {

                    return bdates;
                }
                else



                    return
                        CheckBDates(Bday, Bmonth, Byear) + CleanUp_Bday(Bday) + CleanUp_Bmonth(Bmonth) + CleanUp_Byear(Byear) + BNumber;

            }

            set
            {
                bdates = value;
            }


        }

        public string Adates

        {

            get
            {

                if (adates != null)
                {

                    return adates;
                }
                else

                    return

                        CheckADates(Aday, Amonth, Ayear) + CleanUp_Aday(Aday) + CleanUp_Amonth(Amonth) + CleanUp_Byear(Ayear) + ANumber;

            }

            set
            {
                adates = value;
            }


        }

        public string CleanUp_NR(string contactInfo) // for lines without empty line before
        {
            if (contactInfo == null || contactInfo == "")
            {
                return "";
            }

            else
            {


                return "\r\n" + contactInfo;
            }
        }

        public string CleanUp_2RN(string contactInfo) // for lines with empty line before
        {
            if (contactInfo == null || contactInfo == "")
            {
                return "";
            }

            else
            {


                return "\r\n\r\n" + contactInfo;
            }
        }


        public string CleanUp_FIO(string fio)
        {
            if (fio == null || fio == "")
            {
                return "";
            }

            else
            {


                return fio + " ";
            }

        }

        public string CleanUp_Home(string pHome)
        {
            if (pHome == null || pHome == "")
            {
                return "";
            }

            else
            {


                return "H: " + pHome + "\r\n";
            }

        }
        public string CleanUp_Mobile(string pMobile)
        {
            if (pMobile == null || pMobile == "")
            {
                return "";
            }

            else
            {


                return "M: " + pMobile + "\r\n";
            }

        }
        public string CleanUp_Work(string pWork)
        {
            if (pWork == null || pWork == "")
            {
                return "";
            }

            else
            {


                return "W: " + pWork + "\r\n";
            }

        }

        public string CleanUp_Fax(string pFax)
        {
            if (pFax == null || pFax == "")
            {
                return "";
            }

            else
            {


                return "F: " + pFax;
            }

        }




        public string CleanUp_Bday(string bday)
        {
            if (bday == null || bday == "" || bday == "0")
            {
                return "";
            }

            else
            {

                return bday + "." + " ";
            }

        }

        public string CleanUp_Bmonth(string bmonth)
        {
            if (bmonth == null || bmonth == "" || bmonth == "-")
            {
                return "";
            }

            else
            {


                return bmonth + " ";
            }

        }

        public string CleanUp_Amonth(string amonth)
        {
            if (amonth == null || amonth == "" || amonth == "-")
            {
                return "";
            }

            else
            {
                TextInfo amont = CultureInfo.CurrentCulture.TextInfo;
                return amont.ToTitleCase(amonth) + " ";
            }

        }

        public string CleanUp_Byear(string byear)
        {
            if (byear == null || byear == "")
            {
                return "";
            }

            else
            {


                return byear;
            }

        }

        public string CleanUp_Aday(string aday)
        {
            if (aday == null || aday == "" || aday == "0")
            {
                return "";
            }

            else
            {


                return aday + "." + " ";
            }

        }

        public string CleanUp_Phone2(string phone2)
        {
            if (phone2 == null || phone2 == "")
            {
                return "";
            }

            else
            {


                return "\r\n" + "\r\n" + "P: " + phone2;
            }

        }





    }

}
