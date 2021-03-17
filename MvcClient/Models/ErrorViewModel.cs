using System;
using IdentityServer4.Models;

namespace MvcClient.Models
{
    //public class ErrorViewModel
    //{
    //    public string RequestId { get; set; }

    //    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    //}


    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }

        public ErrorViewModel(string error)
        {
            Error = new ErrorMessage { Error = error };
        }

        public ErrorMessage Error { get; set; }
    }
}
