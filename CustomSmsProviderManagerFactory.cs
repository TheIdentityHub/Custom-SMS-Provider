using System;
using U2UConsult.IdentityHub.Common.Configuration;
using U2UConsult.IdentityHub.Contracts.SmsProviders;

namespace U2UConsult.DemoSmsProvider
{
    [SmsProviderManagerFactory]
    internal sealed class CustomSmsProviderManagerFactory : ISmsProviderManagerFactory
    {
        internal static readonly string CustomSmsProviderDescription = "Custom Sms Provider Description";
        internal static readonly string CustomSmsProviderDetailUrl = HubConfiguration.HubUrl + "/{0}/CustomSmsProvider/Detail";
        internal static readonly string CustomSmsProviderDisplayName = "Custom Sms Provider";
        internal static readonly string CustomSmsProviderUpdateUrl = HubConfiguration.HubUrl + "/{0}/CustomSmsProvider/Edit";
        internal static readonly Guid TypeId = new Guid("{BBE9B487-DB78-4009-96D3-181C1B6B8DF1}");

        public Guid SmsProviderTypeId => TypeId;

        public ISmsProviderManager GetSmsProviderManager()
        {
            return new CustomSmsProviderManager();
        }
    }
}