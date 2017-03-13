using AspDotNetStorefrontCore;
using erp_integration_api.Helper;
using erp_integration_api.Modules.Pricing.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace erp_integration_api.Modules.Pricing.Models
{
    public class PricingModel
    {
        internal PricingEntity calculatePrice(string erp_cust_guid, string cutomerId, string qty, string productId, string variantId, string ship2_id, string productGuid)
        {
            var pricing = new PricingEntity();

            var dtwhsid = getWhsID(erp_cust_guid, "729b84c7-ed09-428a-83e3-87f6d5a9a927");
            try
            {

                var priceTable = pricecalculate.GetPromoPrice(dtwhsid.WhseId, productGuid, ship2_id, Convert.ToInt32(qty), dtwhsid.ActualPeriod);
                if (priceTable != null && priceTable.Rows.Count > 0)
                {
                    return new PricingEntity
                    {
                        ListPrice = Convert.ToString(priceTable.Rows[0][0]),
                        CustPrice = Convert.ToString(priceTable.Rows[0][1]),
                        AvailableQty = Convert.ToString(priceTable.Rows[0][2]),
                        QuantityMessage = Convert.ToString(priceTable.Rows[0][3]),
                        ReferencePrice = Convert.ToString(priceTable.Rows[0][4]),
                        PriceSource = Convert.ToString(priceTable.Rows[0][5]),
                        Cost = Convert.ToString(priceTable.Rows[0][6]),
                        MinMarginPercentage = Convert.ToString(priceTable.Rows[0][7]),
                        MaxDiscPercentage = Convert.ToString(priceTable.Rows[0][8]),
                    };

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // dataaccess = null;
            }
            //pricing = GetPromoPrice(dtwhsid.WhseId, productGuid, ship2_id, qty, dtwhsid.ActualPeriod);

            return null;
        }

        private WSEntity getWhsID(string erp_cust_guid, string userid)
        {
            try
            {
                var parms = new Dictionary<string, string>();
                parms.Add("customerid", erp_cust_guid);
                parms.Add("userId", userid);
                var ds = SQLHelper.ExecuteProcedureWithReturnDataSet("SetWhesIdandActualprice", parms);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return new WSEntity
                    {
                        WhseId = Convert.ToString(ds.Tables[0].Rows[0]["WhseID"]),
                        ActualPeriod = Convert.ToString(ds.Tables[0].Rows[0]["ActualPeriod"])
                    };
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // dataaccess = null;
            }
            return null;
        }


        #region GetPromoPrice()
        private PricingEntity GetPromoPrice(string whseId, string productGuid, string shipId, string qty, string actualPeriod)
        {
            try
            {
                var parms = new Dictionary<string, string>();
                parms.Add("whse_id", whseId);
                parms.Add("item_id", productGuid);
                parms.Add("ship2_id", shipId);
                parms.Add("qty", qty);
                parms.Add("period", actualPeriod);
                parms.Add("promo_item_id", productGuid);
                parms.Add("is_fractional", "N");
                var ds = SQLHelper.ExecuteProcedureWithReturnDataSet("p_cds_sf_oe_pricing_engine", parms);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return new PricingEntity
                    {
                        ListPrice = Convert.ToString(ds.Tables[0].Rows[0][0]),
                        CustPrice = Convert.ToString(ds.Tables[0].Rows[0][1]),
                        AvailableQty = Convert.ToString(ds.Tables[0].Rows[0][2]),
                        QuantityMessage = Convert.ToString(ds.Tables[0].Rows[0][3]),
                        ReferencePrice = Convert.ToString(ds.Tables[0].Rows[0][4]),
                        PriceSource = Convert.ToString(ds.Tables[0].Rows[0][5]),
                        Cost = Convert.ToString(ds.Tables[0].Rows[0][6]),
                        MinMarginPercentage = Convert.ToString(ds.Tables[0].Rows[0][7]),
                        MaxDiscPercentage = Convert.ToString(ds.Tables[0].Rows[0][8]),
                    };

                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // dataaccess = null;
            }

        }
        #endregion



    }
}