using System;
using System.ComponentModel.DataAnnotations;

public enum PersonType
{
    [Display(Name = "Pessoa Física")]
    Individual,
    [Display(Name = "Pessoa Jurídica")]
    LegalEntity
}

public enum Gender
{
    [Display(Name = "Masculino")]
    Male,
    
    [Display(Name = "Feminino")]
    Female
}

public class CustomerModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(150, ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo E-mail não está em um formato válido.")]
    [StringLength(150, ErrorMessage = "O campo E-mail deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [Phone(ErrorMessage = "O campo Telefone não está em um formato válido.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "O campo Tipo de Pessoa é obrigatório.")]
    public PersonType PersonType { get; set; }

    [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
    [StringLength(14, ErrorMessage = "O campo CPF/CNPJ deve ter no máximo {1} caracteres.")]
    public string CPF_CNPJ { get; set; }

    [Required(ErrorMessage = "O campo Inscrição Estadual é obrigatório.")]
    [StringLength(12, ErrorMessage = "O campo Inscrição Estadual deve ter no máximo {1} caracteres.")]
    public string StateRegistration { get; set; }

    public bool IsExempt { get; set; }

    [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public bool IsBlocked { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "O campo Confirmação de Senha é obrigatório.")]
    [Compare("Password", ErrorMessage = "A confirmação de senha não corresponde à senha.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmação de Senha")]
    public string ConfirmPassword { get; set; }

    public DateTime RegistrationDate { get; set; }
}
