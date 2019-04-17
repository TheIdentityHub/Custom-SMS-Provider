using System;
using U2UConsult.IdentityHub.Contracts.SmsProviders;
using U2UConsult.IdentityHub.ServiceProvider.SmsProvider;

namespace U2UConsult.DemoSmsProvider
{
    internal sealed class CustomSmsProviderManager : SmsProviderManager<CustomSmsProviderConfiguration, CustomSmsProvider>
    {
        public override Uri SmsProviderDefaultImageUrl => null;
        public override string SmsProviderDisplayName => CustomSmsProviderManagerFactory.CustomSmsProviderDisplayName;

        public override SmsProviderProtocol SmsProviderProtocol => SmsProviderProtocol.Custom;

        public override Guid SmsProviderTypeId => CustomSmsProviderManagerFactory.TypeId;
    }
}