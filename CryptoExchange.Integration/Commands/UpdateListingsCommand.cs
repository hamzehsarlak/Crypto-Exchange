using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Integration.Dtos.Listing;

namespace CryptoExchange.Integration.Commands
{
    public class UpdateListingsCommand : MediatRCommandBase<bool>, IMediatRCommand
    {
        public IEnumerable<ListingDto> Listings { get; }

        public UpdateListingsCommand(IEnumerable<ListingDto> listings)
        {
            Listings = listings;
        }
    }
}