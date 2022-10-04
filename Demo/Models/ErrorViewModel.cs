using System;

namespace Demo.Models
{
    public class ErrorViewModel
    {
        public string class_name { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


    }
}
