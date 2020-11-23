using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Core
{
    public class User : IComparable<User>//TODO constructor
    {
        public User() { }
        public User(int id, string firstName, string lastName, string username, decimal balance, string email)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Balance = balance;
            Email = email;
        }
        public User(string firstName, string lastName, string username, decimal balance, string email)
        {
            ID = GetNextID();
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Balance = balance;
            Email = email;
        }
        #region BackingFields
        private string _FirstName;
        private string _LastName;
        private string _Username;
        private string _Email;
        private decimal _Balance;
        #endregion

        //ID generation
        public static int NextID { get; set; } = 1;
        public static int GetNextID() => NextID++;

        #region Properties
        public int ID { get; set; }//TODO implement this as a set through constructor
        public string FirstName//TODO test null is thrown
        {
            get { return _FirstName; }
            set { _FirstName = value ?? throw new ArgumentNullException(); }
        }
        public string LastName//TODO test null is thrown
        {
            get { return _LastName; }
            set { _LastName = value ?? throw new ArgumentNullException(); }
        }
        public string Username//TODO check the regex works
        {
            get { return _Username; }
            set
            {
                Regex CharChecker = new Regex("^[0-9a-z_]*$");//from string start to string end only conclude 0-9 a-z _ all 0 or more times
                _Username = CharChecker.IsMatch(value) ? value : throw new ArgumentException("Username can only include lowercase 0-9 and _", value);
            }
        }
        public string Email//todo test
        {
            get { return _Email; }
            set
            {
                Regex CharChecker = new Regex(@"^[\w-.]+@([a-zA-Z\d]+[a-zA-Z\d.-]*\.[a-zA-Z\d.-]*[a-zA-Z\d]+)$");//[check local part]@[check only char or digit][check domain part].[check domain part][check not - or .]
                _Email = CharChecker.IsMatch(value) ? value : throw new ArgumentException("not a valid email adress", value);
            }
        }

        public decimal Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
                if (_Balance <= 50)
                {
                    //TODO when to use the delegate UserBalanceNotification
                }
            }
        }
        #endregion

        #region Methods

        public override string ToString() => $"{FirstName} {LastName} ({Email})";
        public override bool Equals(object obj)//TODO
        {
            if (!(obj is User)) return false;
            User userObj = obj as User;
            if (ID != userObj.ID) return false;
            return true;
            //TODO potentially make more? but this should be enough

        }
        public override int GetHashCode()//TODO check if any of these will ever be changed.
        {
            return ID.GetHashCode() + FirstName.GetHashCode() + LastName.GetHashCode() + Username.GetHashCode() + Email.GetHashCode();
        }

        public int CompareTo(User other)
        {
            return ID.CompareTo(other.ID);
        }

        #endregion
    }
    delegate void UserBalanceNotification(User user, decimal balance);//TODO

}
