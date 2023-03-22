using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Core.IMediatR.Abstraction;
using Knab.Integration.Dtos.Listing;

namespace Knab.Integration.Commands
{
    public class UpdateListingsCommand : MediatRCommandBase<bool>, IMediatRCommand
    {
        public IEnumerable<ListingDto> Listings { get; set; }

        public UpdateListingsCommand(IEnumerable<ListingDto> listings)
        {
            Listings = listings;
        }
    }
}