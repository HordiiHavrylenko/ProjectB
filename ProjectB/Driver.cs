using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class Driver : AbstractPerson
    {
        public int Id { get; set; }
        public override string Name { get; set; }
        public override int Age { get; set; }

        public CarBrand Car { get; set; }

        public Driver(int id, string name, int age, CarBrand car) 
        {
            Id = id;
            Name = name;
            Age = age;
            Car = car;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Driver: {Name}, Age: {Age}, Car: {Car}");
        }



    }
}
