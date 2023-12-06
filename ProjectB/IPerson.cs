using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void JoinTeam(Team team);
        void LeaveTeam(Team team);
    }
}
