using FluentAssertions;
using Knab.Application.QueryHandlers;
using Knab.Integration.Dtos;
using Knab.Integration.Queries;
using Knab.Tests.Mocks;

namespace Knab.Tests.Queries;

[TestFixture]
public class ConversionsQueryHandlerTest
{
    private readonly QueryBusMock _queryBusMock;
    private readonly GetConversionsQueryHandler _sut;

    public ConversionsQueryHandlerTest()
    {
        _queryBusMock = new QueryBusMock();
        _sut = new GetConversionsQueryHandler(_queryBusMock.Object);
    }

    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
        _queryBusMock.VerifyAll();
    }

    [Test]
    public async Task Handle_Should_Succeed()
    {
        _queryBusMock.SetupForGetCachedRatesQuery(TestData.RateDtos);
        _queryBusMock.SetupForGetCachedListingsQuery(TestData.ListingDtos);

        var result = (await _sut.Handle(new GetConversionsQuery(), default)).ToArray();

        result.Length.Should().Be(2);

        result.All(r => r.Conversions.Count == TestData.RateDtos.Count).Should().BeTrue();
    }

    [Test]
    public void Conversions_Should_Be_Correct()
    {
        var data = TestData.ListingDtos.First();
        var dto = new ConversionDto(data.Id, data.CryptoCurrencyDto.Name, data.CryptoCurrencyDto.Symbol, data.UsdPrice,
            data.BtcPrice, TestData.RateDtos);
        dto.Conversions.Should().ContainKeys(TestData.RateDtos.Select(r => r.Symbol));

        foreach (var conversion in dto.Conversions)
        {
            conversion.Value.Should()
                .Be(Math.Round(data.UsdPrice * TestData.RateDtos.First(r => r.Symbol == conversion.Key).Rate, 2,
                    MidpointRounding.AwayFromZero));
        }
    }
}