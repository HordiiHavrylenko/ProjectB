using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class Team : IPrintable
    {

        public string TeamName { get; set; }
        public List<Driver> Drivers { get; set; }
        public Coach Coach { get; set; }

        public List<IPerson> Members { get; set; }

        public Team()
        {
            Members = new List<IPerson>();
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
