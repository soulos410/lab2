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
            ResearchTeam resTeam2 = resTeam.DeepCopy() as ResearchTeam;
            resTeam.ResearchName = "Math";
            resTeam2.AddPersons(new Person("Ser", "Gay", new DateTime(2000, 6, 1)));
            Console.WriteLine(resTeam.ToString());
            Console.WriteLine();
            Console.WriteLine(resTeam2.ToString());
            Console.WriteLine();


            // 6 task 
            Console.WriteLine("\n   Persons without publications:");
            resTeam.AddPersons(new Person("Sereja", "Oleja",new DateTime(2015,03,10)));

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
