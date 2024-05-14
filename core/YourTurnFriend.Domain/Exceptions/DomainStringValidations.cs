namespace YourTurnFriend.Domain.Exceptions;

internal static class DomainStringValidations
{
    internal static void MinLength(int minLength, string target, string propertyName)
    {
        var isNullOrWhiteSpace = string.IsNullOrWhiteSpace(target);

        DomainExceptionValidation.When(target.Length < minLength || isNullOrWhiteSpace, 
                                        $"{propertyName} must have at least {minLength} characters.");
    }

    internal static void MaxLength(int maxLength, string target, string propertyName)
    {
        DomainExceptionValidation.When(target.Length > maxLength, 
                                        $"{propertyName} must have less than {maxLength} characters.");
    }
}
