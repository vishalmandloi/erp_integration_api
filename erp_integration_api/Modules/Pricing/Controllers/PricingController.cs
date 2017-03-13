using erp_integration_api.Common;
using erp_integration_api.Modules.Pricing.Entities;
using erp_integration_api.Modules.Pricing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace erp_integration_api.Modules.Pricing.Controllers
{
    [RoutePrefix("api")]
    public class PricingController : ApiController
    {
        public Response<PricingEntity> Get(string erpCustGuid, string cutomerId, string qty, string productId, string variantId , string erpShipingId, string productGuid)
        {
            Response<PricingEntity> response = new Response<PricingEntity>();
            var pricingModel = new PricingModel();
            var result = pricingModel.calculatePrice(erpCustGuid, cutomerId, qty, productId, variantId, erpShipingId, productGuid);
            if (result != null)
            {
                response.Create(true, Messages.FormatMessage("succees"), Messages.AppVersion, result);
            }
            else
            {
                response.Create(false, "try again", Messages.AppVersion, result);
            }
            return response;
        }
    }
}
