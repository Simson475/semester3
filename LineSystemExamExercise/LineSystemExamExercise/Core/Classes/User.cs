using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Core
{
    /// <summary>
    /// synbolises a user of the system.
    /// </summary>
    public class User : IComparable<User>
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
            NextID = Math.Max(NextID, id);

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
        #endregion

        //ID generation
        public static int NextID { get; set; } = 1;
        public static int GetNextID() => NextID++;

        #region Properties
        public int ID { get; }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value ?? throw new ArgumentNullException(); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value ?? throw new ArgumentNullException(); }
        }
        public string FullName => $"{FirstName} {LastName}";

        public string Username
        {
            get { return _Username; }
            set
            {
                if (value == null) throw new ArgumentNullException("username cannot be null");
                Regex CharChecker = new Regex("^[0-9a-z_]*$");//from string start to string end only conclude 0-9 a-z _ all 0 or more times
                _Username = CharChecker.IsMatch(value) ? value : throw new ArgumentException("Username can only include lowercase 0-9 and _", value);
            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                Regex CharChecker = new Regex(@"^[\w-.]+@([a-zA-Z\d]+[a-zA-Z\d.-]*\.[a-zA-Z\d.-]*[a-zA-Z\d]+)$");//[check local part]@[check only char or digit][check domain part].[check domain part][check not - or .]
                _Email = CharChecker.IsMatch(value) ? value : throw new ArgumentException("not a valid email adress", value);
            }
        }

        public decimal Balance { get; set; }
        #endregion

        #region Methods

        public override string ToString() => $"{FirstName} {LastName} ({Email})";

        public override bool Equals(object obj)
        {
            if (!(obj is User user)) return false;
            if (ID != user.ID) return false;
            return this.GetHashCode() == user.GetHashCode();

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, FirstName, LastName, Username, Email) * 97;
        }


        public int CompareTo(User other)
        {
            //Id should be unique so we can just compare that
            return ID.CompareTo(other.ID);
        }

        #endregion
    }

}
