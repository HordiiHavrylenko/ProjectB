using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class Coach : AbstractPerson
    {
        private string coachName { get; set; }
        private int coachAge { get; set; }
        private decimal coachSalary { get; set; }


        public override string Name
        {
            get => coachName;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 3 && value.All(char.IsLetter))
                    coachName = value;
                else
                throw new ArgumentException("Ім'я тренера повинно містити більше 3 букв та не бути пустим.");
                
            }
        }

        public override int Age
        {
            get => coachAge;
            set
            {
                if (!int.TryParse(value.ToString(), out int parsedValue) || parsedValue < 18)
                {
                    throw new ArgumentException("Вік водія повинен становити не менше 18 років");
                }

                coachAge = parsedValue;

            }
        }

        public decimal Salary
        {
            get => coachSalary;
            set
            {
                if (!decimal.TryParse(value.ToString(), out decimal parsedValue) || parsedValue <1000 )
                    throw new ArgumentException("Зарплатня тренера не може бути меншою 1000");
                coachSalary = value;
            }

            
        }

        public Coach (string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public Coach()
        {

        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Coach: {Name}, Age: {Age}, Salary: {Salary:C}");
        }
    }
}
