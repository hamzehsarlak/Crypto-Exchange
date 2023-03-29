using FluentAssertions;
using Knab.CoinMarketCap;
using Knab.CoinMarketCap.Models.Response;
using Knab.Integration.Queries;
using Knab.Tests.Mocks;
using Microsoft.Extensions.Options;

namespace Knab.Tests.CoinMarketCap;

[TestFixture]
public class CoinMarketCapTests
{
    private readonly RestQueryBusMock _restQueryBusMock;
    private readonly CoinMarketCapService _sut;

    public CoinMarketCapTests()
    {
        _restQueryBusMock = new RestQueryBusMock();
        var options = Options.Create(new CoinMarketCapOptions()
        {
            ApiKey = "x"
        });

        _sut = new CoinMarketCapService(_restQueryBusMock.Object, options);
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
        _restQueryBusMock.SetupGetForSuccess(TestData.ListingsResponse);

        var result = await _sut.GetListingsAsync(new FetchListingsQuery());
        result.Count().Should().Be(2);
    }

    [Test]
    public void GetListingsAsync_Should_Not_Succeed()
    {
        _restQueryBusMock.SetupGetForError<ListingsResponse>();

        Assert.ThrowsAsync<Exception>(async () => await _sut.GetListingsAsync(new FetchListingsQuery()));
    }
}