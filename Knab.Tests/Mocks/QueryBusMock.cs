using Knab.Core.Abstraction.CQRS;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Dtos.Rate;
using Knab.Integration.Queries;
using Moq;

namespace Knab.Tests.Mocks;

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