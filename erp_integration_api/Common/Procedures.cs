using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xcd.ERP.API.Common
{
    public static class Procedures
    {
        public static string SPCompanyTypeAHead = "p_CDS_SyCompany_Select_TypeAHead";
        public static string SPCheckEligibleLine = "p_ADC_Create_Receipt_Header";
        public static string SPCreateReceiptDetails = "p_ADC_Create_Receipt_Detail";
        public static string SPCreateReceiptDetailsNew = "Porv_Create_Receipt_Header";
        public static string SPUpdateReceiptDetails = "p_ADC_Update_Receipt_Detail";
        public static string SPCreateOrUpdateReceiptLineUnitCtrl = "p_ADCCreateReceiptLineUnitCtrl";
        public static string SPGetReceiptDetail = "p_ADCGetReceiptDtls";
        public static string SPGetReceiptUnitControl = "P_PORV_GET_UNIT_CONTROL_DATA";
        public static string SPDeleteReceipt = "p_ADC_Delete_Receipt";
        public static string SPPostBatch = "p_po_receipt_batch_Post";
        public static string SPUserLogin = "p_PORVUserLogin";
        public static string SPPrintBatchWorkSheet = "p_CDSEDMReceivingWorksheet";
        public static string SPPrintBatchPutAway = "p_CDSEDMPOPutAway";
        public static string SPUpdateInventory = "p_PORV_Update_Inventory";
        public static string SPCheckShippingOrderStatus = "P_PORV_CHECK_SHIPPING_ORDER_STATUS";
        public static string SPGetPODetails = "p_CDS_GetPODetails";
        public static string SPGetReworkPODetails = "p_ADC_Get_REWORK_PO_Details";
        public static string SPReworkPostBatch = "p_po_receipt_batch_rework_po_post";
    }
}