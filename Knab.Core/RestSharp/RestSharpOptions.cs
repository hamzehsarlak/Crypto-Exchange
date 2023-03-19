using System;

namespace Knab.Core.RestSharp
{
    public class RestSharpOptions
    {
        public int MaxRetryAttempts { get; set; }
        public TimeSpan PauseBetweenFailures { get; set; }

        public RestSharpOptions()
        {
            
        }
        public RestSharpOptions(int maxRetryAttempts=-1, TimeSpan pauseBetweenFailures= default)
        {
            MaxRetryAttempts = maxRetryAttempts;
            PauseBetweenFailures = pauseBetweenFailures;
        }
    }
}
