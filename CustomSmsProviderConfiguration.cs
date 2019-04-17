using U2UConsult.IdentityHub.Contracts.SmsProviders;

namespace U2UConsult.DemoSmsProvider
{
    public sealed class CustomSmsProviderConfiguration : SmsProviderConfiguration
    {
        public string AccountId { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}