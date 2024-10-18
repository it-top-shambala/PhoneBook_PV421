namespace PhoneBook;

public class Person
{
    public Guid Id { get; set; }

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _firstName = value;
            }
        }
    }
    
    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _lastName = value;
            }
        }
    }
    
    public string FullName => $"{FirstName} {LastName}";
    
    private DateTime _birthDate;
    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (value <= DateTime.Now)
            {
                _birthDate = value;
            }
        } 
    }
    private int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        if (BirthDate.Date > today.AddYears(-age)) age--;
        
        return age;
    }
    public int Age => GetAge();
}
