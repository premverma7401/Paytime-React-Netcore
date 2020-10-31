namespace Paytime.Application.Interfaces
{
    public interface IUserAccessor
    {
        string GetCurrentUser();
        string UserId { get; }

    }
}