using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Paper
    {
        public string PublicationName { get; set; }
        public Person person { get; set; }
        public DateTime date { get; set; }

        public Paper(string PublName, Person person, DateTime defDate)
        {
            PublicationName = PublName;
            this.person = person;
            date = defDate;
        }

        public Paper()
        {
            PublicationName = "Hey";
            Person defaultPerson = new Person();
            defaultPerson.SetAuthor("Denis", "Karneev");
            DateTime defaultDate = new DateTime(2008, 08, 12);
        }

        public override string ToString()
        {
            return PublicationName + " " + person + " " + date;
        }
        public object DeepCopy()
        {
            object paper = new Person();
            ((Paper)paper).PublicationName = this.PublicationName;
            ((Paper)paper).person = this.person;
            ((Paper)paper).date = this.date;
            return paper;
        }
    }
}
