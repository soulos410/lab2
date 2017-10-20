using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp1
{
    public enum TimeFrame { Year, TwoYears, Long };

    public interface INameAndCopy
    {
        string name { get; set; }
        object DeepCopy();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1st task
            var team1 = new Team();
            var team2 = new Team();

            Console.WriteLine("Hash code of 1st: {0} Hash of 2nd : {1} \n \n", team1.GetHashCode(), team2.GetHashCode());

            Console.WriteLine("TEAMS THE SAME?! " + team1.Equals(team2) + "\n \n");
            Console.WriteLine("References the same? : " + ReferenceEquals(team1, team2) + "\n\n");
            // 2nd task
            try
            {
                team1.RegistrationGetSet = -100;
            }
            catch (ArgumentException arg)
            {
                Console.WriteLine(arg.Message + "\n \n");
            }
            // 3rd task
            ResearchTeam resTeam = new ResearchTeam("ResearchName", "OrganizationName", 3, TimeFrame.TwoYears);
            resTeam.AddPapers(new Paper());
            resTeam.AddPersons(new Person());
            Console.WriteLine(resTeam.ToString());

            // 4th task
            Console.WriteLine(resTeam.GetTeam);
            // 5th task



            // 6 task 
            Console.WriteLine("TASK 6");
            resTeam.AddPapers(new Paper("NameOfPub", new Person("Sergey", "Denis", new DateTime(2013, 10, 10)), new DateTime(2000, 01, 10)));
            resTeam.AddPersons(new Person("Sereja", "Oleja",new DateTime(2015,03,10)));

            foreach(Person p in resTeam.personsList)
            {
                Console.WriteLine("This is the person : \n" + p + " \n");
            }
            foreach(Paper pap in resTeam.publicationsList)
            {
                Console.WriteLine("This is the Publication : \n" + pap + "\n");
            }
            foreach (Person person in resTeam.PersonsWithoutPublications())
            {
                Console.WriteLine("\n" + person);
            }


            // 7 task 
            resTeam.AddPapers(new Paper("NewPub",new Person(), new DateTime(2016,01,01)));
            foreach (Paper person in resTeam.GetPubliscationsByYear(2))
            {
                Console.WriteLine("\n" + person);
            }

        }
    }
}
