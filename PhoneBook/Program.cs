using PhoneBook;

var phoneBook = new Dictionary<Person, List<PhoneNumber>>() 
{
    {
        new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(1980, 1, 1)
        },
        [
            new PhoneNumber()
            {
                Type = TypeOfPhoneNumber.Unknown,
                Number = "123-456-7890"
            }
        ]
    },
    {
        new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = "Dennis",
            LastName = "Doe",
            BirthDate = null
        },
        [
            new PhoneNumber()
            {
                Type = TypeOfPhoneNumber.Mobile,
                Number = "123-456-7890"
            },
            new PhoneNumber()
            {
                Type = TypeOfPhoneNumber.Work,
                Number = "123-456-7890"
            }
        ]
    },
};

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("=================");
Console.WriteLine("=== PhoneBook ===");
Console.WriteLine("=================");

var exit = false;
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("+++ МЕНЮ +++");
    Console.WriteLine("1. Добавить контакт");
    Console.WriteLine("2. Удалить контакт");
    Console.WriteLine("3. Найти контакт");
    Console.WriteLine("4. Показать все контакты");
    Console.WriteLine("0. Выход");
    
    Console.Write("Ваш выбор: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": // 1. Добавить контакт
            // TODO Сделать дома!
            break;
        
        case "2": // 2. Удалить контакт
            Console.Write("Введите ID для поиска: ");
            var id = Console.ReadLine();

            var result1 = from item in phoneBook
                let person = item.Key
                where person.Id == Guid.Parse(id)
                select person;

            if (!result1.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Контакта не найдено!");
                break;
            }
            
            phoneBook.Remove(result1.First());
            break;
        
        case "3": // 3. Найти контакт
            Console.Write("Введите имя для поиска: ");
            var name = Console.ReadLine();
            
            var result = from item in phoneBook
                let person = item.Key
                let numbers = item.Value
                where person.FirstName.ToLower().StartsWith(name.ToLower()) 
                      || person.LastName.ToLower().StartsWith(name.ToLower())
                select new
                {
                    Person = person, 
                    Numbers = numbers
                };

            if (!result.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ничего не найдено!");
                break;
            }
            
            foreach (var item in result)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{item.Person.Id}: {item.Person.FullName}");
                
                foreach (var number in item.Numbers)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t\t{number.Type}: {number.Number}");
                }
            }
            break;
        
        case "4": // 4. Показать все контакты
            foreach (var (person, numbers) in phoneBook)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{person.Id}: {person.FullName}");
                
                foreach (var number in numbers)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t\t{number.Type}: {number.Number}");
                }
            }
            break;
        
        case "0": // 0. Выход
            exit = true;
            break;
        
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы ввели неверный вариант!");
            break;
    }
} while (!exit);

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.Write("До свидания!");
Console.ResetColor();