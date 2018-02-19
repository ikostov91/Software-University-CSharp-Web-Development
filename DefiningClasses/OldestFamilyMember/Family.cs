using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    private List<Person> members;

    public List<Person> Members
    {
        get { return this.members; }
    }

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember(List<Person> people)
    {
        return members.OrderByDescending(x => x.Age).First();
    }

    //public override string ToString()
    //{
    //    return ;
    //}
}

