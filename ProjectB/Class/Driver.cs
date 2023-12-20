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
        private int id { get; set; }
        private string driverName { get; set; }
        private  int driverAge { get; set; }

        private CarBrand car;

        public override string Name
        {
            get => driverName;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 3 && value.All(char.IsLetter))
                    driverName = value;
                else
                throw new ArgumentException("Ім'я водія повинно містити більше 3 букв та не бути пустим.");
                
            }
        }

        public override int Age
        {
            get => driverAge;
            set
            {
                if (!int.TryParse(value.ToString(), out int parsedValue) || parsedValue < 18)
                {
                    throw new ArgumentException("Вік водія повинен становити не менше 18 років");
                }

                driverAge = parsedValue;
                
            }
        }


        public CarBrand Car { 
            get 
            {
                return car;
            }
            set
            { 
                car = value; 
            }
        }

        public int Id
        {
            get { return id; }

            set
            {
                if (value > 0 || value < 99)
                    id = value;
                else
                    id = 0;
            }
        }

        public Driver(string name, int age, CarBrand car,int id) 
        {
            
            Name = name;
            Age = age;
            Car = car;
            Id = id;
        }

        public Driver()
        {

        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Driver: {Name}, Age: {Age}, Car: {Car}");
        }



    }
}
