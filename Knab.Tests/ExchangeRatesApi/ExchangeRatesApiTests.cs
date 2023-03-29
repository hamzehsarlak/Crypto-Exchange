using FluentAssertions;
using Knab.Application.ExchangeRatesApi;
using Knab.Application.ExchangeRatesApi.Models.Responses;
using Knab.Integration.Queries;
using Knab.Tests.Mocks;
using Microsoft.Extensions.Options;

namespace Knab.Tests.ExchangeRatesApi;

public class ExchangeRatesApiTests
{
    private readonly RestQueryBusMock _restQueryBusMock;
    private readonly ExchangeRatesApiService _sut;

    public ExchangeRatesApiTests()
    {
        _restQueryBusMock = new RestQueryBusMock();
        var options = Options.Create(new ExchangeRatesApiOptions()
        {
            ApiKey = "x"
        });

        _sut = new ExchangeRatesApiService(_restQueryBusMock.Object, options);
    }

    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
        _restQueryBusMock.VerifyAll();
    }

    [Test]
    public async Task GetListingsAsync_Should_Succeed()
    {
        _restQueryBusMock.SetupGetForSuccess(TestData.RatesResponse);

        var result = await _sut.GetRatesAsync(new FetchRatesQuery());
        result.Count.Should().Be(4);
    }

    [Test]
    public void GetListingsAsync_Should_Not_Succeed()
    {
        _restQueryBusMock.SetupGetForError<RatesResponse>();

        Assert.ThrowsAsync<Exception>(async () => await _sut.GetRatesAsync(new FetchRatesQuery()));
    }
}