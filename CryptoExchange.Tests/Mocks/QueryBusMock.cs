using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Integration.Dtos.Listing;
using CryptoExchange.Integration.Dtos.Rate;
using CryptoExchange.Integration.Queries;
using Moq;

namespace CryptoExchange.Tests.Mocks;

public class QueryBusMock : Mock<IQueryBus>
{
    public void SetupForGetCachedRatesQuery(IEnumerable<RateDto> rateDtos)
    {
        Setup(s => s.SendAsync<GetCachedRatesQuery, IEnumerable<RateDto>>(It.IsAny<GetCachedRatesQuery>(), default))
            .ReturnsAsync(() => rateDtos);
    }

    public void SetupForGetCachedListingsQuery(IEnumerable<ListingDto> listingDtos)
    {
        Setup(s => s.SendAsync<GetCachedListingsQuery, IEnumerable<ListingDto>>(It.IsAny<GetCachedListingsQuery>(),
                default))
            .ReturnsAsync(() => listingDtos);
    }
}