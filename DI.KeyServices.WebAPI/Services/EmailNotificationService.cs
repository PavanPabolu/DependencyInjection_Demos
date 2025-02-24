namespace DI.KeyServices.WebAPI.Services
{
    public sealed class EmailNotificationService : INotificationService
    {
        public string Send() => $"Email Sent!";
    }
}
