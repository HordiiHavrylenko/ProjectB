using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public abstract class AbstractPerson : IPerson
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract void DisplayInfo();

        public void JoinTeam(Team team)
        {
            team.Members.Add(this);
            Console.WriteLine($"{Name} has joined the team {team.TeamName}");
        }

        public void LeaveTeam(Team team)
        {
            team.Members.Remove(this);
            Console.WriteLine($"{Name} has left the team {team.TeamName}");
        }
    }
}
