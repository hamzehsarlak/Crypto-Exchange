using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.Data;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Domain.Entities;
using CryptoExchange.Integration.Commands;

namespace CryptoExchange.Application.CommandHandlers
{
    public class UpdateListingsCommandHandler : IMediatRCommandHandler<UpdateListingsCommand, bool>
    {
        private readonly IRepository<CryptoCurrencyEntity> _cryptoCurrencyRepository;
        private readonly IRepository<ListingEntity> _listingRepository;

        public UpdateListingsCommandHandler(IRepository<CryptoCurrencyEntity> cryptoCurrencyRepository,
            IRepository<ListingEntity> listingRepository)
        {
            _cryptoCurrencyRepository = cryptoCurrencyRepository;
            _listingRepository = listingRepository;
        }

        public async Task<bool> Handle(UpdateListingsCommand command, CancellationToken cancellationToken)
        {
            // map to entity
            var listingEntities = command.Listings.Select(l => new ListingEntity(l.Id, l.UsdPrice, l.BtcPrice));
            var cryptoEntities = command.Listings.Select(l => new CryptoCurrencyEntity(l.CryptoCurrencyDto.Id,
                l.CryptoCurrencyDto.Name, l.CryptoCurrencyDto.Symbol, l.CryptoCurrencyDto.Slug));

            // save to db
            await _cryptoCurrencyRepository.Upsert(cryptoEntities, cancellationToken);
            await _listingRepository.Upsert(listingEntities, cancellationToken);
            return true;
        }
    }
}