public enum PersonType
{
    Individual,
    LegalEntity
}

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public PersonType PersonType { get; set; }
    public string CPF_CNPJ { get; set; }
    public string StateRegistration { get; set; }
    public bool IsExempt { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsBlocked { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public DateTime RegistrationDate { get; set; }
}