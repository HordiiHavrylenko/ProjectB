using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class Coach : AbstractPerson
    {
        public override string Name { get; set; }
        public override int Age { get; set; }
        public decimal Salary { get; set; }

        public Coach (string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Coach: {Name}, Age: {Age}, Salary: {Salary:C}");
        }
    }
}
