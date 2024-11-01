namespace Shared.DataTransferObjects.Client
{
    public record ClientDto(Guid ClientId, string Name, string Contact, string Email, string Password);
}