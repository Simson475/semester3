using System;

namespace OOP01Classes
{
    public class Person
    {
        // Constructors
        public Person(string fornavn, string efternavn)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            AssignID();
        }
        public Person(string fornavn, string efternavn, Person mor, Person far)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Mor = mor;
            Far = far;
            AssignID();
        }

        //Variables
        private string _Fornavn;
        private string _Efternavn;
        private int _PersonID;
        public int Alder;
        private Person _Mor;
        private Person _Far;
        public static int CounterID = 1;


        //Properties
        public int PersonID { get => _PersonID; private protected set => _PersonID = value; }
        public Person Mor
        {
            get
            {
                return _Mor;
            }
            set
            {
                if (value is Person)
                {
                    _Mor = value;
                }
                else
                {
                    throw new Exception("Mother has to be of type person");
                }
            }
        }
        public Person Far
        {
            get
            {
                return _Far;
            }
            set
            {
                if (value is Person)
                {
                    _Far = value;
                }
                else
                {
                    throw new Exception("Mother has to be of type person");
                }
            }
        }
        public string Fornavn
        {
            get
            {
                return _Fornavn;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name cannot be empty");
                }
                else
                {
                    _Fornavn = value;
                }
            }
        }
        public string Efternavn
        {
            get
            {
                return _Efternavn;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name cannot be empty");
                }
                else
                {
                    _Efternavn = value;
                }
            }
        }


        //functions
        private void AssignID() =>
            PersonID = CounterID++;
    }
}
