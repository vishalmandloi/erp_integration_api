using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp_integration_api.Common
{
    public class Constaints
    {
        public static string CompanyName = "My Test Company";
        public static string CompanyUrl = "http://google.com";
        public static string CompanyAddress = "This is company Address";
        public static string CompanyPhone = "123 234 3343";
    }

    /// <summary>
    /// 
    /// </summary>
    public struct RolesMessages
    {
        public const string FetchedSuccess = "Data Fetched Successfully";

        public const string InvalidId = "Please give the proper item identifier.";

        public const string RoleIdNotPresentUser = "PUT halt due to Role-Id not present in the model";

        public const string CommandIdNotPresentUser = "PUT halt due to Command-Id not present in the model";

        public const string RecordsNotGet = "Unable to get the Records.";

        public const string NotDeleted = "Failed to delete this item";

        public const string NoDataChange = "No content changed";

        public const string ModelEmpty = "Model is empty";

        public const string NotCreated = "Unable to create new item, please try again later.";

    }
}