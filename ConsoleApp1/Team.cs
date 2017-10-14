using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Team : INameAndCopy
    {
        public string name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        protected string organizationName;
        protected int registrationNumber;

        public Team(string orgName, int regNumber)
        {
            organizationName = orgName;
            registrationNumber = regNumber;
        }
        public Team()
        {
            organizationName = "NameOfOrganization";
            registrationNumber = 1;
        }

        public string organizationGetSet
        {
            get{ return organizationName; }
            set { organizationName = value;}
        }
        public int registrationGetSet
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("***ИСКЛЮЧЕНИЕ***  Значение регистрационного номера меньше или равно 0");
                }
                else registrationNumber = value;
            }
        }
        public virtual object DeepCopy()
        {
            object team = new Team(organizationName, registrationNumber);
            return team;
        }
        public override bool Equals(object obj)
        {
            if ( obj == null)
            {
                return false;
            }
            return this.ToString() == obj.ToString();
        }
        public virtual int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public virtual string ToString()
        {
            return String.Format("Organization name: {0} , Registration number: {1}", organizationName,registrationNumber); 
        }
    }
}
