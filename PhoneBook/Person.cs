namespace PhoneBook;

public class Person
{
    public Guid Id { get; set; }

    private readonly string _firstName;
    public required string FirstName
    {
        get => _firstName;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }
            _firstName = value;
        }
    }
    
    private readonly string _lastName;
    public required string LastName
    {
        get => _lastName;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Фамилия не может быть пустой");
            }
            _lastName = value;
        }
    }
    
    public string FullName => $"{FirstName} {LastName}";
    
    private readonly DateTime? _birthDate;
    public required DateTime? BirthDate
    {
        get => _birthDate;
        init
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Дата рождения не может быть позже текущей даты");
            }
            
            _birthDate = value;
        } 
    }
    private int? GetAge()
    {
        if(BirthDate is null) return null;
        
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Value.Year;
        if (BirthDate.Value.Date > today.AddYears(-age)) age--;
        
        return age;
    }
    public int? Age => GetAge();
}
