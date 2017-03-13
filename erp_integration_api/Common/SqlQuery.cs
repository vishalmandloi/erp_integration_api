using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xcd.ERP.API.Common
{
    public class SqlQuery
    {

        public static string GetVendorMaster(int limit, string vendor_no)
        {
            var sb = new StringBuilder("");
			sb.AppendLine("   SELECT   COUNT(*) OVER() as RowsCount, "
  + "  AP_VENDOR.VENDOR_ID as VENDOR_ID,  "
  + "  AP_VENDOR.VENDOR_NO as VENDOR_NO,  "
  + "  AP_VENDOR.VENDOR_NAME as VENDOR_NAME,  "
  + "  AP_VENDOR.TEL_NO as TEL_NO,  "
  + "  AP_VENDOR.FAX_NO as FAX_NO,  "
  + "  AP_VENDOR.CURRENCY as CURRENCY,  "
  + "  AP_VENDOR.E_MAIL_ADDRESS as E_MAIL_ADDRESS,  "
  + "  AP_VENDOR.WEB_ADDRESS as WEB_ADDRESS,  "
  + "  AP_VENDOR.IS_ITEM_SUPPLIER as IS_ITEM_SUPPLIER,  "
  + "  AP_VENDOR.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID,  "
  + "  vw_location_control.ZIP as ZIP, "
  + "  vw_location_control.COUNTY as COUNTY, "
  + "  vw_location_control.CITY as CITY, "
  + "  vw_location_control.STATE_CODE as STATE_CODE, "
  + "  vw_location_control.COUNTRY as COUNTRY, "
  + "  vw_location_control.PHONE_MASK as PHONE_MASK, "
  + "  vw_location_control.DIAL_CODE as DIAL_CODE,  "
  + "  AP_VENDOR.OUR_ACCT_NO as OUR_ACCT_NO,  "
  + "  AP_VENDOR.ADDRESS as ADDRESS,  "
  + "  vw_location_control.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID1,  "
  + "  AP_VENDOR.MEMO_STATUS as MEMO_STATUS,  "
  + "  AP_VENDOR_CLASS.CLASS_CODE as CLASS_CODE,  "
  + "  AP_VENDOR.STATUS_ID as STATUS_ID  "
  + "  FROM  "
  + "  AP_VENDOR as AP_VENDOR (nolock)  "
  + "  Left Outer Join vw_location_control as vw_location_control (nolock) on "
  + "    vw_location_control.ZIP_CODE_DTL_ID = AP_VENDOR.ZIP_CODE_DTL_ID "
  + "  Left Outer Join AP_VENDOR_CLASS as AP_VENDOR_CLASS (nolock) on "
  + "    AP_VENDOR_CLASS.CLASS_ID = AP_VENDOR.CLASS_ID ");


            if (vendor_no.ToUpper().Trim() != "NULL")
            {
                sb.AppendLine(" WHERE AP_VENDOR.VENDOR_NO = @VENDOR_NO ");
            }

            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY AP_VENDOR.VENDOR_NO  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT ROWS ONLY ");
            }



            return sb.ToString();
        }


        public static string SelectVendorInGrid()
        {
            var sb = new StringBuilder("");
            sb.AppendLine("  select count(*) over() as RowsCount, "
                + " AP_VENDOR.VENDOR_ID, "
                + " AP_VENDOR.VENDOR_NO, "
                + " AP_VENDOR.VENDOR_NAME, "
                + " AP_VENDOR.ADDR, "
                + " AP_VENDOR.ZIP_CODE_DTL_ID,  "
                + " dbo.zip_code4(VW_LOCATION_CONTROL.ZIP, AP_VENDOR.ZIP4) as ZIP,  "
                + " AP_VENDOR.ZIP4 as ZIP4,  "
                + " VW_LOCATION_CONTROL.CITY, "
                + " VW_LOCATION_CONTROL.COUNTY, "
                + " VW_LOCATION_CONTROL.STATE_CODE, "
                + " VW_LOCATION_CONTROL.COUNTRY, "
                + " AP_VENDOR.TEL_NO, "
                + " AP_VENDOR.FAX_NO, "
                + " AP_VENDOR.GL_MASTER_ACCT_ID, "
                + " AP_VENDOR.CLASS_UDF_ENUM_ID, "
                + " AP_VENDOR.CURRENCY, "
                + " AP_VENDOR.OUR_ACCT_NO, "
                + " AP_VENDOR.AR_TERMS_ID, "
                + " AP_VENDOR.TAX_ID_NO, "
                + " AP_VENDOR.IS_INDIVIDUAL, "
                + " AP_VENDOR.FLAG_1099, "
                + " AP_VENDOR.IS_FOREIGN, "
                + " AP_VENDOR.NAME_CTRL_FOR_1099, "
                + " AP_VENDOR.AVG_PAY_DAYS, "
                + " AP_VENDOR.DATE_OPENED, "
                + " AP_VENDOR.LAST_PUR_DATE, "
                + " AP_VENDOR.LAST_PMT_DATE, "
                + " AP_VENDOR.LAST_CHK_NO, "
                + " AP_VENDOR.LAST_PO_NO, "
                + " AP_VENDOR.LAST_INVOICE_NO, "
                + " AP_VENDOR.LAST_PAY_DAYS, "
                + " AP_VENDOR.MIN_PAY_DAYS, "
                + " AP_VENDOR.COMMENT, "
                + " AP_VENDOR.CURRENT_BALANCE, "
                + " AP_VENDOR.HIGH_BAL, "
                + " AP_VENDOR.HIGH_DATE, "
                + " AP_VENDOR.CREDIT_LIMIT, "
                + " AP_VENDOR.STATUS_ID, "
                + " AP_VENDOR.LANGUAGE, "
                + " AP_VENDOR.IS_EDI_PARTNER, "
                + " AP_VENDOR.IS_ITEM_SUPPLIER, "
                + " AP_VENDOR.IS_TEMP_VENDOR, "
                + " AP_VENDOR.E_MAIL_ADDRESS, "
                + " AP_VENDOR.WEB_ADDRESS, "
                + " AP_VENDOR.IS_TAX_ALLOWED, "
                + " AP_VENDOR.IS_PO_REQUIRED, "
                + " AP_VENDOR.IS_PAID_BY_EFT, "
                + " AP_VENDOR.IS_FRT_ALLOWED, "
                + " AP_VENDOR.IS_DISCOUNT_REQUIRED, "
                + " AP_VENDOR.IS_LATE_DISCOUNT_OK, "
                + " AP_VENDOR.MEMO_STATUS, "
                + " AP_VENDOR.PAYTO_VENDOR_ID, "
                + " AP_PAYEE.PAYEE_NAME,  "
                + " AP_PAYEE.PAY_ADDRESS, "
                + " AP_PAYEE.ZIP_CODE_DTL_ID as PAYEE_ZIP_CODE_DTL_ID,  "
                + " dbo.zip_code4(VP.ZIP, AP_PAYEE.ZIP4) as PAYEE_ZIP,  "
                + " AP_PAYEE.ZIP4 as PAYEE_ZIP4,  "
                + " VP.CITY as PAYEE_CITY, "
                + " VP.COUNTY as PAYEE_COUNTY, "
                + " VP.STATE_CODE as PAYEE_STATE_CODE, "
                + " VP.COUNTRY as PAYEE_COUNTRY, "
                + " AP_VENDOR_INVEN.BUYER_ID, "
                + " AP_VENDOR_INVEN.BROKER_ID, "
                + " AP_VENDOR_INVEN.CARRIER_ID, "
                + " AP_VENDOR_INVEN.RESTOCK_RATE, "
                + " AP_VENDOR_INVEN.RETURN_JAN, "
                + " AP_VENDOR_INVEN.RETURN_FEB, "
                + " AP_VENDOR_INVEN.RETURN_MAR, "
                + " AP_VENDOR_INVEN.RETURN_APR, "
                + " AP_VENDOR_INVEN.RETURN_MAY, "
                + " AP_VENDOR_INVEN.RETURN_JUN, "
                + " AP_VENDOR_INVEN.RETURN_JUL, "
                + " AP_VENDOR_INVEN.RETURN_AUG, "
                + " AP_VENDOR_INVEN.RETURN_SEP, "
                + " AP_VENDOR_INVEN.RETURN_OCT, "
                + " AP_VENDOR_INVEN.RETURN_NOV, "
                + " AP_VENDOR_INVEN.RETURN_DEC, "
                + " AP_VENDOR_INVEN.BALANCE_PERCENTAGE, "
                + " AP_VENDOR_INVEN.REVIEW_CYCLE, "
                + " AP_VENDOR_INVEN.REVIEW_DATE, "
                + " AP_VENDOR_INVEN.CONSIGNEE, "
                + " AP_VENDOR_INVEN.PO_CANCEL_DAYS, "
                + " AP_VENDOR_INVEN.IS_FOB_DEST, "
                + " AP_VENDOR_INVEN.IS_BO_OK, "
                + " AP_VENDOR_INVEN.IS_ACKNOWLEDGED, "
                + " AP_VENDOR_INVEN.IS_CONFIRMING, "
                + " AP_VENDOR_INVEN.IS_PO_APPEND_OK, "
                + " AP_VENDOR_INVEN.DELIVERY_TYPE, "
                + " AP_VENDOR_INVEN.FRT_PAY_METHOD, "
                + " AP_VENDOR_INVEN.ALLOW_VENDOR_DIRECT, "
                + " AP_VENDOR_INVEN.WARRANTY_GL_MASTER_ACCT_ID, "
                + " AP_VENDOR_INVEN.USE_LANDED_COST "

                + " from  AP_VENDOR  "
                + " LEFT OUTER JOIN AP_VENDOR_INVEN ON (AP_VENDOR.VENDOR_ID = AP_VENDOR_INVEN.VENDOR_ID) "
                + " LEFT OUTER JOIN AP_PAYEE ON (AP_PAYEE.VENDOR_ID = AP_VENDOR.VENDOR_ID) "
                + " LEFT OUTER JOIN VW_LOCATION_CONTROL on (AP_VENDOR.ZIP_CODE_DTL_ID = VW_LOCATION_CONTROL.ZIP_CODE_DTL_ID) "
                + " LEFT OUTER JOIN VW_LOCATION_CONTROL VP on (AP_PAYEE.ZIP_CODE_DTL_ID = VP.ZIP_CODE_DTL_ID) "

                + " where AP_VENDOR.VENDOR_ID =@VENDOR_ID "

                + "");

            return sb.ToString();

        }


        public static string SelectedVendor()
        {
            var sb = new StringBuilder();

            sb.AppendLine("  SELECT  count(*) over() as RowsCount, "
                    + " AP_VENDOR.VENDOR_ID, "
                    + " AP_VENDOR.VENDOR_NO, "
                    + " AP_VENDOR.VENDOR_NAME, "
                    + " AP_VENDOR.ADDR, "
                    + " AP_VENDOR.ZIP_CODE_DTL_ID, "
                    + " AP_VENDOR.ZIP4, "
                    + " AP_VENDOR.TEL_NO, "
                    + " AP_VENDOR.FAX_NO, "
                    + " AP_VENDOR.GL_MASTER_ACCT_ID, "
                    + "  (convert(varchar(10) , GL_MASTER_ACCT.ACCT_NO) + '-' + convert(varchar(8), GL_MASTER_ACCT.SUBACCT)) as ACCT_COMBO, "
                    + " AP_VENDOR.DEPT_ID, "
                    + " AP_VENDOR.CLASS_ID, "
                    + " AP_VENDOR.CURRENCY, "
                    + " AP_VENDOR.OUR_ACCT_NO, "
                    + " AP_VENDOR.AR_TERMS_ID, "
                    + " AP_VENDOR.TAX_ID_NO, "
                    + " AP_VENDOR.IS_INDIVIDUAL, "
                    + " AP_VENDOR.FLAG_1099, "
                    + " AP_VENDOR.IS_FOREIGN, "
                    + " AP_VENDOR.NAME_CTRL_FOR_1099, "
                    + " AP_VENDOR.AVG_PAY_DAYS, "
                    + " AP_VENDOR.DATE_OPENED, "
                    + " AP_VENDOR.LAST_PUR_DATE, "
                    + " AP_VENDOR.LAST_PMT_DATE, "
                    + " AP_VENDOR.LAST_CHK_NO, "
                    + " AP_VENDOR.LAST_PO_NO, "
                    + " AP_VENDOR.LAST_INVOICE_NO, "
                    + " AP_VENDOR.LAST_PAY_DAYS, "
                    + " AP_VENDOR.MIN_PAY_DAYS, "
                    + " AP_VENDOR.COMMENT, "
                    + " AP_VENDOR.CURRENT_BALANCE, "
                    + " AP_VENDOR.HIGH_BAL, "
                    + " AP_VENDOR.HIGH_DATE, "
                    + " AP_VENDOR.CREDIT_LIMIT, "
                    + " AP_VENDOR.STATUS_ID, "
                    + " AP_VENDOR.LANGUAGE, "
                    + " AP_VENDOR.IS_EDI_PARTNER, "
                    + " AP_VENDOR.IS_ITEM_SUPPLIER, "
                    + " AP_VENDOR.E_MAIL_ADDRESS, "
                    + " AP_VENDOR.WEB_ADDRESS, "
                    + " AP_VENDOR.IS_TAX_ALLOWED, "
                    + " AP_VENDOR.IS_PO_REQUIRED, "
                    + " AP_VENDOR.IS_PAID_BY_EFT, "
                    + " AP_VENDOR.IS_FRT_ALLOWED, "
                    + " AP_VENDOR.IS_DISCOUNT_REQUIRED, "
                    + " AP_VENDOR.IS_LATE_DISCOUNT_OK, "
                    + " AP_VENDOR.PAYTO_VENDOR_ID, "
                    + " AP_VENDOR.LAST_PMT_AMT,  "
                    + " AP_VENDOR.IS_COMMENT_PRINT_PO,  "
                    + " AP_VENDOR.IS_COMMENT_PRINT_VRQ,  "
                    + " AP_VENDOR.IS_COMMENT_PRINT_VRA,  "
                    + " AP_VENDOR.IS_COMMENT_PRINT_WS, "
                    + " AP_VENDOR.IS_COMMENT_PRINT_CHECK, "
                    + " AP_VENDOR.MEMO_STATUS, "
                    + " vw_location_control.ZIP, "
                    + " vw_location_control.CITY,  "
                    + " vw_location_control.COUNTY,  "
                    + " vw_location_control.STATE_CODE,  "
                    + " vw_location_control.STATE,  "
                    + " vw_location_control.COUNTRY, "
                    + " dbo.ap_open_1099_balance(AP_VENDOR.VENDOR_ID, dbo.enspire_date(current_timestamp), 'Y') as ap_open_1099_fiscal, "
                    + " dbo.ap_open_1099_balance(AP_VENDOR.VENDOR_ID, dbo.enspire_date(current_timestamp), 'N') as ap_open_1099_calendar "

                    + " FROM AP_VENDOR (nolock)  "
                    + "  LEFT OUTER JOIN GL_MASTER_ACCT  (nolock) on (AP_VENDOR.GL_MASTER_ACCT_ID = GL_MASTER_ACCT.GL_MASTER_ACCT_ID) "
                    + "   LEFT OUTER  JOIN vw_location_control vw_location_control  (nolock) ON  (vw_location_control.ZIP_CODE_DTL_ID = AP_VENDOR.ZIP_CODE_DTL_ID) "

                    + "  WHERE ( "
                    + "    ((AP_VENDOR.VENDOR_ID =@VENDOR_ID )) "
                    + "        ) "

                    + "");

            return sb.ToString();
        }


        public static string SelectedVendor_INVEN()
        {
            var sb = new StringBuilder();

            sb.AppendLine("  SELECT "

                  + "   AP_VENDOR_INVEN.VENDOR_ID,  "
                  + "   AP_VENDOR_INVEN.BUYER_ID,  "
                  + "   AP_VENDOR_INVEN.BROKER_ID,  "
                  + "   AP_VENDOR_INVEN.CARRIER_ID,  "
                  + "   AP_VENDOR_INVEN.SERVICE_CODE_ID, "
                  + "   AP_VENDOR_INVEN.RESTOCK_RATE,  "
                  + "   AP_VENDOR_INVEN.BALANCE_PERCENTAGE,  "
                  + "   AP_VENDOR_INVEN.REVIEW_CYCLE,  "
                  + "   AP_VENDOR_INVEN.REVIEW_DATE,  "
                  + "   AP_VENDOR_INVEN.CONSIGNEE,  "
                  + "   AP_VENDOR_INVEN.PO_CANCEL_DAYS,  "
                  + "   AP_VENDOR_INVEN.IS_FOB_DEST,  "
                  + "   AP_VENDOR_INVEN.IS_BO_OK,  "
                  + "   AP_VENDOR_INVEN.IS_ACKNOWLEDGED,  "
                  + "   AP_VENDOR_INVEN.IS_CONFIRMING,  "
                  + "   AP_VENDOR_INVEN.IS_PO_APPEND_OK, "
                  + "   AP_VENDOR_INVEN.DELIVERY_TYPE,  "
                  + "   AP_VENDOR_INVEN.FRT_PAY_METHOD,  "
                  + "   AP_VENDOR_INVEN.ALLOW_VENDOR_DIRECT,  "
                  + "   AP_VENDOR_INVEN.IS_COST_PRINT_OK, "
                  + "   AP_VENDOR_INVEN.RETURN_JAN,  "
                  + "   AP_VENDOR_INVEN.RETURN_FEB,  "
                  + "   AP_VENDOR_INVEN.RETURN_MAR,  "
                  + "   AP_VENDOR_INVEN.RETURN_APR,  "
                  + "   AP_VENDOR_INVEN.RETURN_MAY,  "
                  + "   AP_VENDOR_INVEN.RETURN_JUN,  "
                  + "   AP_VENDOR_INVEN.RETURN_JUL,  "
                  + "   AP_VENDOR_INVEN.RETURN_AUG,  "
                  + "   AP_VENDOR_INVEN.RETURN_SEP,  "
                  + "   AP_VENDOR_INVEN.RETURN_OCT,  "
                  + "   AP_VENDOR_INVEN.RETURN_NOV,  "
                  + "   AP_VENDOR_INVEN.RETURN_DEC,  "
                  + "   AP_VENDOR_INVEN.WARRANTY_GL_MASTER_ACCT_ID, "
                  + "  dbo.gl_acct_combo(WARRANTY_GL_MASTER_ACCT_ID) as ACCT_COMBO, "
                  + "   AP_VENDOR_INVEN.DEPT_ID, "
                  + "   AP_VENDOR_INVEN.USE_LANDED_COST, "
                  + "   AP_VENDOR_INVEN.PO_LIMIT, "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_FILE_TYPE,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_SN_BEG_COL,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_SN_END_COL,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_ITEM_BEG_COL,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_ITEM_END_COL,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_QTY_BEG_COL,  "
                  + "   AP_VENDOR_INVEN.UNIT_CTRL_QTY_END_COL "

              + "  FROM  "
                + "   AP_VENDOR_INVEN AP_VENDOR_INVEN (nolock)  "

              + "  WHERE ( "
              + "   ((AP_VENDOR_INVEN.VENDOR_ID = @VENDOR_ID )) "
              + "  ) "

                );

            return sb.ToString();
        }


        public static string AP_VENDOR_LANDED_COST()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT"
                    + " DBO.AP_VENDOR_LANDED_COST.VENDOR_ID AS VENDOR_ID, "
                    + " DBO.AP_VENDOR_LANDED_COST.LANDED_COST_ID AS LANDED_COST_ID, "
                    + " DBO.AP_VENDOR_LANDED_COST.LANDED_COST_CODE, "
                    + " DBO.AP_VENDOR_LANDED_COST.DESCRIPTION, "
                    + " DBO.AP_VENDOR_LANDED_COST.METHOD_ID, "
                    + " DBO.AP_VENDOR_LANDED_COST.BASIS_ID, "
                    + " DBO.AP_VENDOR_LANDED_COST.UNIT_AMT, "
                    + " DBO.AP_VENDOR_LANDED_COST.UNIT_RATE "
                    + " FROM  DBO.AP_VENDOR_LANDED_COST (nolock)  "

                    + "  WHERE ( "
                    + "    ((AP_VENDOR_LANDED_COST.VENDOR_ID = @VENDOR_ID )) "
                    + " ) "

              + " ");
            return sb.ToString();
        }


        public static string LOAD_FACTORS()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                        + " AP_VENDOR_LOAD.VENDOR_ID AS VENDOR_ID, "
                        + " AP_VENDOR_LOAD.BRACKET, "
                        + " AP_VENDOR_LOAD.COST_ADJ_PERCENTAGE "
                        + " FROM  AP_VENDOR_LOAD (nolock)  "

                        + "  WHERE ( "
                        + "    ((AP_VENDOR_LOAD.VENDOR_ID = @VENDOR_ID )) "
                        + " ) "

                        + "   ");

            return sb.ToString();

        }

        public static string Payee()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT  "
                        + " DBO.AP_PAYEE.VENDOR_ID AS VENDOR_ID, "
                        + " DBO.AP_PAYEE.PAYEE_NAME, "
                        + " DBO.AP_PAYEE.PAY_ADDRESS, "
                        + " DBO.AP_PAYEE.ZIP_CODE_DTL_ID, "
                        + " DBO.AP_PAYEE.ZIP4, "
                        + " DBO.AP_PAYEE.TEL_NO AS TEL_NO, "
                        + " DBO.AP_PAYEE.FAX_NO AS FAX_NO, "
                        + " DBO.AP_PAYEE.E_MAIL_ADDRESS AS E_MAIL_ADDRESS, "
                        + " DBO.AP_PAYEE.WEB_ADDRESS AS WEB_ADDRESS, "
                        + " VW_LOCATION_CONTROL.ZIP as PAY_ZIP, "
                        + " VW_LOCATION_CONTROL.CITY as PAY_CITY, "
                        + " VW_LOCATION_CONTROL.COUNTY as PAY_COUNTY, "
                        + " VW_LOCATION_CONTROL.STATE_CODE as PAY_STATE, "
                        + " VW_LOCATION_CONTROL.COUNTRY as PAY_COUNTRY "
                        + " FROM  DBO.AP_PAYEE (nolock)  "
                        + "   LEFT OUTER  JOIN VW_LOCATION_CONTROL  (nolock) on (DBO.AP_PAYEE.ZIP_CODE_DTL_ID = VW_LOCATION_CONTROL.ZIP_CODE_DTL_ID) "

                         + "  WHERE ( "
                         + "   ((AP_PAYEE.VENDOR_ID = @VENDOR_ID )) "
                        + "  ) "
                        );


            return sb.ToString();

        }

        public static string Target()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  SELECT  "
                        + " AP_VENDOR_BUY_CONTROL.VENDOR_ID AS VENDOR_ID, "
                        + " AP_VENDOR_BUY_CONTROL.UNIT_BASIS_ID, "
                        + " AP_VENDOR_BUY_CONTROL.TARGET, "
                        + " AP_VENDOR_BUY_CONTROL.MIN_ORDER, "
                        + " AP_VENDOR_BUY_CONTROL.FREE_FRT "
                        + " FROM  AP_VENDOR_BUY_CONTROL (nolock)  "

                        + "  WHERE ( "
                            + "   ((AP_VENDOR_BUY_CONTROL.VENDOR_ID = @VENDOR_ID )) "
                        + " ) "
                        );
            return sb.ToString();

        }

        public static string ShipFrom()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                          + " AP_VENDOR_SHIP_FROM.VENDOR_ID,  "
                          + " AP_VENDOR_SHIP_FROM.AP_SHIP_FROM_ID,  "
                          + " AP_VENDOR_SHIP_FROM.SHIP_NAME,  "
                          + " AP_VENDOR_SHIP_FROM.ADDR,  "
                          + " AP_VENDOR_SHIP_FROM.ZIP_CODE_DTL_ID, "
                          + " AP_VENDOR_SHIP_FROM.ZIP4, "
                          + " VW_LOCATION_CONTROL.ZIP, "
                          + " VW_LOCATION_CONTROL.CITY, "
                          + " VW_LOCATION_CONTROL.COUNTY, "
                          + " VW_LOCATION_CONTROL.STATE_CODE, "
                          + " VW_LOCATION_CONTROL.COUNTRY, "
                          + " AP_VENDOR_SHIP_FROM.TEL_NO,  "
                          + " AP_VENDOR_SHIP_FROM.FAX_NO,  "
                          + " AP_VENDOR_SHIP_FROM.E_MAIL_ADDRESS "
                     + " FROM  "
                       + "    AP_VENDOR_SHIP_FROM AP_VENDOR_SHIP_FROM (nolock)  "

                     + " LEFT OUTER JOIN VW_LOCATION_CONTROL  (nolock) on ( AP_VENDOR_SHIP_FROM.ZIP_CODE_DTL_ID = VW_LOCATION_CONTROL.ZIP_CODE_DTL_ID) "
                     + "  WHERE ( "
                     + "    ((AP_VENDOR_SHIP_FROM.VENDOR_ID = @VENDOR_ID )) "
                     + " ) "

                );

            return sb.ToString();
        }

       

        public static string RebateHDR()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                            + " AP_REBATE_HDR.AP_REBATE_ID AS AP_REBATE_ID, "
                            + " AP_REBATE_HDR.VENDOR_ID AS VENDOR_ID, "
                            + " AP_VENDOR.VENDOR_NO, "
                            + " AP_VENDOR.VENDOR_NAME, "
                            + " AP_REBATE_HDR.CUST_ID AS CUST_ID, "
                            + " AR_CUST.CUST_NO, "
                            + " AR_CUST.CUST_NAME, "
                            + " AP_REBATE_HDR.SHIP2_ID AS SHIP2_ID, "
                            + " AR_SHIP2.SHIP_NO, "
                            + " AR_SHIP2.SHIP2_NAME, "
                            + " AP_REBATE_HDR.CONTRACT_ID AS CONTRACT_ID, "
                            + " OE_CONTRACT_HDR.CONTRACT, "
                            + " AP_REBATE_HDR.DESCRIPTION, "
                            + " AP_REBATE_HDR.AUTH_NO, "
                            + " AP_REBATE_HDR.GL_MASTER_ACCT_ID AS GL_MASTER_ACCT_ID, "
                            + " AP_REBATE_HDR.BEGIN_DATE, "
                            + " AP_REBATE_HDR.END_DATE, "
                            + " AP_REBATE_HDR.REBATE_TYPE, "
                            + " AP_REBATE_HDR.TABLE_BASIS_ID, "
                            + " dbo.gl_acct_combo(AP_REBATE_HDR.GL_MASTER_ACCT_ID) as ACCT_COMBO, "
                            + " dbo.gl_acct_no(AP_REBATE_HDR.GL_MASTER_ACCT_ID) as ACCT_NO, "
                            + " AP_REBATE_HDR.VCONTRACT_ID, "
                            + " AP_CONTRACT_HDR.CONTRACT AS VENDOR_CONTRACT "

                            + " FROM AP_REBATE_HDR (nolock) INNER JOIN AP_VENDOR (nolock) ON (AP_REBATE_HDR.VENDOR_ID = AP_VENDOR.VENDOR_ID) "
                            + " LEFT OUTER JOIN AR_CUST (nolock) ON (AP_REBATE_HDR.CUST_ID = AR_CUST.CUST_ID) "
                            + " LEFT OUTER JOIN AR_SHIP2 (nolock) ON (AP_REBATE_HDR.CUST_ID = AR_SHIP2.CUST_ID AND AP_REBATE_HDR.SHIP2_ID = AR_SHIP2.SHIP2_ID) "
                            + " LEFT OUTER JOIN OE_CONTRACT_HDR (nolock) ON (AP_REBATE_HDR.CONTRACT_ID = OE_CONTRACT_HDR.CONTRACT_ID) "
                            + " LEFT OUTER JOIN AP_CONTRACT_HDR (nolock) on (AP_REBATE_HDR.VCONTRACT_ID = AP_CONTRACT_HDR.VCONTRACT_ID) WHERE  "
                            + "( "
                             + "   ((AP_REBATE_HDR.VENDOR_ID = @VENDOR_ID )) "
                            + " ) "

                );
            return sb.ToString();
        }


        /// <summary>
        /// CONTRACT
        /// </summary>
        public static string ContractHDR()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                            + " AP_CONTRACT_HDR.VENDOR_ID AS VENDOR_ID, "
                            + " AP_CONTRACT_HDR.VCONTRACT_ID AS VCONTRACT_ID, "
                            + " AP_CONTRACT_HDR.CUST_ID AS CUST_ID, "
                            + " AR_CUST.CUST_NO, "
                            + " AR_CUST.CUST_NAME, "
                            + " AP_CONTRACT_HDR.SHIP2_ID AS SHIP2_ID, "
                            + " AR_SHIP2.SHIP_NO, "
                            + " AR_SHIP2.SHIP2_NAME, "
                            + " AP_CONTRACT_HDR.CONTRACT, "
                            + " AP_CONTRACT_HDR.DESCRIPTION, "
                            + " AP_CONTRACT_HDR.START_DATE, "
                            + " AP_CONTRACT_HDR.END_DATE, "
                            + " AP_CONTRACT_HDR.AR_SHIP2_CONTRACT_ID as AR_SHIP2_CONTRACT_ID, "
                            + " OE_CONTRACT_HDR.CONTRACT_ID, "
                            + " OE_CONTRACT_HDR.CONTRACT as PRICE_CONTRACT "
                            + " FROM AP_CONTRACT_HDR (nolock)  "
                            + " LEFT OUTER JOIN AR_SHIP2  (nolock) ON (AP_CONTRACT_HDR.SHIP2_ID = AR_SHIP2.SHIP2_ID) "
                            + " LEFT OUTER JOIN AR_CUST  (nolock) ON (AP_CONTRACT_HDR.CUST_ID = AR_CUST.CUST_ID) "
                            + " LEFT OUTER JOIN AR_SHIP2_CONTRACT  (nolock) on (AR_SHIP2_CONTRACT.AR_SHIP2_CONTRACT_ID = AP_CONTRACT_HDR.AR_SHIP2_CONTRACT_ID) "
                            + " LEFT OUTER JOIN OE_CONTRACT_HDR  (nolock) on (OE_CONTRACT_HDR.CONTRACT_ID = AR_SHIP2_CONTRACT.CONTRACT_ID) "

                            + "  WHERE ( "
                             + "   ((AP_CONTRACT_HDR.VENDOR_ID =@VENDOR_ID )) "
                            + " ) "

                );
            return sb.ToString();
        }

        /// KARDEX  RECORDS
        public static string Kardex(int? transaction, DateTime? start_date)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" select "
 + "  newid() as KARDEX_ID,  "
 + "  ap_open_items_hist.TRANS_DATE,  "
 + "  enspire.dbo.sy_user.last_name + ', ' + enspire.dbo.sy_user.first_name as FULL_NAME,  "
 + "  co_batch.BATCH_NAME,  "
 + "  case when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'A' then 'Adjustment'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'C' then 'CM Apply'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'L' then 'Allowance'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'O' then 'OA Apply'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'P' then 'Payment'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'N' then 'NSF Check'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'R' then 'Refund'   "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'V' then 'Void Refund'   "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'E' then 'Orig Entry'  "
 + "       when AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID = 'U' then 'OA Entry'  "
  + "     else  AP_OPEN_ITEMS_HIST.TRANS_TYPE_ID end as TRANS_TYPE_ID,    "
  + "     ap_open_items.INVOICE,  "
  + "     ap_open_items.INVOICE_DATE,   "
  + "     ap_check.CHECK_NO,  "
  + "     ap_open_items_hist.TRANS_AMT,   "
  + "     ap_open_items_hist.TRANS_DISC_TAKEN,   "
  + "     ap_vendor.current_balance as BALANCE,   "
  + "     ap_vendor.CURRENT_BALANCE,  "
  + "     ap_vendor.HIGH_BAL,   "
  + "     ap_vendor.HIGH_DATE,   "
  + "     ap_vendor_class.CLASS_CODE,    "
  + "    ap_vendor.LAST_PO_NO,   "
  + "    ap_open_items.PO_NO,   "
  + "     ar_terms_master.TERMS_CODE, "
  + "     ap_vendor.AVG_PAY_DAYS,   "
  + "     ap_vendor.CREDIT_LIMIT,    "
  + "     case    "
  + "       when ap_vendor.CREDIT_LIMIT > 0 then   "
  + "         ap_vendor.credit_limit - ap_vendor.CURRENT_BALANCE   "
   + "      else   "
   + "        null   "
  + "     end as AVAIL_CREDIT   "
 + "  from ap_open_items_hist  (nolock)   "
 + "    inner join ap_open_items  (nolock) on (ap_open_items_hist.ap_invoice_id = ap_open_items.ap_invoice_id)  "
 + "    inner join ap_vendor  (nolock) on (ap_open_items.vendor_id = ap_vendor.vendor_id)   "
 + "    inner join co_batch  (nolock) on (ap_open_items_hist.batch_id = co_batch.batch_id)   "
 + "    inner join enspire.dbo.sy_user  (nolock) on (co_batch.user_id = enspire.dbo.sy_user.user_id)   "
 + "    left outer join ap_check (nolock)  on (ap_open_items_hist.ap_check_id = ap_check.ap_check_id)  "
 + "    left outer join ap_vendor_class  (nolock) on (ap_vendor.class_id = ap_vendor_class.class_id)    "
 + "    inner join ar_terms_master  (nolock) on (ap_vendor.ar_terms_id = ar_terms_master.ar_terms_id)   "

  );

            if (transaction != null)
            {

                sb.AppendLine("   "
           + "  where ap_open_item_id in  (select top(@TRANSACTION) ap_open_item_id  from ap_open_items_hist (nolock)  "
           + "   inner join ap_open_items  (nolock) on (ap_open_items.ap_invoice_Id = ap_open_items_hist.ap_invoice_Id)  "
           + "  where ap_open_items.vendor_id = @VENDOR_ID    "
           + "    order by trans_date desc)  and ap_open_items.vendor_id = @VENDOR_ID "
           + "    order by ap_open_items_hist.trans_date desc, ap_open_items.invoice "

                 );

            }

            if (start_date != null)
            {
                sb.AppendLine("   "

                + "  where dbo.enspire_date(trans_date) >= '" + start_date.Value.ToString("yyyy-MM-dd") + "'" + " "
                + "  and ap_open_items.vendor_id = @VENDOR_ID "
                + "  order by ap_open_items_hist.trans_date desc, ap_open_items.invoice  "

                );

            }




            return sb.ToString();
        }

        ///
        public static string DiscountHDR()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "

                + " AP_VENDOR_DISC_HDR.VENDOR_ID AS VENDOR_ID, "
                + " AP_VENDOR_DISC_HDR.TABLE_BASIS_ID, "
                + " AP_VENDOR_DISC_HDR.DISCOUNT_LEVEL "
                + " FROM  AP_VENDOR_DISC_HDR (nolock)  "

                + "  WHERE ( "
                + "  ((AP_VENDOR_DISC_HDR.VENDOR_ID = @VENDOR_ID)) "
                + " ) "

 );
            return sb.ToString();

        }


        public static string DiscountDTL()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                       + " DBO.AP_VENDOR_DISC_DTL.VENDOR_ID AS VENDOR_ID, "
                       + " DBO.AP_VENDOR_DISC_DTL.BRACKET_ID AS BRACKET_ID, "
                       + " DBO.AP_VENDOR_DISC_DTL.BRACKET, "
                       + " DBO.AP_VENDOR_DISC_DTL.BUY_AMT, "
                       + " DBO.AP_VENDOR_DISC_DTL.DISC_RATE "
                       + " FROM  DBO.AP_VENDOR_DISC_DTL (nolock)  "
                       + "  WHERE ( "
                       + "    ((AP_VENDOR_DISC_DTL.VENDOR_ID = @VENDOR_ID )) "
                       + " ) "

                   );

            return sb.ToString();
        }


        public static string DocControl()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "

    + " AP_VENDOR_DOC_CONTROL2.DOC_CONTROL_ID,  "
    + " AP_VENDOR_DOC_CONTROL2.VENDOR_ID,  "
    + " AP_VENDOR_DOC_CONTROL2.FILE_ID,  "
    + " AP_VENDOR_DOC_CONTROL2.DOC_CONTROL_DATA,  "
    + " AP_VENDOR_DOC_CONTROL2.MESSAGE_ID,  "
    + " INS_FILES.FILE_NAME as FILE_NAME,  "
    + " CO_DOC_MESSAGES.MSG_CODE   "
    + " from AP_VENDOR_DOC_CONTROL2 as AP_VENDOR_DOC_CONTROL2 (nolock)   "
    + " left outer join [ENSPIRE].DBO.INS_FILES as INS_FILES  (nolock) on AP_VENDOR_DOC_CONTROL2.FILE_ID = INS_FILES.FILE_ID   "
    + " left outer join CO_DOC_MESSAGES  (nolock) on AP_VENDOR_DOC_CONTROL2.MESSAGE_ID = CO_DOC_MESSAGES.MESSAGE_ID   "
    + " WHERE (   "
    + " ((AP_VENDOR_DOC_CONTROL2.VENDOR_ID = @VENDOR_ID ))  "
    + "  )  "
    );

            return sb.ToString();
        }


        public static string DocControltype()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "

             + "  CO_DOC_CONTROL2.DOC_CONTROL_ID as DOC_CONTROL_ID, "
             + " CO_DOC_CONTROL2.DOC_CODE as DOC_CODE, "
             + " CO_DOC_CONTROL2.IS_NUMBER_USED as IS_NUMBER_USED, "
             + " CO_DOC_CONTROL2.NEXT_NO as NEXT_NO, "
             + " CO_DOC_CONTROL2.MAX_DOC_PER_BATCH as MAX_DOC_PER_BATCH, "
             + " CO_DOC_CONTROL2.MESSAGE_ID as MESSAGE_ID, "
             + " CO_DOC_CONTROL2.DEFAULT_MESSAGE_NO as DEFAULT_MESSAGE_NO, "
             + " CO_DOC_CONTROL2.DOC_CONTROL_DATA as DOC_CONTROL_DATA, "
             + " CO_DOC_CONTROL2.FILE_ID as FILE_ID, "
             + " CO_DOC_MESSAGES.MSG_CODE, "
             + " INS_FILES.FILE_NAME as FILE_NAME, "
             + " replace(enspire.dbo.file_path(co_doc_control2.file_id), '\\Insight Report Explorer\','') + "
             + " '\' + ins_files.file_name as file_path, "
             + " CO_DOC_CONTROL.DESCRIPTION "
             + " FROM CO_DOC_CONTROL2 (nolock)  "
             + " left outer join CO_DOC_MESSAGES (nolock)  on CO_DOC_CONTROL2.MESSAGE_ID = CO_DOC_MESSAGES.MESSAGE_ID "
             + " left outer join [ENSPIRE].DBO.INS_FILES as INS_FILES  (nolock) on CO_DOC_CONTROL2.FILE_ID = INS_FILES.FILE_ID "
            
            + "  left outer join CO_DOC_CONTROL (nolock) on CO_DOC_CONTROL.DOC_CONTROL_ID = "
	 + "  CO_DOC_CONTROL2.DOC_CONTROL_ID  "
            
         + "   WHERE ( "
             + " ((CO_DOC_CONTROL2.DOC_TYPE = @DOC_TYPE )) "
             + " ) "
        );

            return sb.ToString();
        }

        // History
        public static string Statistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "

    + "    ACCTG_YEAR,   "
    + "   ACCTG_PERIOD,   "
    + "   STD_INVOICE_AMOUNT,   "
    + "     DISC_AVAILABLE,   "
    + "     PAYMENT_AMOUNT,   "
    + "     DISC_TAKEN,   "
    + "    RELEASED_PO_AMOUNT,   "
    + "     REBATE_AMOUNT,   "
    + "    DIRECT_INVOICE_AMOUNT,   "
    + "    VRA_AMOUNT,   "
    + "    INVOICE_COUNT,   "
    + "    CREDIT_COUNT,   "
    + "     CHECK_COUNT,   "
    + "     DIRECT_PO_COUNT,   "
    + "     STD_PO_COUNT,   "
    + "     RECEIPT_COUNT,   "
    + "     VRA_COUNT,   "
    + "    lines_received as HITS,   "
    + "    miss_late + miss_damage + miss_backorder as MISS,   "
    + "     MISS_LATE,   "
    + "     MISS_DAMAGE,   "
    + "    MISS_BACKORDER,   "
    + "    case   "
    + "      when lines_received > 0 then   "
    + "       cast(round(cast(lines_received - miss_late - miss_damage - miss_backorder as decimal(17,8)) / cast(lines_received as decimal(17,8)) * 100, 2) as money)   "
    + "      else   "
    + "        0   "
    + "   end as SERVICE,   "
    + "    case   "
    + "      when lines_received > 0 then   "
    + "        cast(round(cast(miss_late as decimal(17,8)) / cast(lines_received as decimal(17,8)) * 100, 2) as money)   "
    + "     else   "
    + "       0   "
    + "   end as LATE_PERCENT,   "
    + "   case    "
    + "     when lines_received > 0 then   "
      + "     cast( round(cast(miss_damage as decimal(17,8)) / cast(lines_received as decimal(17,8)) * 100, 2) as money)   "
       + "   else   "
      + "      0   "
      + "  end as DAMAGE_PERCENT,   "
      + "  case   "
      + "    when lines_received > 0 then   "
       + "     cast (round(cast(miss_backorder as decimal(17,8)) / cast(lines_received as decimal(17,8)) * 100, 2) as money)   "
       + "   else   "
      + "      0   "
      + "  end as BACKORDER_PERCENT,  "
     + "   AVG_LEADTIME   "
 + " from ap_statistics (nolock)   "
 + " where vendor_id = @vendor_id   "
   + "         and acctg_year in (@acctg_year, @acctg_year - 1)   "
 + " order by acctg_year,  "
  + "   acctg_period "

  );

            return sb.ToString();
        }

        public static string History_use13th_period()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT  USE_13TH_PERIOD ");
            sb.AppendLine(" from co_misc_control (nolock) ");

            return sb.ToString();

        }


        //docstat
        public static string DocStat()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  SELECT ");
            sb.AppendLine(" "
                + "         po_doc_hdr.PO_DOC_ID,  "
                + "    po_doc_hdr.DOC_NO,  "
                + "    po_doc_hdr.PO_DOC_TYPE_ID,  "
                + "    case po_doc_hdr.PO_DOC_TYPE_ID  "
                + "      when 'B' then   'PO'  "
                + "     when 'D' then  "
                + "        'Vendor Direct'  "
                + "       when 'O' then  "
                + "        'Buy Out'  "
                + "      when 'R' then  "
                + "        'Rework'  "
                + "      when 'Q' then  "
                + "        'Quote'  "
                + "      when 'V' then  "
                + "        'VRA'  "
                + "      else  "
                 + "       'UNKNOWN'  "
                + "    end as DOC_TYPE,  "
                + "    in_warehouse.WHSE_CODE,  "
                + "    po_doc_hdr.PO_DATE,  "
                + "    po_doc_hdr.DATE_RECEIVED,  "
                + "    ar_cust.CUST_NO,  "
                + "    ar_cust.CUST_NAME,  "
                + "    round(sum(po_doc_dtl.qty_ordered * (po_doc_dtl.unit_cost - (po_doc_dtl.family_disc_amt/po_doc_hdr.exchange_rate) - (po_doc_dtl.vendor_discount/po_doc_hdr.exchange_rate))), 2) as PO_AMT,  "
                 + "   case po_doc_hdr.STATUS_ID  "
                + "      when 'W' then  "
                 + "       'Worksheet'  "
                 + "     when 'E' then  "
                 + "       'Entered'  "
                 + "     when 'P' then  "
                 + "       'Printed'  "
                 + "     when 'R' then  "
                 + "       'Released'  "
                 + "     when 'C' then  "
                 + "         'Closed'  "
                 + "    end as STATUS  "
             + " from po_doc_hdr (nolock)  "
              + "    inner join po_doc_dtl (nolock) on (po_doc_hdr.po_doc_id = po_doc_dtl.po_doc_id)  "
              + "    inner join in_warehouse (nolock) on (po_doc_hdr.whse_id = in_warehouse.whse_id)  "
              + "    left outer join oe_doc_hdr (nolock) on (po_doc_hdr.oe_doc_id = oe_doc_hdr.oe_doc_id)  "
               + "   left outer join ar_cust (nolock) on (oe_doc_hdr.cust_id = ar_cust.cust_id)  "

             + " where po_doc_hdr.vendor_id = @VENDORID  "

             + " group by po_doc_hdr.po_doc_id,  "
             + "         po_doc_hdr.doc_no,  "
             + "        po_doc_hdr.po_doc_type_id,  "
             + "         in_warehouse.whse_code,  "
             + "         po_doc_hdr.po_date,  "
             + "         po_doc_hdr.date_received,  "
             + "         ar_cust.cust_no,  "
             + "         ar_cust.cust_name,  "
             + "         case po_doc_hdr.status_id  "
             + "           when 'W' then  "
             + "            'Worksheet'  "
             + "           when 'E' then  "
             + "            'Entered'  "
             + "           when 'P' then  "
             + "             'Printed'  "
             + "           when 'R' then  "
             + "             'Released'  "
             + "           when 'C' then  "
             + "             'Closed'  "
             + "         end  "
             + " order by po_doc_hdr.po_date desc,  "
             + "   po_doc_hdr.doc_no desc  "

             );



            return sb.ToString();


        }


      
        
        
        #region new one test


        public static string BindVendor_Class(Guid? classid)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT   ");
            sb.AppendLine(" CLASS_ID,CLASS_CODE,[DESCRIPTION] from AP_VENDOR_CLASS ");
            if (classid != null)
            {
                sb.AppendLine(" WHERE CLASS_ID = @CLASS_ID");
            }

            return sb.ToString();

        }

        public static string ZipCode(int limit)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT   "
            + "   vw_location_control.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID,  "
            + "   vw_location_control.CITY as CITY,  "
            + "   vw_location_control.COUNTY as COUNTY,  "
            + "   vw_location_control.STATE_CODE as STATE_CODE,  "
            + "   vw_location_control.STATE as STATE,  "
            + "   vw_location_control.ZIP as ZIP,  "
            + "   vw_location_control.COUNTRY_CODE as COUNTRY_CODE,  "
            + "   vw_location_control.COUNTRY as COUNTRY,  "
            + "   vw_location_control.DESCRIPTION as DESCRIPTION  "
            + " FROM  "
            + "   vw_location_control as vw_location_control (nolock)  ");

           
                sb.AppendLine("  WHERE  (( vw_location_control.ZIP LIKE @ZIPCODE+'%' ))  ");

            
           
            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY vw_location_control.ZIP  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT  ROWS ONLY ");
            }

            




            return sb.ToString();
        }

        public static string ZipCodeID()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT   "
            + "   vw_location_control.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID,  "
            + "   vw_location_control.CITY as CITY,  "
            + "   vw_location_control.COUNTY as COUNTY,  "
            + "   vw_location_control.STATE_CODE as STATE_CODE,  "
            + "   vw_location_control.STATE as STATE,  "
            + "   vw_location_control.ZIP as ZIP,  "
            + "   vw_location_control.COUNTRY_CODE as COUNTRY_CODE,  "
            + "   vw_location_control.COUNTRY as COUNTRY,  "
            + "   vw_location_control.DESCRIPTION as DESCRIPTION  "
            + " FROM  "
            + "   vw_location_control as vw_location_control (nolock)  ");
                       
           
                sb.AppendLine("  WHERE ((vw_location_control.ZIP_CODE_DTL_ID = @ZIPCODE_ID))  ");


            return sb.ToString();
        }



        public static string FamilyHDR()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  SELECT "

+ "  DBO.AP_FAMILY_HDR.VENDOR_ID AS VENDOR_ID,  "  
+ "  DBO.AP_FAMILY_HDR.AP_FAMILY_ID AS AP_FAMILY_ID,  "  
+ "  DBO.AP_FAMILY_HDR.FAMILY,  "  
+ "  DBO.AP_FAMILY_HDR.DESCRIPTION,  "  
+ "  DBO.AP_FAMILY_HDR.TABLE_BASIS_ID,  "  
+ "  DBO.AP_FAMILY_HDR.DISCOUNT_LEVEL,  "  
+ "  DBO.AP_FAMILY_HDR.MIN_BUY,  "  
+ "  DBO.AP_FAMILY_HDR.IS_SINGLE_ITEM_OK  "  
+ "  FROM  DBO.AP_FAMILY_HDR (nolock)    "  
+ "   WHERE (  "
+ "     ((AP_FAMILY_HDR.VENDOR_ID = @VENDOR_ID))  "  
+ "  )  "  

            );

                return sb.ToString();
        }

        public static string FamilyDTL()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  SELECT "

 + "  DBO.AP_FAMILY_HDR.VENDOR_ID AS VENDOR_ID,  "
 + "  DBO.AP_FAMILY_DTL.AP_FAMILY_ID AS AP_FAMILY_ID,  "
 + "  DBO.AP_FAMILY_DTL.BRACKET,  "
 + "  DBO.AP_FAMILY_DTL.BRACKET_ID AS BRACKET_ID,  "
 + "  DBO.AP_FAMILY_DTL.BUY_AMT,  "
 + "  DBO.AP_FAMILY_DTL.DISC_RATE  "
 + "  FROM DBO.AP_FAMILY_DTL (nolock)   "
 + "   INNER JOIN DBO.AP_FAMILY_HDR  (nolock) ON (DBO.AP_FAMILY_DTL.AP_FAMILY_ID = DBO.AP_FAMILY_HDR.AP_FAMILY_ID)   "
  + "  WHERE (  "
   + "   ((AP_FAMILY_HDR.VENDOR_ID = @VENDOR_ID))  "
 + "  )  "


            );

            return sb.ToString();
        }

        public static string Archive(int offset , int limit )
        {
            var sb =

			@" select COUNT(*) OVER() as RowsCount, po_doc_hdr.PO_DOC_ID,
       po_doc_hdr.DOC_NO,
       po_doc_hdr.PO_DATE,
       in_warehouse.WHSE_CODE,
       case po_doc_hdr.PO_DOC_TYPE_ID
         when 'B' then
           'PO'
         when 'D' then
           'Vendor Direct'
         when 'O' then
           'Buy Out'
         when 'R' then
           'Rework'
         when 'Q' then
           'Quote'
         when 'V' then
           'VRA'
         else
           'UNKNOWN'
       end as DOC_TYPE,
       ar_cust.CUST_NO,
       ar_cust.CUST_NAME,
       sum(po_doc_dtl.qty_ordered * (po_doc_dtl.unit_cost - po_doc_dtl.family_disc_amt - po_doc_dtl.vendor_discount)) as PO_AMT
from po_doc_hdr (nolock)
     inner join po_doc_dtl (nolock) on (po_doc_hdr.po_doc_id = po_doc_dtl.po_doc_id)
     inner join in_warehouse (nolock) on (po_doc_hdr.whse_id = in_warehouse.whse_id) 
     left outer join oe_doc_hdr (nolock) on (po_doc_hdr.oe_doc_id = oe_doc_hdr.oe_doc_id)
     left outer join ar_cust (nolock) on (oe_doc_hdr.cust_id = ar_cust.cust_id)
where po_doc_hdr.po_doc_type_id <> 'Q'
      and po_doc_hdr.status_id = 'C'
      and po_doc_hdr.vendor_id = @VENDOR_ID

         
 group by po_doc_hdr.po_doc_id,  po_doc_hdr.doc_no,  po_doc_hdr.po_date,  in_warehouse.whse_code,  po_doc_hdr.po_doc_type_id,  ar_cust.cust_no,  ar_cust.cust_name  order by po_doc_hdr.po_date,  po_doc_hdr.doc_no 
OFFSET " + offset + " ROWS FETCH NEXT  " + limit + "  ROWS ONLY";


            return sb.ToString();
        }

        public static string ContractDTL()
        {
            var sb =

                @"SELECT
AP_CONTRACT_HDR.VENDOR_ID AS VENDOR_ID,
AP_CONTRACT_DTL.VCONTRACT_ID AS VCONTRACT_ID,
AP_CONTRACT_DTL.VCONTRACT_DTL_ID AS VCONTRACT_DTL_ID,
AP_CONTRACT_DTL.LINE_TYPE,
AP_CONTRACT_DTL.ITEM_ID AS ITEM_ID,
IN_ITEM_MASTER.ITEM_NO,
IN_ITEM_MASTER.BASE_DESCRIPTION,
AP_CONTRACT_DTL.PRODUCT_GROUP_ID AS PRODUCT_GROUP_ID,
AP_CONTRACT_DTL.AP_FAMILY_ID AS AP_FAMILY_ID,
AP_CONTRACT_DTL.LINE_COMMENT,
AP_CONTRACT_DTL.DISC_RATE,
AP_CONTRACT_DTL.UNIT_COST,
AP_CONTRACT_DTL.QTY_UM,
AP_CONTRACT_DTL.QTY_CONV,  
AP_CONTRACT_DTL.AMT_UM,
AP_CONTRACT_DTL.AMT_CONV,
AP_CONTRACT_DTL.BEGIN_DATE,
AP_CONTRACT_DTL.END_DATE,
AP_CONTRACT_DTL.IS_REBATE_OK,
AP_CONTRACT_DTL.IS_FAMILY_DISC_OK,
AP_CONTRACT_DTL.CALC_METHOD_ID,
AP_CONTRACT_DTL.QTY_TABLE_TYPE,
in_item_ref_price.reference_price,
in_vndritem_master.list_price,
IN_ITEM_MASTER.SKU_UM,
AP_CONTRACT_DTL.VENDOR_DISCOUNT

FROM AP_CONTRACT_DTL  (nolock) 
  LEFT OUTER JOIN IN_ITEM_MASTER  (nolock) ON (AP_CONTRACT_DTL.ITEM_ID = IN_ITEM_MASTER.ITEM_ID)
  INNER JOIN AP_CONTRACT_HDR  (nolock) ON (AP_CONTRACT_DTL.VCONTRACT_ID = AP_CONTRACT_HDR.VCONTRACT_ID)
  left outer join in_item_ref_price  (nolock) on (in_item_ref_price.item_id = ap_contract_dtl.item_id)
  left outer join in_vndritem_master  (nolock) on (in_vndritem_master.item_id = ap_contract_dtl.item_id and
                                         in_vndritem_master.vendor_id = ap_contract_hdr.vendor_id)

 WHERE (
   (((AP_CONTRACT_HDR.VENDOR_ID = @VENDOR_ID )) AND
   ((AP_CONTRACT_DTL.LINE_TYPE = @LINE_TYPE )))) ";


            return sb.ToString();

        }


        public static string DocStatDetails()
        {
            var sb =

                @"select po_doc_hdr.DOC_NO,
       ap_vendor.VENDOR_NO,
       ap_vendor.VENDOR_NAME,
       in_warehouse.WHSE_CODE,
       po_doc_dtl.SORT_ORDER,
       po_doc_dtl.LINE_TYPE,
       po_doc_dtl.ITEM_NO,
       po_doc_dtl.BASE_DESCRIPTION,
       round(po_doc_dtl.qty_ordered / po_doc_dtl.buy_conv,8) as QTY_ORDERED,
       round(po_doc_dtl.cum_qty_received / po_doc_dtl.buy_conv,8) as QTY_RECEIVED,
       po_doc_dtl.buy_um,
       round(po_doc_dtl.unit_cost * po_doc_dtl.amt_conv,8) as UNIT_COST,
       po_doc_dtl.AMT_UM,
       po_doc_dtl.PO_DOC_DTL_ID
from po_doc_dtl (nolock)
     inner join po_doc_hdr (nolock) on (po_doc_dtl.po_doc_id = po_doc_hdr.po_doc_id)
     inner join ap_vendor (nolock) on (po_doc_hdr.vendor_id = ap_vendor.vendor_id)
     inner join in_warehouse (nolock) on (po_doc_hdr.whse_id = in_warehouse.whse_id)
where po_doc_dtl.po_doc_id = @PO_DOC_ID ";
            
            return sb.ToString();

        }

        public static string DocMessages()
        {
            var sb = 
                @"SELECT 
       CO_DOC_MESSAGES.MESSAGE_ID, 
       CO_DOC_MESSAGES.DOC_TYPE, 
       CO_DOC_MESSAGES.MSG_NO, 
       CO_DOC_MESSAGES.LANGUAGE_CODE, 
       CO_DOC_MESSAGES.MSG_CODE, 
       CO_DOC_MESSAGES.MESSAGE_TEXT, 
       CO_DOC_MESSAGES.MSG_TEXT,
       CO_DOC_MESSAGES.DOC_CONTROL_ID,
       co_doc_messages.msg_description
FROM 
     CO_DOC_MESSAGES CO_DOC_MESSAGES (nolock) 

 WHERE (
   ((CO_DOC_MESSAGES.DOC_CONTROL_ID = @DOC_CONTROL_ID )) 
       )   ";

            return sb.ToString();

        }


        public static string Aging()
        {
            var sb =
                @"select 
  ap_invoice_id,
  invoice,
  case when doc_code = 'C' then vendor_cm_no else null end as vendor_cm_no,
  aging_date,
  invoice_date,
  due_date,
  current_amt as invoice_amount,
  aging_level0,
  aging_level1,
  aging_level2,
  aging_level3,
  aging_level4,
  po_no,
  info
from vw_ap_aging_as_of_date  (nolock) 
where vendor_id = @VENDOR_ID  ";

            return sb.ToString();
        }




        public static string RebateDTL()
        {
            var sb =
                @"SELECT
AP_REBATE_DTL.AP_REBATE_ID AS AP_REBATE_ID,
AP_REBATE_DTL.AP_REBATE_DTL_ID AS AP_REBATE_DTL_ID,
AP_REBATE_DTL.AP_FAMILY_ID AS AP_FAMILY_ID,
AP_REBATE_DTL.GROUP_ID AS GROUP_ID,
AP_REBATE_DTL.ITEM_ID AS ITEM_ID,
IN_ITEM_MASTER.ITEM_NO,
IN_ITEM_MASTER.BASE_DESCRIPTION,
AP_REBATE_DTL.BEGIN_DATE,
AP_REBATE_DTL.END_DATE,
AP_REBATE_DTL.PTD_QTY,
AP_REBATE_DTL.REBATE_PERCENTAGE,
AP_REBATE_DTL.DISCOUNT_PERCENTAGE,
AP_REBATE_DTL.MARGIN_PERCENTAGE,
AP_REBATE_DTL.UNIT_REBATE_AMT,
AP_REBATE_DTL.APPLY_TO_V_DIRECT,
AP_REBATE_DTL.APPLY_TO_S_LINE,
AP_REBATE_HDR.VENDOR_ID AS VENDOR_ID,
AP_REBATE_HDR.REBATE_TYPE,
AP_REBATE_DTL.BASE_COST,
AP_REBATE_DTL.CALC_BASE_ID,
AP_REBATE_DTL.CALC_RATE,
AP_REBATE_DTL.COST_BASIS_ID
FROM AP_REBATE_DTL  (nolock) 
LEFT OUTER JOIN IN_ITEM_MASTER  (nolock) ON (AP_REBATE_DTL.ITEM_ID = IN_ITEM_MASTER.ITEM_ID)
INNER JOIN AP_REBATE_HDR  (nolock) ON (AP_REBATE_DTL.AP_REBATE_ID = AP_REBATE_HDR.AP_REBATE_ID)



 WHERE (
   ((AP_REBATE_HDR.VENDOR_ID = @VENDOR_ID ))
       ) ";

            return sb.ToString();
        }


        public static string RecurInvoiceHeader()
        {
            var sb =
                @"SELECT 
       AP_RECUR_HDR.RECUR_INVOICE_ID, 
       AP_RECUR_HDR.VENDOR_ID, 
       AP_RECUR_HDR.HOLD_BATCH_ID, 
       AP_RECUR_HDR.INVOICE_NO, 
       AP_RECUR_HDR.COMMENT, 
       AP_RECUR_HDR.BANK_ID, 
       AP_RECUR_HDR.IS_SELECTED, 
       AP_RECUR_HDR.IS_AUTO_RELEASED, 
       AP_RECUR_HDR.FREQUENCY_ID, 
       AP_RECUR_HDR.PO_NO, 
       AP_RECUR_HDR.AR_TERMS_ID, 
       AP_RECUR_HDR.DISC_AMT, 
       AP_RECUR_HDR.TAX_AMT, 
       AP_RECUR_HDR.DISC_RATE, 
       AP_RECUR_HDR.FRT_AMT, 
       AP_RECUR_HDR.IS_FORM_1099, 
       AP_RECUR_HDR.MAX_RELEASES, 
       AP_RECUR_HDR.REL_COUNT, 
       AP_RECUR_HDR.REL_DAY, 
       AP_RECUR_HDR.LAST_REL_DATE, 
       AP_RECUR_HDR.NEXT_REL_DATE, 
       AP_RECUR_HDR.GL_ACCT_ID, 
       AP_RECUR_HDR.SUBTOTAL_AMT, 
       AP_VENDOR.VENDOR_NO, 
       AP_VENDOR.VENDOR_NAME, 
       AP_VENDOR.ADDR, 
       AP_VENDOR.IS_PO_REQUIRED,
       AP_VENDOR.ZIP4,
       VW_LOCATION_CONTROL.ZIP,
       VW_LOCATION_CONTROL.CITY,
       VW_LOCATION_CONTROL.COUNTY,
       VW_LOCATION_CONTROL.STATE_CODE,
       VW_LOCATION_CONTROL.COUNTRY,
       AP_RECUR_HDR.BATCH_RELEASE_THRU_DATE, 
       GL_ACCT.PROFIT_CTR_ID, 
       GL_ACCT.GL_MASTER_ACCT_ID, 
       AP_VENDOR.CURRENCY, 
       AP_RECUR_HDR.IS_PREPAID,
       AP_VENDOR.MEMO_STATUS,
       dbo.gl_acct_combo(GL_ACCT.GL_MASTER_ACCT_ID) as ACCT_COMBO
FROM 
     AP_RECUR_HDR AP_RECUR_HDR (nolock) 
      LEFT OUTER JOIN AP_VENDOR AP_VENDOR  (nolock) ON 
     (AP_RECUR_HDR.VENDOR_ID = AP_VENDOR.VENDOR_ID)
      LEFT OUTER JOIN GL_ACCT GL_ACCT  (nolock) ON 
     (AP_RECUR_HDR.GL_ACCT_ID = GL_ACCT.GL_ACCT_ID)
     INNER JOIN GL_MASTER_ACCT (nolock)  on (GL_ACCT.GL_MASTER_ACCT_ID = GL_MASTER_ACCT.GL_MASTER_ACCT_ID)
     LEFT OUTER JOIN VW_LOCATION_CONTROL  (nolock) on ( AP_VENDOR.ZIP_CODE_DTL_ID = VW_LOCATION_CONTROL.ZIP_CODE_DTL_ID)

 WHERE (
   ((AP_RECUR_HDR.VENDOR_ID = @VENDOR_ID ))
)
";

            return sb.ToString();
        }

        public static string RecurInvoiceDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT "
                            + " AP_RECUR_DTL.RECUR_INVOICE_ID, "
                            + " AP_RECUR_DTL.RECUR_INVOICE_DTL_ID, "
                            + " AP_RECUR_HDR.HOLD_BATCH_ID, "
                            + " AP_RECUR_HDR.NEXT_REL_DATE, "
                            + " AP_RECUR_HDR.VENDOR_ID, "
                            + " GL_ACCT.PROFIT_CTR_ID, "
                            + " GL_ACCT.GL_MASTER_ACCT_ID, "
                            + " AP_RECUR_DTL.GL_ACCT_ID, "
                            + " AP_RECUR_DTL.AMOUNT, "
                            + " dbo.gl_acct_combo(gl_acct.gl_master_acct_id) as ACCT_COMBO, "
                            + " GL_MASTER_ACCT.DESCRIPTION as DESCRIPTION "
                            + " FROM AP_RECUR_DTL (nolock)  "
                            + " INNER JOIN AP_RECUR_HDR  (nolock) ON (AP_RECUR_DTL.RECUR_INVOICE_ID = AP_RECUR_HDR.RECUR_INVOICE_ID) "
                            + " INNER JOIN GL_ACCT (nolock)  ON (AP_RECUR_DTL.GL_ACCT_ID = GL_ACCT.GL_ACCT_ID) "
                            + " INNER JOIN GL_MASTER_ACCT  (nolock) ON (GL_ACCT.GL_MASTER_ACCT_ID = GL_MASTER_ACCT.GL_MASTER_ACCT_ID) "
                            + " INNER JOIN GL_PROFIT_CTR  (nolock) ON (GL_ACCT.PROFIT_CTR_ID = GL_PROFIT_CTR.PROFIT_CTR_ID) "

                            + "  WHERE ( "
                            + "    ((AP_RECUR_HDR.VENDOR_ID = @VENDOR_ID )) "
                            + " ) "
                        );

            return sb.ToString();

        }


        public static string glMasterAcct( int limit)
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                @" 
SELECT
   vw_GL_Master_Acct.GL_MASTER_ACCT_ID as GL_MASTER_ACCT_ID,
   vw_GL_Master_Acct.ACCT_COMBO as ACCT_COMBO,
   vw_GL_Master_Acct.ACCT_NO as ACCT_NO,
   vw_GL_Master_Acct.SUBACCT as SUBACCT,
   vw_GL_Master_Acct.DESCRIPTION as DESCRIPTION,
   vw_GL_Master_Acct.ACCT_TYPE as ACCT_TYPE,
   vw_GL_Master_Acct.RATIO_CODE_ID as RATIO_CODE_ID,
   GL_RATIO_CODE.CODE as CODE
FROM
   vw_GL_Master_Acct as vw_GL_Master_Acct (nolock)
   Left Outer Join GL_RATIO_CODE as GL_RATIO_CODE (nolock) on
      GL_RATIO_CODE.RATIO_CODE_ID = vw_GL_Master_Acct.RATIO_CODE_ID

   " );

        //if (glCode != "NULL")
        //{
            sb.AppendLine(" WHERE  vw_GL_Master_Acct.ACCT_NO LIKE  @ACCT_NO+'%' ");
       // }

        if (limit > 0)
        {
            sb.AppendLine(" ORDER BY  vw_GL_Master_Acct.ACCT_NO  OFFSET @OFFSET  ROWS FETCH NEXT  @LIMIT  ROWS ONLY ");
        }



            return sb.ToString();

        }

//        public static string glMasterAcctID()
//        {
//            var sb =
//                @" SELECT
//GL_MASTER_ACCT.GL_MASTER_ACCT_ID,
//GL_MASTER_ACCT.ACCT_NO,
//GL_MASTER_ACCT.SUBACCT,
//GL_MASTER_ACCT.DESCRIPTION,
//GL_MASTER_ACCT.ACCT_TYPE,
//GL_MASTER_ACCT.RATIO_CODE_ID,
//(convert(varchar(10) , ACCT_NO) + '-' + convert(varchar(8), SUBACCT)) as ACCT_COMBO
//from  GL_MASTER_ACCT
//where GL_MASTER_ACCT.GL_MASTER_ACCT_ID = @GL_MASTER_ACCT_ID ";

//            return sb.ToString();
//        }



        public static string ItemLookUp( int limit )
        {
            var sb = new StringBuilder();
            sb.AppendLine(

                @"SELECT IN_ITEM_MASTER.ITEM_ID, 
IN_ITEM_MASTER.ITEM_NO, 
IN_ITEM_MASTER.BASE_DESCRIPTION, 
IN_ITEM_MASTER.UPC_NO, 
IN_ITEM_MASTER.PSR_NO, 
IN_ITEM_MASTER.CATALOG_NAME, 
IN_ITEM_MASTER.PAGE_NO, 
IN_ITEM_MASTER.SEQ_PREFIX, 
IN_ITEM_MASTER.SEQ_SUFFIX, 
IN_ITEM_MASTER.STATUS_ID, 
IN_ITEM_MASTER.IS_STOCKED, 
IN_ITEM_MASTER.SUB_METHOD_ID, 
IN_ITEM_MASTER.OK_TO_DISCOUNT, 
IN_ITEM_MASTER.OK_TO_BO, 
IN_ITEM_MASTER.UNIT_CTRL_METHOD_ID, 
IN_ITEM_MASTER.UNIT_CTRL_WHEN_ID, 
IN_ITEM_MASTER.OK_TO_MIX, 
IN_ITEM_MASTER.IS_TAXABLE, 
IN_ITEM_MASTER.IS_DECIMAL, 
IN_ITEM_MASTER.CONTAINER_USED, 
IN_ITEM_MASTER.CONTAINER_WHEN_ID, 
IN_ITEM_MASTER.CONSIGNMENT_METHOD_ID, 
CAST(IN_ITEM_MASTER.CONSIGNMENT_RATE AS DECIMAL(5,2)) AS CONSIGNMENT_RATE, 
IN_ITEM_MASTER.WT_CTRL_TYPE, 
CAST(IN_ITEM_MASTER.MAX_DISC_PERCENTAGE AS DECIMAL(5,2)) AS MAX_DISC_PERCENTAGE, 
CAST(IN_ITEM_MASTER.MIN_MARGIN_PERCENTAGE AS DECIMAL(5,2)) AS MIN_MARGIN_PERCENTAGE, 
CAST(IN_ITEM_MASTER.UNIT_WEIGHT AS DECIMAL(17,8)) AS UNIT_WEIGHT, 
CAST(IN_ITEM_MASTER.UNIT_VOLUME AS DECIMAL(17,8)) AS UNIT_VOLUME, 
IN_ITEM_MASTER.DATE_ADDED, 
IN_ITEM_MASTER.PRICE_CHANGE_DATE, 
IN_ITEM_MASTER.LAST_SALE_DATE, 
CAST(IN_ITEM_MASTER.LIST_PRICE AS DECIMAL(17,8)) AS LIST_PRICE, 
IN_ITEM_MASTER.DATE_LAST_PRICED, 
IN_ITEM_MASTER.SKU_UM, 
IN_ITEM_MASTER.QTY_UM, 
CAST(IN_ITEM_MASTER.QTY_CONV AS DECIMAL(17,8)) AS QTY_CONV, 
CAST(IN_ITEM_MASTER.BREAK_PERCENTAGE AS DECIMAL(5,2)) AS BREAK_PERCENTAGE, 
CAST(IN_ITEM_MASTER.NEXT_COST AS DECIMAL(17,8)) AS NEXT_COST, 
CAST(IN_ITEM_MASTER.STD_COST AS DECIMAL(17,8)) AS STD_COST, 
IN_ITEM_MASTER.WARRANTY_MONTHS, 
IN_ITEM_MASTER.SHELF_LIFE_DAYS, 
IN_ITEM_MASTER.PRICE_UM, 
CAST(IN_ITEM_MASTER.PRICE_CONV_FACTOR AS DECIMAL(17,8)) AS PRICE_CONV_FACTOR, 
IN_ITEM_MASTER.COMMODITY_CODE, 
IN_ITEM_MASTER.COUNTRY_ID, 
dbo.country_code(IN_ITEM_MASTER.COUNTRY_ID) as COUNTRY_CODE, 
IN_ITEM_MASTER.LAST_PO_DATE, 
IN_ITEM_MASTER.LAST_RECEIPT_DATE, 
dbo.gk_group_code(in_item_master.group_id) as GROUP_CODE, 
IN_ITEM_MASTER.LAST_CHANGE_USER_ID, 
dbo.in_item_image_id(IN_ITEM_MASTER.ITEM_ID) as IMAGE_ID  ,
dbo.VENDOR_NO(IN_ITEM_MASTER.VENDOR_ID) as VENDOR_NO 
 ,dbo.VENDOR_NAME(IN_ITEM_MASTER.VENDOR_ID) as VENDOR_NAME 
, in_mfgr.mfgr 
 ,dbo.qty_avail(in_item_master.item_id, @whse_id) as qty_avail 
 ,dbo.qty_on_order(in_item_master.item_id, @whse_id) as qty_on_order 
 ,dbo.qty_on_hand(in_item_master.item_id, @whse_id) as qty_on_hand 
 ,dbo.whse_item_stockaid_qty(in_item_master.item_id, @whse_id) as stockaid_qty 
,(select dbo.gk_bin_no(in_whseitem_master.sell_bin) from in_whseitem_master (nolock)
where in_whseitem_master.item_id = in_item_master.item_id and 
in_whseitem_master.whse_id = @whse_id) as PRIMARY_BIN ,
(select dbo.gk_bin_no(in_whseitem_master.overflow_bin) from in_whseitem_master (nolock)
 where in_whseitem_master.item_id = in_item_master.item_id and 
 in_whseitem_master.whse_id = @whse_id) as SECONDARY_BIN ,
(select in_whseitem_master.monthly_usage from in_whseitem_master (nolock) 
 where in_whseitem_master.item_id = in_item_master.item_id and 
 in_whseitem_master.whse_id = @whse_id) as MONTHLY_USAGE FROM IN_ITEM_MASTER  (nolock) 
left outer JOIN IN_mfgr (nolock) ON IN_ITEM_master.mfgr_id = in_mfgr.mfgr_id 
 inner join in_vndritem_master  (nolock) on 
(in_vndritem_master.item_id = in_item_master.item_id 
and in_vndritem_master.vendor_id = @vendor_id ) 

         ");
                       
                sb.AppendLine( "  WHERE IN_ITEM_MASTER.ITEM_NO LIKE  @ITEM_NO+'%' ");
          

            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY  IN_ITEM_MASTER.ITEM_NO  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT ROWS ONLY ");
            }

            return sb.ToString();
        }



        public static string ItemLookUpById()
        {
            var sb = new StringBuilder();
            sb.AppendLine(

                @"SELECT
IN_ITEM_MASTER.ITEM_ID,
IN_ITEM_MASTER.COMMODITY_ID,
IN_ITEM_MASTER.ITEM_NO,
IN_ITEM_MASTER.BASE_DESCRIPTION,
IN_ITEM_MASTER.UPC_NO,
IN_ITEM_MASTER.PSR_NO,
IN_ITEM_MASTER.GROUP_ID,
IN_ITEM_MASTER.VENDOR_ID,
IN_ITEM_MASTER.MFGR_ID,
IN_ITEM_MASTER.CATALOG_NAME,
IN_ITEM_MASTER.PAGE_NO,
IN_ITEM_MASTER.SEQ_PREFIX,
IN_ITEM_MASTER.SEQ_SUFFIX,
IN_ITEM_MASTER.STATUS_ID,
IN_ITEM_MASTER.IN_FAMILY_ID,
IN_ITEM_MASTER.IS_STOCKED,
IN_ITEM_MASTER.SUB_METHOD_ID,
IN_ITEM_MASTER.OK_TO_DISCOUNT,
IN_ITEM_MASTER.OK_TO_BO,
IN_ITEM_MASTER.KIT_ID,
IN_ITEM_MASTER.UNIT_CTRL_METHOD_ID,
IN_ITEM_MASTER.UNIT_CTRL_WHEN_ID,
IN_ITEM_MASTER.OK_TO_MIX,
IN_ITEM_MASTER.IS_TAXABLE,
IN_ITEM_MASTER.IS_DECIMAL,
IN_ITEM_MASTER.CONTAINER_USED,
IN_ITEM_MASTER.CONTAINER_WHEN_ID,
IN_ITEM_MASTER.CONSIGNMENT_METHOD_ID,
CAST(IN_ITEM_MASTER.CONSIGNMENT_RATE AS DECIMAL(5,2)) AS CONSIGNMENT_RATE,
IN_ITEM_MASTER.WT_CTRL_TYPE,
CAST(IN_ITEM_MASTER.MAX_DISC_PERCENTAGE AS DECIMAL(5,2)) AS MAX_DISC_PERCENTAGE,
IN_ITEM_MASTER.HAZARD_ID,
IN_ITEM_MASTER.GL_SET_ID,
CAST(IN_ITEM_MASTER.MIN_MARGIN_PERCENTAGE AS DECIMAL(5,2)) AS MIN_MARGIN_PERCENTAGE,
CAST(IN_ITEM_MASTER.UNIT_WEIGHT AS DECIMAL(17,8)) AS UNIT_WEIGHT,
CAST(IN_ITEM_MASTER.UNIT_VOLUME AS DECIMAL(17,8)) AS UNIT_VOLUME,
IN_ITEM_MASTER.DATE_ADDED,
IN_ITEM_MASTER.PRICE_CHANGE_DATE,
IN_ITEM_MASTER.LAST_SALE_DATE,
CAST(IN_ITEM_MASTER.LIST_PRICE AS DECIMAL(17,8)) AS LIST_PRICE,
IN_ITEM_MASTER.SKU_UM,
IN_ITEM_MASTER.QTY_UM,
CAST(IN_ITEM_MASTER.QTY_CONV AS DECIMAL(17,8)) AS QTY_CONV,
CAST(IN_ITEM_MASTER.BREAK_PERCENTAGE AS DECIMAL(5,2)) AS BREAK_PERCENTAGE,
CAST(IN_ITEM_MASTER.NEXT_COST AS DECIMAL(17,8)) AS NEXT_COST,
CAST(IN_ITEM_MASTER.STD_COST AS DECIMAL(17,8)) AS STD_COST,
IN_ITEM_MASTER.WARRANTY_MONTHS,
IN_ITEM_MASTER.SHELF_LIFE_DAYS,
IN_ITEM_MASTER.PRICE_UM,
CAST(IN_ITEM_MASTER.PRICE_CONV_FACTOR AS DECIMAL(17,8)) AS PRICE_CONV_FACTOR,
IN_ITEM_MASTER.COMMODITY_CODE,
IN_ITEM_MASTER.COUNTRY_ID,
IN_ITEM_MASTER.LAST_PO_DATE,
IN_ITEM_MASTER.LAST_RECEIPT_DATE,
IN_ITEM_MASTER.LAST_CHANGE_USER_ID,
IN_ITEM_MASTER.CATEGORY_ID,
IN_ITEM_MASTER.MEMO_STATUS,
CAST(IN_ITEM_REF_PRICE.REFERENCE_PRICE AS DECIMAL(17,8)) AS REFERENCE_PRICE,
IN_KIT_SPEC_HDR.BTO_PRICE_METHOD,
dbo.in_item_image_id(IN_ITEM_MASTER.ITEM_ID) as IMAGE_ID 
from  IN_ITEM_MASTER
left outer join IN_ITEM_REF_PRICE on (IN_ITEM_MASTER.ITEM_ID = IN_ITEM_REF_PRICE.ITEM_ID)
left outer join IN_KIT_SPEC_HDR on (IN_ITEM_MASTER.ITEM_ID = IN_KIT_SPEC_HDR.KIT_ITEM_ID)
where IN_ITEM_MASTER.ITEM_ID = @ITEM_ID

");

            return sb.ToString();   
                
        }


        public static string ShipToLookup( int limit)
        {
             var sb = new StringBuilder();
            sb.AppendLine(

            @" SELECT
   AR_SHIP2.SHIP2_ID as SHIP2_ID,
   AR_SHIP2.CUST_ID as CUST_ID,
   AR_SHIP2.SHIP_NO as SHIP_NO,
   AR_SHIP2.SHIP2_NAME as SHIP2_NAME,
   AR_SHIP2.TEL_NO as TEL_NO,
   AR_SHIP2.FAX_NO as FAX_NO,
   AR_SHIP2.WEB_ADDRESS as WEB_ADDRESS,
   AR_SHIP2.STATUS_ID as STATUS_ID,
   AR_SHIP2.DATE_CREATED as DATE_CREATED,
   AR_SHIP2.DATE_LAST_PURCH as DATE_LAST_PURCH,
   AR_SHIP2.DATE_PO_EXPIRES as DATE_PO_EXPIRES,
   AR_SHIP2.DATE_LAST_QUOTED as DATE_LAST_QUOTED,
   AR_SHIP2.DATE_CLOSED as DATE_CLOSED,
   AR_SHIP2.LAST_INVOICE_NO as LAST_INVOICE_NO,
   AR_SHIP2.SHIP_ZONE as SHIP_ZONE,
   AR_SHIP2.ROUTE_STOP as ROUTE_STOP,
   AR_SHIP2.DAYS_TO_CANCEL as DAYS_TO_CANCEL,
   AR_SHIP2.DAYS_TO_SHIP as DAYS_TO_SHIP,
   AR_SHIP2.MIN_ORDER_AMT as MIN_ORDER_AMT,
   AR_SHIP2.LANGUAGE_CODE as LANGUAGE_CODE,
   AR_SHIP2.SINGLE_ORDER_LIMIT as SINGLE_ORDER_LIMIT,
   AR_SHIP2.SURCHARGE_RATE as SURCHARGE_RATE,
   AR_SHIP2.TAX_EXEMPT_NO as TAX_EXEMPT_NO,
   AR_SHIP2.COMMENTS as COMMENTS,
   AR_SHIP2.BLANKET_PO as BLANKET_PO,
   AR_SHIP2.BLANKET_PO_AMT as BLANKET_PO_AMT,
   AR_SHIP2.BLANKET_PO_AMT_USED as BLANKET_PO_AMT_USED,
   AR_SHIP2.NEXT_PO_REL_NO as NEXT_PO_REL_NO,
   AR_SHIP2.EMAIL_ADDRESS as EMAIL_ADDRESS,
   AR_SHIP2.IS_PICK_TICKET_PRICED as IS_PICK_TICKET_PRICED,
   AR_SHIP2.IS_PACK_SLIP_PRICED as IS_PACK_SLIP_PRICED,
   AR_SHIP2.IS_ACKNOW_PRICED as IS_ACKNOW_PRICED,
   AR_SHIP2.QTY_BRACKET as QTY_BRACKET,
   AR_SHIP2.CONTAINER_BRACKET as CONTAINER_BRACKET,
   AR_SHIP2.BACKORDER_CTRL_ID as BACKORDER_CTRL_ID,
   AR_SHIP2.USAGE_TRACKING_ID as USAGE_TRACKING_ID,
   AR_SHIP2.SUBTOTAL_CTRL_ID as SUBTOTAL_CTRL_ID,
   AR_SHIP2.IS_COMMENT_PRINT_PICKTKT as IS_COMMENT_PRINT_PICKTKT,
   AR_SHIP2.IS_COMMENT_PRINT_PACKSLIP as IS_COMMENT_PRINT_PACKSLIP,
   AR_SHIP2.IS_COMMENT_PRINT_ACKNOW as IS_COMMENT_PRINT_ACKNOW,
   AR_SHIP2.IS_COMMENT_PRINT_INVOICE as IS_COMMENT_PRINT_INVOICE,
   AR_SHIP2.IS_COMMENT_PRINT_QUOTE as IS_COMMENT_PRINT_QUOTE,
   AR_SHIP2.COD_METHOD_ID as COD_METHOD_ID,
   AR_SHIP2.IS_JOB as IS_JOB,
   AR_SHIP2.IS_RESIDENCE as IS_RESIDENCE,
   AR_SHIP2.IS_LICENSED as IS_LICENSED,
   AR_SHIP2.IS_LOT_PRICED as IS_LOT_PRICED,
   AR_SHIP2.IS_TAXABLE as IS_TAXABLE,
   AR_SHIP2.IS_SUMMARY_BILLED as IS_SUMMARY_BILLED,
   AR_SHIP2.IS_BEST_PRICE_OK as IS_BEST_PRICE_OK,
   AR_SHIP2.IS_SUB_OK as IS_SUB_OK,
   AR_SHIP2.IS_PO_REQUIRED as IS_PO_REQUIRED,
   AR_SHIP2.IS_RESTOCK_FEE_OK as IS_RESTOCK_FEE_OK,
   AR_SHIP2.IS_SHIP_COMPLETE as IS_SHIP_COMPLETE,
   AR_SHIP2.IS_SAVE_MSG_OK as IS_SAVE_MSG_OK,
   AR_SHIP2.IS_BREAK_CHARGE_OK as IS_BREAK_CHARGE_OK,
   AR_SHIP2.IS_SURCHARGE_OK as IS_SURCHARGE_OK,
   AR_SHIP2.IS_CO_CHECK_OK as IS_CO_CHECK_OK,
   AR_SHIP2.IS_FAMILY_DISC_OK as IS_FAMILY_DISC_OK,
   AR_SHIP2.IS_SPECIAL_ORDER_OK as IS_SPECIAL_ORDER_OK,
   AR_SHIP2.FOB_DEST as FOB_DEST,
   AR_SHIP2.IS_JOB_USAGE_PURGER as IS_JOB_USAGE_PURGER,
   AR_SHIP2.SAVE_MSG_MIN as SAVE_MSG_MIN,
   AR_SHIP2.ROUTE_CODE as ROUTE_CODE,
   AR_SHIP2.TERRITORY_CODE as TERRITORY_CODE,
   AR_SHIP2.TYPE_CODE as TYPE_CODE,
   AR_SHIP2.SIC_CODE as SIC_CODE,
   AR_SHIP2.SOURCE_CODE as SOURCE_CODE,
   AR_SHIP2.FRT_CTRL_ID as FRT_CTRL_ID,
   AR_SHIP2.FRT_ALLOWANCE_ID as FRT_ALLOWANCE_ID,
   AR_SHIP2.RESTOCK_RATE as RESTOCK_RATE,
   AR_SHIP2.IS_INSIDE_CITY_LIMITS as IS_INSIDE_CITY_LIMITS,
   AR_SHIP2.BILL_VIA_CARRIER_ID as BILL_VIA_CARRIER_ID,
   AR_SHIP2.INSIDE_SALESREP_ID as INSIDE_SALESREP_ID,
   AR_SHIP2.OUTSIDE_SALESREP_ID as OUTSIDE_SALESREP_ID,
   AR_SHIP2.AR_PRICE_COL_ID as AR_PRICE_COL_ID,
   AR_SHIP2.WHSE_ID as WHSE_ID,
   AR_SHIP2.AR_TERMS_ID as AR_TERMS_ID,
   AR_SHIP2.GL_SET_ID as GL_SET_ID,
   AR_SHIP2.SHIP_VIA_CARRIER_ID as SHIP_VIA_CARRIER_ID,
   AR_SHIP2.FRT_CTRL as FRT_CTRL,
   AR_SHIP2.FED_EX_ACCT as FED_EX_ACCT,
   AR_SHIP2.UPS_ACCT as UPS_ACCT,
   AR_SHIP2.MEMO_STATUS as MEMO_STATUS,
   AR_SHIP2.SERVICE_CODE_ID as SERVICE_CODE_ID,
   AR_SHIP2.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID,
   vw_location_control.CITY as CITY,
   vw_location_control.COUNTY as COUNTY,
   vw_location_control.STATE_CODE as STATE_CODE,
   vw_location_control.COUNTRY as COUNTRY,
   vw_location_control.PHONE_MASK as PHONE_MASK,
   vw_location_control.DIAL_CODE as DIAL_CODE,
   vw_location_control.ZIP as ZIP,
   cast(ar_ship2.addr as varchar(50)) as ADDR
FROM
   AR_SHIP2 as AR_SHIP2 (nolock)
   Left Outer Join vw_location_control as vw_location_control (nolock) on
      vw_location_control.ZIP_CODE_DTL_ID = AR_SHIP2.ZIP_CODE_DTL_ID  "     );


            //if (shipNo != "NULL")
            //{
                sb.AppendLine("  WHERE ((((AR_SHIP2.SHIP_NO LIKE @SHIP_NO+'%' ))  AND  ");
                sb.AppendLine("    ((AR_SHIP2.CUST_ID = @CUST_ID ))) )");
            //}
            //else
            //{
            //    sb.AppendLine("  WHERE AR_SHIP2.CUST_ID = @CUST_ID  ");
            //}

            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY  AR_SHIP2.SHIP_NO  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT  ROWS ONLY ");
            }

            return sb.ToString();

        }


        public static string ShipToContractLookup( int limit)
        {
            var sb = new StringBuilder();
            sb.AppendLine(

            @"SELECT
   AR_SHIP2_CONTRACT.AR_SHIP2_CONTRACT_ID as AR_SHIP2_CONTRACT_ID,
   OE_CONTRACT_HDR.CONTRACT_ID as CONTRACT_ID,
   OE_CONTRACT_HDR.CONTRACT as CONTRACT,
   OE_CONTRACT_HDR.DESCRIPTION as DESCRIPTION,
   AR_SHIP2_CONTRACT.BEGIN_DATE as BEGIN_DATE,
   AR_SHIP2_CONTRACT.END_DATE as END_DATE,
   AR_SHIP2_CONTRACT.SHIP2_ID as SHIP2_ID,
   AR_SHIP2_CONTRACT.CUST_ID as CUST_ID,
   AR_SHIP2.SHIP_NO as SHIP_NO,
   dbo.ship2_whse_id(AR_SHIP2_CONTRACT.CUST_ID, AR_SHIP2_CONTRACT.SHIP2_ID) as WHSE_ID
FROM
   OE_CONTRACT_HDR as OE_CONTRACT_HDR (nolock)
   Inner Join AR_SHIP2_CONTRACT as AR_SHIP2_CONTRACT (nolock) on
      AR_SHIP2_CONTRACT.CONTRACT_ID = OE_CONTRACT_HDR.CONTRACT_ID
   Left Outer Join AR_SHIP2 as AR_SHIP2 (nolock) on
      AR_SHIP2.SHIP2_ID = AR_SHIP2_CONTRACT.SHIP2_ID
WHERE (
   ((OE_CONTRACT_HDR.CONTRACT LIKE @CONTRACT+'%' ))
)" );

            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY  OE_CONTRACT_HDR.CONTRACT  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT  ROWS ONLY ");
            }
            return sb.ToString();
        }


        public static string CustomerStandardLookup( int limit)
        {
            var sb =new StringBuilder();
            sb.AppendLine(

                @"SELECT
   AR_CUST.CUST_ID as CUST_ID,
   AR_CUST.CUST_NO as CUST_NO,
   AR_CUST.CUST_NAME as CUST_NAME,
   AR_CUST.CURRENCY as CURRENCY,
   AR_CUST.CREDIT_LIMIT as CREDIT_LIMIT,
   AR_CUST.CUST_TYPE_ID as CUST_TYPE_ID,
   AR_CUST_STANDARD.DATE_LAST_PMT as DATE_LAST_PMT,
   AR_CUST_STANDARD.DATE_BAD_CHECK as DATE_BAD_CHECK,
   AR_CUST_STANDARD.DATE_REVIEW_CREDIT as DATE_REVIEW_CREDIT,
   AR_CUST_STANDARD.DATE_LAST_PURCHASED as DATE_LAST_PURCHASED,
   AR_CUST_STANDARD.HIGH_BALANCE as HIGH_BALANCE,
   AR_CUST_STANDARD.DATE_HIGH_BALANCE as DATE_HIGH_BALANCE,
   AR_CUST_STANDARD.AVG_PAY_DAYS as AVG_PAY_DAYS,
   AR_CUST_STANDARD.LAST_PAY_DAYS as LAST_PAY_DAYS,
   AR_CUST_STANDARD.OLDEST_DAYS as OLDEST_DAYS,
   AR_CUST_STANDARD.PAST_DUE_DAYS as PAST_DUE_DAYS,
   AR_CUST_STANDARD.CREDIT_HOLD_DAYS as CREDIT_HOLD_DAYS,
   AR_CUST_STANDARD.FINANCE_CHG_RATE as FINANCE_CHG_RATE,
   AR_CUST_STANDARD.MIN_FINANCE_CHG as MIN_FINANCE_CHG,
   AR_CUST_STANDARD.STMT_CYCLE as STMT_CYCLE,
   AR_CUST_STANDARD.COOP_RATE as COOP_RATE,
   AR_CUST_STANDARD.COOP_AD_CTRL as COOP_AD_CTRL,
   AR_CUST_STANDARD.IS_COOP_ROLLOVER as IS_COOP_ROLLOVER,
   AR_CUST_STANDARD.IS_STMT_ONLY as IS_STMT_ONLY,
   AR_CUST_STANDARD.IS_STMT_SENT as IS_STMT_SENT,
   AR_CUST_STANDARD.IS_STMT_DUNNING as IS_STMT_DUNNING,
   AR_CUST_STANDARD.IS_STMT_SHOW_PO as IS_STMT_SHOW_PO,
   AR_CUST_STANDARD.INVOICE_COPIES as INVOICE_COPIES,
   AR_CUST_STANDARD.OPEN_ITEMS_BALANCE as OPEN_ITEMS_BALANCE,
   AR_CUST_STANDARD.DELIVERY_TYPE as DELIVERY_TYPE,
   AR_CUST_STANDARD.STATEMENT_DELIVERY_TYPE as STATEMENT_DELIVERY_TYPE,
   AR_CUST_STANDARD.DEFAULT_SHIP2_ID as DEFAULT_SHIP2_ID,
   AR_CUST.XREF_NAME as XREF_NAME,
   AR_CUST_STANDARD.PAYFROM_ID as PAYFROM_ID,
   vw_location_control.CITY as CITY,
   vw_location_control.STATE_CODE as STATE_CODE,
   AR_SHIP2.TYPE_CODE as TYPE_CODE,
   AR_SHIP2.ADDRESS as ADDRESS,
   AR_SALESREP.LAST_NAME as LAST_NAME,
   AR_SHIP2.TEL_NO as TEL_NO,
   AR_SALESREP.SALESREP_CODE as SALESREP_CODE,
   AR_SHIP2.IS_SKU_PRINT_INVOICE as IS_SKU_PRINT_INVOICE,
   AR_SALESREP1.LAST_NAME as LAST_NAME1,
   AR_SALESREP1.FIRST_NAME as FIRST_NAME,
   AR_SALESREP1.SALESREP_CODE as SALESREP_CODE1,
   vw_location_control.ZIP as ZIP,
   cast(ar_ship2.addr as varchar(255)) as ADDR
FROM
   AR_CUST as AR_CUST (nolock)
   Inner Join AR_CUST_STANDARD as AR_CUST_STANDARD (nolock) on
      AR_CUST_STANDARD.CUST_ID = AR_CUST.CUST_ID
   Left Outer Join AR_SHIP2 as AR_SHIP2 (nolock) on
      AR_SHIP2.SHIP2_ID = AR_CUST_STANDARD.DEFAULT_SHIP2_ID
   Left Outer Join vw_location_control as vw_location_control (nolock) on
      vw_location_control.ZIP_CODE_DTL_ID = AR_SHIP2.ZIP_CODE_DTL_ID
   Left Outer Join AR_SALESREP as AR_SALESREP (nolock) on
      AR_SALESREP.SALESREP_ID = AR_SHIP2.OUTSIDE_SALESREP_ID
   Left Outer Join AR_SALESREP as AR_SALESREP1 (nolock) on
      AR_SALESREP1.SALESREP_ID = AR_SHIP2.INSIDE_SALESREP_ID
WHERE (
   (((AR_CUST.CUST_NO LIKE @CUST_NO+'%' )) AND
   ((AR_CUST.CUST_TYPE_ID = @CUST_TYPE_ID )))
)"
                 );

            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY  AR_CUST.CUST_NO  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT ROWS ONLY ");
            }

               
            return sb.ToString();

        }


        public static string VendorContractLookup( int limit)
        {
            var sb = new StringBuilder();
            sb.AppendLine(

                @"SELECT
   AP_CONTRACT_HDR.VCONTRACT_ID as VCONTRACT_ID,
   AP_CONTRACT_HDR.CONTRACT as CONTRACT,
   AP_CONTRACT_HDR.DESCRIPTION as DESCRIPTION,
   AP_CONTRACT_HDR.START_DATE as START_DATE,
   AP_CONTRACT_HDR.END_DATE as END_DATE,
   AR_CUST.CUST_NO as CUST_NO,
   AR_CUST.CUST_NAME as CUST_NAME,
   AR_SHIP2.SHIP_NO as SHIP_NO,
   AR_SHIP2.SHIP2_NAME as SHIP2_NAME,
   AR_SHIP2.TEL_NO as TEL_NO,
   AR_SHIP2.FAX_NO as FAX_NO,
   AR_SHIP2.WEB_ADDRESS as WEB_ADDRESS,
   AP_CONTRACT_HDR.VENDOR_ID as VENDOR_ID,
   AP_VENDOR.VENDOR_NO as VENDOR_NO,
   AP_VENDOR.VENDOR_NAME as VENDOR_NAME,
   vw_location_control.ZIP_CODE_DTL_ID as ZIP_CODE_DTL_ID,
   vw_location_control.CITY as CITY,
   vw_location_control.COUNTY as COUNTY,
   vw_location_control.STATE_CODE as STATE_CODE,
   vw_location_control.COUNTRY as COUNTRY,
   vw_location_control.PHONE_MASK as PHONE_MASK,
   vw_location_control.DIAL_CODE as DIAL_CODE,
   cast(ar_ship2.addr as varchar(50)) as addr,
   dbo.zip_code4(vw_location_control.zip, ar_ship2.zip4) as zip
FROM
   AP_CONTRACT_HDR as AP_CONTRACT_HDR (nolock)
   Left Outer Join AR_CUST as AR_CUST (nolock) on
      AR_CUST.CUST_ID = AP_CONTRACT_HDR.CUST_ID
   Left Outer Join AR_SHIP2 as AR_SHIP2 (nolock) on
      AR_SHIP2.CUST_ID = AR_CUST.CUST_ID
   Left Outer Join AP_VENDOR as AP_VENDOR (nolock) on
      AP_VENDOR.VENDOR_ID = AP_CONTRACT_HDR.VENDOR_ID
   Left Outer Join vw_location_control as vw_location_control (nolock) on
      vw_location_control.ZIP_CODE_DTL_ID = AR_SHIP2.ZIP_CODE_DTL_ID
WHERE (
   (((AP_CONTRACT_HDR.CONTRACT LIKE @CONTRACT+'%' )) AND
   ((AP_CONTRACT_HDR.VENDOR_ID = @VENDOR_ID )))
)"
                );
            if (limit > 0)
            {
                sb.AppendLine(" ORDER BY  AP_CONTRACT_HDR.CONTRACT  OFFSET @OFFSET ROWS FETCH NEXT  @LIMIT  ROWS ONLY ");
            }

            return sb.ToString();

        }


        public static string GetAcctId()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  select  * from gl_acct g where g.GL_MASTER_ACCT_ID=@GL_MASTER_ACCT_ID and g.PROFIT_CTR_ID=@PROFIT_CTR_ID ");

           // sb.AppendLine(
//            @"
//declare  @gl_acct_id varchar(255)  ;
//declare  @new_record bit ;
//
//if (@profit_ctr_id is not null) and (@gl_master_acct_id is not null) begin
//set @new_record = 0
//set @gl_acct_id = null
//
//select @gl_acct_id = gl_acct_id
//from gl_acct (nolock)
//where profit_ctr_id = @profit_ctr_id
//      and gl_master_acct_id = @gl_master_acct_id
//  if (@@ERROR <> 0) GOTO on_error
//
//if @gl_acct_id is null begin
//  set @gl_acct_id = newid()
//  set @new_record = 1
//
//  insert into gl_acct
//    (gl_acct_id,
//     profit_ctr_id,
//     gl_master_acct_id)
//  values
//    (@gl_acct_id,
//     @profit_ctr_id,
//     @gl_master_acct_id)
//  if (@@ERROR <> 0) GOTO on_error
//
//  -- Create COException Trans Record
//  insert into co_exception_trans
//  (exception_id,
//  exception_type,
//  trans_date,
//  user_id,
//  gl_acct_id)
//  values
//  (newid(),
//   '08',
//  getdate(),
//   null, -- Currently null since all calling routines do not currently pass user_id,  future changes may be required
//   @gl_acct_id
//  )
// if (@@ERROR <> 0) GOTO on_error
//
//end
//end
//
//return(0)
//
//on_error:
//return(1)"
   //         );


            return sb.ToString();
        }


        public static string QtyTable()
        {
             var sb = new StringBuilder();
             sb.AppendLine(@"SELECT 
  AP_CONTRACT_QTY.VCONTRACT_DTL_ID AS VCONTRACT_DTL_ID,  
  AP_CONTRACT_QTY.BRACKET_ID AS BRACKET_ID,
  AP_CONTRACT_QTY.BRACKET,
  AP_CONTRACT_QTY.BUY_QTY,
  AP_CONTRACT_QTY.DISC_RATE,
  AP_CONTRACT_QTY.UNIT_COST,
  in_vndritem_master.std_pack as QTY_UM,
  in_vndritem_master.std_pack as AMT_UM,
  in_vndritem_master.STD_PACK,
  in_vndritem_master.LIST_PRICE,
  ap_contract_dtl.CALC_METHOD_ID,
  ap_contract_dtl.QTY_TABLE_TYPE,
  ap_contract_hdr.VENDOR_ID,
  ap_contract_dtl.ITEM_ID
FROM  AP_CONTRACT_QTY (nolock) 
  inner join ap_contract_dtl  (nolock) on (ap_contract_dtl.vcontract_dtl_id = ap_contract_qty.vcontract_dtl_id)
  inner join ap_contract_hdr  (nolock) on (ap_contract_hdr.vcontract_id = ap_contract_dtl.vcontract_id)
  left outer join in_vndritem_Master  (nolock) on (in_vndritem_master.vendor_id = ap_contract_hdr.vendor_id and
                                         in_vndritem_master.item_id = ap_contract_dtl.item_id)
 WHERE (
   ((AP_CONTRACT_QTY.VCONTRACT_DTL_ID = @VCONTRACT_DTL_ID ))
)
"
                 );

             return sb.ToString();


        }

        #endregion

    }
}