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
        public Person Author { get; set; }
        public DateTime Date { get; set; }

        public Paper(string PublName, Person pers, DateTime defDate)
        {
            PublicationName = PublName;
            Author = pers;
            Date = defDate;
        }

        public Paper()
        {
            PublicationName = "PubName";
            Author = new Person("Fml", "BlessRng",new DateTime(2010,01,01));
            Date = new DateTime(2014, 08, 12);
        }

        public override string ToString()
        {
            return PublicationName + " " + Author + " " + Date;
        }
        public object DeepCopy()
        {
            object paper = new Paper();
            ((Paper)paper).PublicationName = this.PublicationName;
            ((Paper)paper).Author = this.Author;
            ((Paper)paper).Date = this.Date;
            return paper;
        }
    }
}
