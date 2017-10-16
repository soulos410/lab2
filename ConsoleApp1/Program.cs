using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp1
{
    public interface INameAndCopy
    {
        string name { get; set; }
        object DeepCopy();
    }

    class Program
    {
        static void Main(string[] args)
        {            
            ResearchTeam team1 = new ResearchTeam();        //p.1
            Console.WriteLine(Convert.ToString(team1.Indexator(TimeFrame.Year) + " " + team1.Indexator(TimeFrame.TwoYears) + " " + team1.Indexator(TimeFrame.Long))); //p.2
            team1.SetResearchName("Research1");
            team1.SetOrgName("group681063");
            team1.SetRegistrationNumber(5);
            team1.SetTimeFrame(TimeFrame.Year);           
            Console.WriteLine(Convert.ToString(team1.ToString()));      //p.3
            team1.AddPapers(new Paper("NameOfPublication", new Person("Sergey", "Lisyunin", new DateTime(2030, 11, 10)), new DateTime(2005, 10, 12)));          //p.4
            Console.WriteLine(team1 + "\n");
            Paper pub = new Paper("Ootp",new Person("Oleg","Shakun",new DateTime(2000,10,10)),new DateTime(2001,05,05)); 
            Paper pub2 = new Paper("Isp", new Person("Denis", "Shakun", new DateTime(1989,09, 10)), new DateTime(2000, 05, 05));
            team1.AddPapers(pub,pub2);            
            Console.WriteLine("last paper is :  " + team1.LastPaper.ToString());         //p.5
            Console.WriteLine("Введите размерность двумерного массива: (кол-во строк/кол-во столбцов. Используя символы // и __ как разделители)");
            string countOfElements = Console.ReadLine();            

            Console.WriteLine("\n You entered : {0}", countOfElements);
            
            string[] separators = {"//","__"};

            string[] words = countOfElements.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("\n String after separation: {0} {1}",words[0],words[1]);
            int rows, colums;
            rows = int.Parse(words[0]);
            colums = int.Parse(words[1]);

            Paper[] oneRowArray = new Paper[rows * colums];
            Paper[,] twoRowArray = new Paper[rows, colums];
            Paper[][] stupArray = new Paper[rows][];

            TimeSpan firstArray, secondArray, thirdArray;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < oneRowArray.Length; i++)
            {
                oneRowArray[i] = new Paper();
            }
            stopwatch.Stop();
            
            firstArray = stopwatch.Elapsed;

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < colums; j++)
                {
                    twoRowArray[i, j] = new Paper();
                }
            }
            stopwatch.Stop();
            secondArray = stopwatch.Elapsed;

            stopwatch.Reset();
            stopwatch.Start();
            if (rows > 2)
            {
                int i = 0;
                stupArray[0] = new Paper[rows * colums - 3];
                stupArray[1] = new Paper[1];
                stupArray[2] = new Paper[5];
                for(; i < (rows*colums -3); i++)
                {
                    stupArray[0][i] = new Paper();
                }
                for(; i < 1; i++)
                {
                    stupArray[1][i] = new Paper();
                }
                for(; i < 5; i++)
                {
                    stupArray[2][i] = new Paper();
                }
            }
            else
            {
                int i = 0;
                stupArray[0] = new Paper[rows * colums - 1];
                stupArray[1] = new Paper[3];
                for(; i < (rows*colums-1); i++)
                {
                    stupArray[0][i] = new Paper();
                }
                for(; i < 3; i++)
                {
                    stupArray[1][i] = new Paper();
                }                
            }
            stopwatch.Stop();
            thirdArray = stopwatch.Elapsed;
            Console.WriteLine("Time of 1st array: {0}" + " Rows : {1} Colums: {2}", firstArray,1,rows*colums);          //p.6
            Console.WriteLine("Time of 2nd array: {0}" + " Rows : {1} Colums: {2}", secondArray,rows,colums);
            Console.WriteLine("Time of 3rd array: {0}" + " Rows : {1}", thirdArray,rows);
                if(rows > 2)
            {
                int i = 0;
                for (; i < 3; i++)
                {
                    Console.WriteLine("{0} row colums: {1}", i+1, stupArray[i].Length);
                }
            }
                else
            {
                int i = 0;
                for (; i <= 2; i++)
                {                    
                    Console.WriteLine("{0} row colums: {1}", i+1, stupArray[i].Length);
                }
            }
            
            

        }
    }
    public enum TimeFrame {Year,TwoYears,Long};

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
    }
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
            defaultPerson.SetAuthor("Denis","Karneev");
            DateTime defaultDate = new DateTime(2008,08,12);
        }

        public override string ToString()
        {
            return PublicationName + " " + person + " " + date;
        }
    }

}
