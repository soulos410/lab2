using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    public class ResearchTeam : Team
    {
        string researchName;
        TimeFrame researchTime;
        ArrayList listOfPersons;
        ArrayList listOfPublications;

        public ArrayList publicationsList
        {
            get
            {
                return listOfPublications;
            }
            set
            {
                new Paper();
            }
        }

        public ArrayList personsList
        {
            get
            {
                return listOfPersons;
            }
            set
            {
                new Person();
            }
        }
        public Paper lastPaper
        {
            get
            {
                if(listOfPublications.Count > 0)
                {
                    DateTime max = DateTime.MinValue;
                    foreach (Paper paper in listOfPublications)
                    {
                        if(paper.date > max)
                        {
                            max = paper.date;
                        }
                        var answer = ((Paper[])listOfPublications.ToArray()).ToList();
                        return answer.Find(i => i.date == max);
                    }
                }
                return null;
            }
        }
        public void AddPapers(params Paper[] papers)
        {
            this.listOfPublications.AddRange(papers);
        }
        public void AddPersons(params Person[] persons)
        {
            this.listOfPersons.AddRange(persons);
        }
        public string ToString()
        {
            string papers = "", teamMembers = ""; 
            for(int i = 0; i < listOfPersons.Count; i++)
            {
                papers += Convert.ToString(listOfPersons[i] + "\n");
            }
            for(int i = 0; i < listOfPublications.Count; i++)
            {
                teamMembers += Convert.ToString(listOfPublications[i] + "\n");
            }
            return researchName + " " + organizationName + " " + registrationNumber + " " + researchTime + " " + papers + " " + teamMembers;
        }
        public string ToShortString()
        {
            return researchName + " " + organizationName + " " + registrationNumber + " " + researchTime;
        }

        public override object DeepCopy()
        {
              object rt = new ResearchTeam (this.researchName,this.organizationName, base.name, base.registrationNumber, this.researchTime);
              foreach(Paper p in this.listOfPublications)
              {
                  ((ResearchTeam) rt).AddPapers((Paper)(p.DeepCopy()));
              }
              foreach (Person p in this.ListOfMembers)
              {
                 ((ResearchTeam)rt).AddMembers((Person)(p.DeepCopy()));
              }
              return rt;
        }

    public ResearchTeam( string researchName,string organization ,int regNumber, TimeFrame researchTime) : base(organization,regNumber)
        {
            this.researchName = researchName;
            this.registrationNumber = regNumber;
            this.researchTime = researchTime;
            listOfPublications = new ArrayList();
            listOfPersons = new ArrayList();
        }
        public ResearchTeam()
        {
            researchName = "Default research name";
            researchTime = TimeFrame.Year;
            listOfPublications = new ArrayList() { new Paper() };
            listOfPersons = new ArrayList() { new Person() };
        }

        public void SetResearchName(string researchName)
        {
            this.researchName = researchName;
        }
        public string GetResearchName()
        {
            return researchName;
        }

        public void SetRegistrationNumber(int registrationNumber)
        {
            this.registrationNumber = registrationNumber;
        }
        public int GetRegistrationNumber()
        {
            return registrationNumber;
        }

        public void SetTimeFrame(TimeFrame researchTime)
        {
            this.researchTime = researchTime;
        }

        public TimeFrame GetTimeFrame()
        {
            return researchTime;
        }
    }
}
