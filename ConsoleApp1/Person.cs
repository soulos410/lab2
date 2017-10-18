using System;

namespace ConsoleApp1
{
    public class Person
    {
        string name { get; set; }
        string surname { get; set; }
        DateTime birthDate { get; set; }
        int date;
        
        int GetYear(DateTime birthDate)
        {
            return this.birthDate.Year;
        }
        DateTime SetYear(DateTime birthDate, int newDate)
        {
            return this.birthDate.AddYears(newDate - birthDate.Year);
        }
        public Person()
        {
            string name = "Denis";
            string surname = "Karneev";
            DateTime date = new DateTime(2003,08,17);
        }
        public Person(string name, string surname, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            birthDate = date;
        }
        public override string ToString()
        {
            return name + " " + surname + " " + birthDate + " " + date;
        }
        public virtual string ToShortString()
        {
            return name + " " + surname;
        }
        public void SetAuthor(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Person personEqu = (Person)obj;
            return name.Equals(personEqu.name) && surname.Equals(personEqu.surname) && date.Equals(personEqu.birthDate); 
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() ^ surname.GetHashCode() ^ birthDate.GetHashCode();
        }
        public object DeepCopy()
        {
            object person = new Person();
            ((Person)person).birthDate = this.birthDate;
            ((Person)person).name = this.name;
            ((Person)person).surname = this.surname;
            return person;
        }
    }

}
