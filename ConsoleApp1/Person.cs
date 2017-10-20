using System;

namespace ConsoleApp1
{
    public class Person
    {
        string Name { get; set; }
        string Surname { get; set; }
        DateTime BirthDate { get; set; }

        
        int GetYear(DateTime birthDate)
        {
            return this.BirthDate.Year;
        }
        DateTime SetYear(DateTime BirthDate, int newDate)
        {
            return this.BirthDate.AddYears(newDate - BirthDate.Year);
        }
        public Person()
        {
            this.Name = "Denis";
            this.Surname = "Karneev";
            this.BirthDate = new DateTime(2003,08,17);
        }
        public Person(string name, string surname, DateTime date)
        {
            Name = name;
            Surname = surname;
            BirthDate = date;
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + BirthDate + " ";
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
        public void SetAuthor(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Person personEqu = (Person)obj;
            return Name.Equals(personEqu.Name) && Surname.Equals(personEqu.Surname); 
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode() ^ BirthDate.GetHashCode();
        }
        public object DeepCopy()
        {
            object person = new Person();
            ((Person)person).BirthDate = this.BirthDate;
            ((Person)person).Name = this.Name;
            ((Person)person).Surname = this.Surname;
            return person;
        }
    }

}
