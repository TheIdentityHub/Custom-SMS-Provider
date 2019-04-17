using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;
using U2UConsult.IdentityHub.Contracts.SmsProviders;
using U2UConsult.IdentityHub.ServiceProvider.SmsProvider;

namespace U2UConsult.DemoSmsProvider
{
    public sealed class CustomSmsProvider : SmsProviderBase
    {
        public override SmsProviderConfiguration ConfigurationSettings { get; set; }

        public override string Description => CustomSmsProviderManagerFactory.CustomSmsProviderDescription;

        public override string DisplayName => CustomSmsProviderManagerFactory.CustomSmsProviderDisplayName;

        public override ISmsProviderManager SmsProviderManager { get; set; }

        public override Guid SmsProviderTypeId => CustomSmsProviderManagerFactory.TypeId;

        public override Task<Uri> GetDetailUrlAsync(string tenant)
        {
            var adminTenant = CustomSmsProviderManager.GetTenantUrlSegment(HttpContext.Current.Request);

            return Task.FromResult(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                    CustomSmsProviderManagerFactory.CustomSmsProviderDetailUrl,
                    adminTenant)));
        }

        public override Task<Uri> GetUpdateUrlAsync(string tenant)
        {
            var adminTenant = CustomSmsProviderManager.GetTenantUrlSegment(HttpContext.Current.Request);

            return Task.FromResult(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                    CustomSmsProviderManagerFactory.CustomSmsProviderUpdateUrl,
                    adminTenant)));
        }

        public override Task<SendSmsResult> SendSms(string phoneNumber, string text)
        {
            // do something to make this custom provider send sms

            return Task.FromResult(SendSmsResult.Success);
        }
    }
}