// See https://aka.ms/new-console-template for more information
using ProjectB;

class Program
{
    static List<Team> teams = new List<Team>();
    static List<Driver> availableDrivers = new List<Driver>();
    static List<Coach> availableCoaches = new List<Coach>();

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
                    CreateTeam();
                    break;
                case "2":
                    CreateDriver();
                    break;
                case "3":
                    CreateCoach();
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
                //case "7":
                //    RemoveTeamMember();
                //    break;
                //case "8":
                //    CreateRace();
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

    static void CreateTeam()
    {
        Console.WriteLine("Введіть назву команди:");
        string teamName = Console.ReadLine();
        Team newTeam = new Team { TeamName = teamName };
        teams.Add(newTeam);
        Console.WriteLine($"Команда {teamName} створена!");
    }

    static void CreateDriver()
    {
        Console.WriteLine("Введіть ім'я водія:");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть вік водія:");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Виберіть марку автомобіля з наступних опцій:");

        // Отримання всіх значень з enum CarBrand та їх вивід
        foreach (CarBrand brand in Enum.GetValues(typeof(CarBrand)))
        {
            Console.WriteLine($"{(int)brand}. {brand}");
        }

        // Введення та перевірка введеного значення
        if (Enum.TryParse(Console.ReadLine(), out CarBrand carBrand))
        {
            Console.WriteLine("Введіть ідентифікатор водія:");
            int id = int.Parse(Console.ReadLine());

            Driver newDriver = new Driver(id, name, age, carBrand);
            availableDrivers.Add(newDriver);
            Console.WriteLine($"Водій {name} створений!");
        }
        else
        {
            Console.WriteLine("Невірний вибір марки автомобіля.");
        }
    }

    static void CreateCoach()
    {
        Console.WriteLine("Введіть ім'я тренера:");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть вік тренера:");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть зарплату тренера:");
        int salary = int.Parse(Console.ReadLine());

        Coach newCoach = new Coach(name, age, salary);
        availableCoaches.Add(newCoach);
        Console.WriteLine($"Тренер {name} створений!");
    }

    static void DisplayAvailableDrivers()
    {
        Console.WriteLine("Список доступних водіїв:");
        foreach (var driver in availableDrivers)
        {
            Console.WriteLine($"{driver.Name}, Age: {driver.Age}");
        }
    }

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
}
