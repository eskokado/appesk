var isValidStateRegistration = false;
var isValidEmail = false;
var isValidCpfCnpj = false;
$(document).ready(function() {
    var cpfCnpjInput = $('#cpfCnpjInput');
    var isExemptCheckbox = $('#IsExempt');
    var stateRegistrationInput = $('#StateRegistration');
    var personType = $('#PersonType');

    $('[data-toggle="tooltip"]').tooltip();
    $('#Phone').inputmask("(99) 99999-9999");
    if (isExemptCheckbox.prop('checked')) {
        stateRegistrationInput.inputmask("");
        stateRegistrationInput.val('ISENTO');
        stateRegistrationInput.prop('disabled', true);
    } else {
        stateRegistrationInput.prop('disabled', false);
        stateRegistrationInput.inputmask("999.999.999.999", { numericInput: true }); 
    }
    
    cpfCnpjInput.inputmask("999.999.999-99", { numericInput: true });
    stateRegistrationInput.inputmask("999.999.999.999", { numericInput: true }); 

    personType.change(function() {
        var PersonType = $(this).val();

        if (PersonType == 0) {
            $('#cpfCnpjInput').inputmask("999.999.999-99", { numericInput: true });
        } else {
            $('#cpfCnpjInput').inputmask("99.999.999/9999-99", { numericInput: true });
        }
    });

    isExemptCheckbox.on('change', function() {
        if (isExemptCheckbox.prop('checked')) {
            stateRegistrationInput.inputmask("");
            stateRegistrationInput.val('ISENTO');
            stateRegistrationInput.prop('disabled', true);
        } else {
            stateRegistrationInput.prop('disabled', false);
            stateRegistrationInput.val('');
            stateRegistrationInput.inputmask("999.999.999.999", { numericInput: true }); 
        }
    });
});

function validationHandler(event) {
    event.preventDefault();
    validateForm(event);
}

function validateForm(event) {
    var form = $('form');
    var isValid = true;

    var cpfCnpjInputValue = $('#cpfCnpjInput').inputmask('unmaskedvalue');
    $('#cpfCnpjInput').val(cpfCnpjInputValue.replace(/\D/g, ''));
    var stateRegistrationInputValue = $('#StateRegistration').inputmask('unmaskedvalue');
    $('#StateRegistration').val(stateRegistrationInputValue.replace(/\D/g, ''));

    isValid = validateField(form, '#Email', '/Customer/ValidateEmail/', 'Este e-mail já está cadastrado para outro Cliente');
    isValid = validateField(form, '#cpfCnpjInput', '/Customer/ValidateCpfCnpj/', 'Este Cpf/Cnpj já está cadastrado para outro Cliente') && isValid;
    isValid = validateField(form, '#StateRegistration', '/Customer/ValidateStateRegistration/', 'Esta Inscrição Estadual já está cadastrada para outro Cliente') && isValid;

     if (isValid) {
        form.append('<input type="hidden" name="clientValidationFailed" value="false" />');
    } else {
        form.append('<input type="hidden" name="clientValidationFailed" value="true" />');
    }
    
    var tempoEmMilissegundos = 500;
    event.preventDefault();
    setTimeout(function() {
        form.submit();
    }, tempoEmMilissegundos);
}