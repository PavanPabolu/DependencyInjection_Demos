namespace DI.KeyServices.WebAPI.Services
{
    public sealed class SMSNotificationService : INotificationService
    {
        public string Send() => $"SMS Sent!";
    }
}
