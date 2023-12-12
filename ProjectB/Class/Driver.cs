using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace ProjectB
{
    public class Driver : AbstractPerson
    {
        private int Id { get; set; }
        private  string driverName { get; set; }
        private  int driverAge { get; set; }

        public override string Name
        {
            get => driverName;
            set
            {
                if (value.Length < 2 || value.Length == 0)
                    throw new ArgumentException("Ім'я водія повинно містити більше 3 букв та не бути пустим.");
                driverName = value;
            }
        }

        public override int Age
        {
            get => driverAge;
            set
            {
                if(!int.TryParse(value.ToString(), out int parsedValue) || parsedValue < 18)
                {
                    throw new ArgumentException("Вік водія повинен становити не менше 18 років");
                }

                driverAge = parsedValue;
                ///TestGit
            }
        }


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
