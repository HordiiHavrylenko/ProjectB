// See https://aka.ms/new-console-template for more information
using ProjectB;
using System.Numerics;

class Program
{
    static List<Team> teams = new List<Team>();
    static List<Driver> availableDrivers = new List<Driver>();
    static List<Coach> availableCoaches = new List<Coach>();
    static List<Race> races = new List<Race>();
    

    static void Main(string[] args)
    {
        bool exit = false;

        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Створити команду");
            Console.WriteLine("2. Створити водія");
            Console.WriteLine("3. Створити тренера");
            Console.WriteLine("4. Переглянути список доступних водіїв");
            Console.WriteLine("5. Переглянути команди");
            Console.WriteLine("6. Додати члена команди");
            Console.WriteLine("7. Видалити члена команди");
            Console.WriteLine("8. Створити заїзд");
            Console.WriteLine("0. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MyCreateTeamDelegate();
                    break;
                case "2":
                    MyCreateDriverDelegate();
                    break;
                case "3":
                    MyCreateCoachDelegate();
                    break;
                case "4":
                    DisplayAvailableDrivers();
                    break;
                case "5":
                    DisplayTeams();
                    break;
                case "6":
                    AddTeamMember();
                    break;
                case "7":
                    RemoveTeamMember();
                    break;
                case "8":
                    CreateRace();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }


        } while (!exit);
    }

    public delegate void CreateTeamDelegate();
    public delegate void CreateDriverDelegate();
    public delegate void CreateCoachDelegate();

    static void CreateTeam()
    {
        Team team;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Введіть назву команди:");
            string enteredName = Console.ReadLine();

            try
            {
                team = new Team(enteredName);
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        teams.Add(team);
        Console.WriteLine($"Команда {team.TeamName} створена!");
    }

    public static CreateTeamDelegate MyCreateTeamDelegate = CreateTeam;

    static void CreateDriver()
    {
        string enteredName;
        string enteredAge;

        Driver driver;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Введіть ім'я водія:");
            Console.WriteLine();
            enteredName = Console.ReadLine();
            try
            {
                driver = new Driver(enteredName, 18, CarBrand.Audi, 1);
                break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            Console.WriteLine("Введіть вік водія:");
            enteredAge = Console.ReadLine();

            if (int.TryParse(enteredAge, out int age))
            {
                try
                {
                    driver.Age = age;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            else
            {
                try
                {
                    throw new FormatException("Вік повинен бути числом");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        CarBrand car;
        do
        {
            Console.WriteLine("Оберіть марку автомобіля");
            foreach (CarBrand carchoice in Enum.GetValues(typeof(CarBrand)))
            {
                Console.WriteLine($"{(int)carchoice} - {carchoice}");
            }
        }
        while (!Enum.TryParse(Console.ReadLine(), out car) || !Enum.IsDefined(typeof(CarBrand), car));
        driver.Car = car;

        int id;
        do
        {
            Console.WriteLine("Введіть ID водія(0-99):");
        }
        while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > 99);

        driver.Id = id;

        availableDrivers.Add(driver);
        Console.WriteLine($"Водій успішно створений");


    }
    public static CreateDriverDelegate MyCreateDriverDelegate = CreateDriver;

    static void CreateCoach()
    {
        Coach coach;

        string enteredName;
        string enteredAge;
        string enteredSalary;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Введіть ім'я тренера");
            Console.WriteLine();
            enteredName = Console.ReadLine();

            try
            {
                coach = new Coach(enteredName, 18, 1000);
                break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            Console.WriteLine("Введіть вік тренера:");
            enteredAge = Console.ReadLine();

            if (int.TryParse(enteredAge, out int age))
            {
                try
                {
                    coach.Age = age;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            else
            {
                try
                {
                    throw new FormatException("Вік повинен бути числом");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        while (true)
        {
            Console.WriteLine("Введіть з/п тренера");
            enteredSalary = Console.ReadLine();

            if (decimal.TryParse(enteredSalary, out decimal salary))
            {
                try
                {
                    coach.Salary = salary;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            else
            {
                try
                {
                    throw new FormatException("Залплатня повинна бути числом");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }


        }
        availableCoaches.Add(coach);
        Console.WriteLine($"Тренер успішно створений");

    }
    public static CreateCoachDelegate MyCreateCoachDelegate = CreateCoach;

    //Створити команду
    //static void CreateTeam()
    //{
    //    Team team;

    //    while (true)
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("Введіть назву команди:");
    //        string enteredName = Console.ReadLine();

    //        try
    //        {
    //            team = new Team(enteredName);
    //            break;

    //        }
    //        catch (ArgumentException ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }

    //    }
    //    teams.Add(team);
    //    Console.WriteLine($"Команда {team.TeamName} створена!");

    //}


    ////Стоврити водія
    //static void CreateDriver()
    //{
    //    string enteredName;
    //    string enteredAge;

    //    Driver driver;
    //    while (true)
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("Введіть ім'я водія:");
    //        Console.WriteLine();
    //        enteredName = Console.ReadLine();
    //        try
    //        {
    //            driver = new Driver(enteredName, 18, CarBrand.Audi, 1);
    //            break;
    //        }
    //        catch(ArgumentException e) 
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }

    //    while(true)
    //    {
    //        Console.WriteLine("Введіть вік водія:");
    //        enteredAge = Console.ReadLine();

    //        if (int.TryParse(enteredAge, out int age))
    //        {
    //            try
    //            {
    //                driver.Age = age;
    //                break;
    //            }
    //            catch (ArgumentException e)
    //            {
    //                Console.WriteLine(e.Message);
    //                continue;
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                throw new FormatException("Вік повинен бути числом");
    //            }
    //            catch (FormatException e)
    //            {
    //                Console.WriteLine(e.Message);
    //            }
    //        }

    //    }

    //    CarBrand car;
    //    do
    //    {
    //        Console.WriteLine("Оберіть марку автомобіля");
    //        foreach(CarBrand carchoice in Enum.GetValues(typeof(CarBrand))) 
    //        {
    //            Console.WriteLine($"{(int)carchoice} - {carchoice}");
    //        }
    //    }
    //        while (!Enum.TryParse(Console.ReadLine(), out car) || !Enum.IsDefined(typeof(CarBrand), car));
    //    driver.Car = car;

    //    int id;
    //    do
    //    {
    //        Console.WriteLine("Введіть ID водія(0-99):");
    //    }
    //    while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > 99);

    //    driver.Id = id;

    //    availableDrivers.Add(driver);
    //    Console.WriteLine($"Водій успішно створений");
    //}



    ////Створити тренера
    //static void CreateCoach()
    //{
    //    Coach coach;

    //    string enteredName;
    //    string enteredAge;
    //    string enteredSalary;
    //    while (true)
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("Введіть ім'я тренера");
    //        Console.WriteLine();
    //        enteredName = Console.ReadLine();

    //        try
    //        {
    //            coach = new Coach(enteredName, 18, 1000);
    //            break;
    //        }
    //        catch(ArgumentException e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }

    //    }


    //    while (true) 
    //    {
    //        Console.WriteLine("Введіть вік тренера:");
    //        enteredAge = Console.ReadLine();

    //        if (int.TryParse(enteredAge, out int age))
    //        {
    //            try
    //            {
    //                coach.Age = age;
    //                break;
    //            }
    //            catch (ArgumentException e)
    //            {
    //                Console.WriteLine(e.Message);
    //                continue;
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                throw new FormatException("Вік повинен бути числом");
    //            }
    //            catch (FormatException e)
    //            {
    //                Console.WriteLine(e.Message);
    //            }
    //        }

    //    }

    //    while (true)
    //    {
    //        Console.WriteLine("Введіть з/п тренера");
    //        enteredSalary = Console.ReadLine();

    //        if(decimal.TryParse(enteredSalary, out decimal salary))
    //        {
    //            try
    //            {
    //                coach.Salary = salary;
    //                break;
    //            }
    //            catch (ArgumentException e)
    //            {
    //                Console.WriteLine(e.Message);
    //            }

    //        }

    //        else
    //        {
    //            try
    //            {
    //                throw new FormatException("Залплатня повинна бути числом");
    //            }
    //            catch(FormatException e)
    //            {
    //                Console.WriteLine(e.Message);
    //            }
    //        }


    //    }
    //    availableCoaches.Add(coach);
    //    Console.WriteLine($"Тренер успішно створений");
    //}


    //Показати доступних водіїв
    static void DisplayAvailableDrivers()
    {
        Console.WriteLine("Список доступних водіїв:");
        foreach (var driver in availableDrivers)
        {
            Console.WriteLine($"{driver.Name}, Age: {driver.Age}, Car:{driver.Car} Id: {driver.Id}");
        }
    }



    //Показати команди
    static void DisplayTeams()
    {
        Console.WriteLine("Список команд та їх членів:");
        foreach (var team in teams)
        {
            Console.WriteLine($"Команда: {team.TeamName}");
            foreach (var member in team.Members)
            {
                Console.WriteLine($"{member.GetType().Name}: {member.Name}, Age: {member.Age}");
            }
            if (team.Coach != null)
            {
                Console.WriteLine($"Тренер: {team.Coach.Name}, Age: {team.Coach.Age}");
            }
            Console.WriteLine();
        }
    }


    //Додати мембера в команду
    static void AddTeamMember()
    {
        Console.WriteLine("Оберіть команду в яку хочете додати члена:");

        // Виведення існуючих команд
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1} {teams[i].TeamName}");
        }

        // Введення та перевірка введеного значення
        int teamChoice;
        if (int.TryParse(Console.ReadLine(), out teamChoice) && teamChoice >= 1 && teamChoice <= teams.Count)
        {
            Team selectedTeam = teams[teamChoice - 1];

            Console.WriteLine("Список вже існуючих водіїв та тренерів:");

            // Виведення існуючих водіїв
            Console.WriteLine("Водії:");
            foreach (Driver existingDriver in availableDrivers)
            {
                Console.WriteLine($"- {existingDriver.Name}");
            }

            // Виведення існуючих тренерів
            Console.WriteLine("Тренери:");
            foreach (Coach existingCoach in availableCoaches)
            {
                Console.WriteLine($"- {existingCoach.Name}");
            }

            Console.WriteLine("Оберіть члена команди:");

            // Введення та перевірка введеного значення
            string memberName = Console.ReadLine();
            IPerson existingMember = availableDrivers.FirstOrDefault(driver => driver.Name == memberName) as IPerson
                       ?? availableCoaches.FirstOrDefault(coach => coach.Name == memberName) as IPerson;

            if (existingMember != null)
            {
                availableDrivers.Remove(existingMember as Driver);
                availableCoaches.Remove(existingMember as Coach);
                selectedTeam.Members.Add(existingMember);
                Console.WriteLine($"{memberName} доданий до команди {selectedTeam.TeamName}!");
            }
            else
            {
                Console.WriteLine($"Члена команди {memberName} не знайдено серед доступних водіїв та тренерів.");
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір команди.");
        }
    }

    //Видалення з команди
    static void RemoveTeamMember()
    {
        Console.WriteLine("Оберіть команду, з якої хочете видалити члена:");

        // Виведення існуючих команд
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1} {teams[i].TeamName}");
        }

        // Введення та перевірка введеного значення
        int teamChoice;
        if (int.TryParse(Console.ReadLine(), out teamChoice) && teamChoice >= 1 && teamChoice <= teams.Count)
        {
            Team selectedTeam = teams[teamChoice - 1];

            Console.WriteLine($"Список членів команди {selectedTeam.TeamName}:");

            // Виведення членів команди
            foreach (IPerson teamMember in selectedTeam.Members)
            {
                Console.WriteLine($"- {teamMember.Name}");
            }

            Console.WriteLine("Оберіть члена команди для видалення:");

            // Введення та перевірка введеного значення
            string memberName = Console.ReadLine();
            IPerson memberToRemove = selectedTeam.Members.FirstOrDefault(member => member.Name == memberName);

            if (memberToRemove != null)
            {
                selectedTeam.Members.Remove(memberToRemove);
                // Додайте члена команди назад до доступних водіїв або тренерів за потреби
                if (memberToRemove is Driver)
                {
                    availableDrivers.Add(memberToRemove as Driver);
                }
                else if (memberToRemove is Coach)
                {
                    availableCoaches.Add(memberToRemove as Coach);
                }
                Console.WriteLine($"{memberName} видалений з команди {selectedTeam.TeamName}!");
            }
            else
            {
                Console.WriteLine($"Члена команди {memberName} не знайдено серед членів команди {selectedTeam.TeamName}.");
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір команди.");
        }
    }

    //Створення заїзду 
    static void CreateRace()
    {
        Console.WriteLine("Оберіть команди для заїзду:");

        // Виведення існуючих команд
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1} {teams[i].TeamName}");
        }

        Console.Write("Виберіть першу команду (введіть номер): ");
        int teamChoice1;
        while (!int.TryParse(Console.ReadLine(), out teamChoice1) || teamChoice1 < 1 || teamChoice1 > teams.Count)
        {
            Console.WriteLine("Невірний вибір. Введіть ще раз: ");
        }

        Console.Write("Виберіть другу команду (введіть номер): ");
        int teamChoice2;
        while (!int.TryParse(Console.ReadLine(), out teamChoice2) || teamChoice2 < 1 || teamChoice2 > teams.Count || teamChoice2 == teamChoice1)
        {
            Console.WriteLine("Невірний вибір. Введіть ще раз: ");
        }

        Team selectedTeam1 = teams[teamChoice1 - 1];
        Team selectedTeam2 = teams[teamChoice2 - 1];

        Race newRace = new Race(selectedTeam1, selectedTeam2);
        races.Add(newRace);

        Console.WriteLine($"Заїзд між командами {selectedTeam1.TeamName} та {selectedTeam2.TeamName} успішно створений!");
    }
}
