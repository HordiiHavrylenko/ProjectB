using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class Team : IPrintable
    {

        private string teamName;
        public List<Driver> Drivers { get; set; }
        public Coach Coach { get; set; }

        public List<IPerson> Members { get; set; }

        public string TeamName 
        {
            get { return teamName; }
            set
            {
                if(!string.IsNullOrEmpty(value) && value.Length >= 3 && value.All(char.IsLetter))
                {
                    teamName = value;
                }

                else 
                { 
                throw new ArgumentException("Назма команди повинна містити не менше 3 букв");
                }
            }
            
        }
        

        public Team(string teamName)
        {
            Members = new List<IPerson>();
            TeamName = teamName;

        }

        public Team()
        {

        }
        public void JoinTeam(IPerson person)
        {
            Members.Add(person);
            Console.WriteLine($"{person.Name} has joined the team {TeamName}");
        }

        public void LeaveTeam(IPerson person)
        {
            Members.Remove(person);
            Console.WriteLine($"{person.Name} has left the team {TeamName}");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Team: {TeamName}");
            foreach (var member in Members)
            {
                Console.WriteLine($"{member.GetType().Name}: {member.Name}, Age: {member.Age}");
            }



        }
    }
}
