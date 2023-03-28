using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.Data;
using Knab.Core.IMediatR.Abstraction;
using Knab.Domain.Entities;
using Knab.Integration.Dtos.CryptoCurrency;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;

namespace Knab.Application.QueryHandlers
{
    public class GetCachedListingsQueryHandler : IMediatRQueryHandler<GetCachedListingsQuery, IEnumerable<ListingDto>>
    {
        private readonly IRepository<CryptoCurrencyEntity> _cryptoCurrencyRepository;
        private readonly IRepository<ListingEntity> _listingRepository;

        public GetCachedListingsQueryHandler(IRepository<CryptoCurrencyEntity> cryptoCurrencyRepository, IRepository<ListingEntity> listingRepository)
        {
            _cryptoCurrencyRepository = cryptoCurrencyRepository;
            _listingRepository = listingRepository;
        }

        public async Task<IEnumerable<ListingDto>> Handle(GetCachedListingsQuery request, CancellationToken cancellationToken)
        {
            var cryptoSymbols = await _cryptoCurrencyRepository.GetAllAsync(cancellationToken);
            
            var listings = (await _listingRepository.GetAllAsync(cancellationToken)).ToArray();
            
            return listings.Select(l => MapListing(l, cryptoSymbols.FirstOrDefault(c => c.Id == l.Id)));
        }

        private static ListingDto MapListing(ListingEntity entity, CryptoCurrencyEntity currencyEntity)
        {
            return new ListingDto
            {
                Id = entity.Id,
                BtcPrice = entity.BtcPrice,
                UsdPrice = entity.UsdPrice,
                CryptoCurrencyDto = MapCryptoCurrency(currencyEntity)
            };
        }
        private static CryptoCurrencyDto MapCryptoCurrency(CryptoCurrencyEntity entity) =>
            new CryptoCurrencyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug,
                Symbol = entity.Symbol
            };
    }
}
