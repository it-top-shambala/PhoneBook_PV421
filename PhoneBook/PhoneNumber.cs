namespace PhoneBook;

public enum TypeOfPhoneNumber
{
    Unknown,
    Home,
    Mobile,
    Work
}

public class PhoneNumber
{
    public required TypeOfPhoneNumber Type { get; init; }
    
    private readonly string _number;
    public required string Number { 
        get => _number;
        init
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Телефонный номер не может быть пустым");
            }
            
            _number = value;
        } 
    }
}