using System.Collections.Generic;

namespace OOP002Inheritance
{
    public abstract class PersonFilter
    {
        public abstract bool FilterPredicate(Person person);
        public virtual List<Person> Filter(List<Person> plist)
        {
            return plist.FindAll(e => FilterPredicate(e));
        }
    }
}
