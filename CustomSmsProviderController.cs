using System.Web.Mvc;
using U2UConsult.IdentityHub.Web.Controllers;

namespace U2UConsult.DemoSmsProvider
{
    [RequireHttps]
    public sealed class CustomSmsProviderController : BaseController
    {
        [HttpGet]
        public ActionResult Detail()
        {
            var smsProvider = GetSmsProvider();
            if (smsProvider == null)
            {
                return new HttpUnauthorizedResult();
            }

            return CustomView(smsProvider.ConfigurationSettings as CustomSmsProviderConfiguration);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var smsProvider = GetSmsProvider() as CustomSmsProvider;
            if (smsProvider == null)
            {
                return new HttpUnauthorizedResult();
            }

            return CustomView(smsProvider.ConfigurationSettings as CustomSmsProviderConfiguration);
        }

        [HttpPost]
        public ActionResult Edit(CustomSmsProviderConfiguration model)
        {
            if (!ModelState.IsValid)
            {
                return CustomView(model);
            }

            var smsProvider = GetSmsProvider() as CustomSmsProvider;

            if (smsProvider == null)
            {
                return new HttpUnauthorizedResult();
            }

            var smsProviderManager = smsProvider.SmsProviderManager as CustomSmsProviderManager;

            if (smsProviderManager == null)
            {
                return new HttpUnauthorizedResult();
            }

            smsProviderManager.UpdateSmsProviderConfiguration(model);

            return RedirectToAction("Detail");
        }
    }
}