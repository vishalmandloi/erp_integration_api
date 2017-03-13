using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace erp_integration_api.Modules.Pricing.Entities
{
    public class PricingEntity
    {
        [DataMember]
        public string ListPrice { get; set; }
        [DataMember]
        public string CustPrice { get; set; }
        [DataMember]
        public string QuantityMessage { get; set; }
        [DataMember]
        public string PriceSource { get; set; }
        [DataMember]
        public string Cost { get; set; }
        [DataMember]
        public string MinMarginPercentage { get; set; }
        [DataMember]
        public string MaxDiscPercentage { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string ReferencePrice { get; set; }
        [DataMember]
        public string AvailableQty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WSEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WhseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ActualPeriod { get; set; }
    }
}