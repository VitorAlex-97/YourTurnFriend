namespace YourTurnFriend.Infra.ExternalServices.Security.Exceptions;

public class SecurityConfigurationException : Exception
{
    private const string _message = "SecurityConfiguration not found.";
    public SecurityConfigurationException() : base(_message)
    {
        
    }
}