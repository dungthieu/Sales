using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models
{
    public class ApiResponse<TContent>
    {
        public ApiResponse()
            : this(content: default(TContent), errorMessage: null)
        {
        }

        public ApiResponse(TContent content)
            : this(content: content, errorMessage: null)
        {
        }

        public ApiResponse(TContent content, string errorMessage)
        {
            Content = content;
            ErrorMessage = errorMessage;
        }

        public TContent Content { get; }

        public string ErrorMessage { get; }
    }
}
