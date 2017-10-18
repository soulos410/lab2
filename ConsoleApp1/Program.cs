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

            Console.WriteLine("Hash code of 1st: {0} Hash of 2nd : {1} \n \n", team1.GetHashCode(),team2.GetHashCode());

            Console.WriteLine("TEAMS THE SAME?! " +  team1.Equals(team2) + "\n \n");
            Console.WriteLine("References the same? : " + ReferenceEquals(team1,team2) + "\n\n");
            // 2nd task
            try
            {
                team1.RegistrationGetSet = -100;
            }
            catch ( ArgumentException arg)
            {
                Console.WriteLine(arg.Message + "\n \n");
            }
            // 3rd task
            ResearchTeam resTeam = new ResearchTeam("ResearchName","OrganizationName",3,TimeFrame.TwoYears);
            resTeam.AddPapers(new Paper[] { new Paper() });
            resTeam.AddPersons(new Person[] { new Person() });

            Console.WriteLine(resTeam.ToString());
        }
    }
}
