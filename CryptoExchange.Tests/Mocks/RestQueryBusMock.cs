using System.Net;
using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Core.RestSharp;
using Moq;
using RestSharp;

namespace CryptoExchange.Tests.Mocks;

public class RestQueryBusMock : Mock<IRestQueryBus>
{

    public void SetupGetForSuccess<TResponse>(TResponse response)
    {
        var result = new ExternalCommandResult<TResponse>
        {
            Result = response,
            StatusCode = HttpStatusCode.OK
        };
        SetupGet(result);
    }

    public void SetupGetForError<TResponse>()
    {
        var ex = new Exception("Request Failed");
        var result = new ExternalCommandResult<TResponse>
        {
            ErrorException = ex,
            ErrorMessage = ex.Message,
            ResponseStatus = ResponseStatus.TimedOut,
            StatusCode = HttpStatusCode.ServiceUnavailable
        };
        SetupGet(result);
    }

    private void SetupGet<TResponse>(IRestBusResult<TResponse> result)
    {
        Setup(s => s.Get<TResponse>(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>(),
            It.IsAny<IEnumerable<Tuple<string, string>>>(), default)
        ).ReturnsAsync(() => result);
    }
}