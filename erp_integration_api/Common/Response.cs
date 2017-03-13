using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace erp_integration_api.Common
{

    [Serializable]
    public class Response<T>
    {
        public bool Success;

        public string Message;
        public string AppVersion;
        public T Result;

        public void Create(bool success, string message, string appversion, T result)
        {
            this.Success = success;
            this.Message = message;
            this.AppVersion = appversion;
            this.Result = result;
        }
    }

    public class Messages
    {
        public const string AppVersion = "1.0";
        public const string LOGIN_SUCCESS = "Loggedin Successfully!";

        public static string FormatMessage(string message, params string[] args)
        {
            return String.Format(message, args);
        }
    }


}