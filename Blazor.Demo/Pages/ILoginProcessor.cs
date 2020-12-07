namespace Blazor.Demo.Pages
{
    public interface ILoginProcessor
    {
        bool Login(string email, string password);
    }
}