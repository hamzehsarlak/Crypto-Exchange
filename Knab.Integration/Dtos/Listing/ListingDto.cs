using Knab.Integration.Dtos.CryptoCurrency;

namespace Knab.Integration.Dtos.Listing
{
    public class ListingDto
    {
        public CryptoCurrencyDto CryptoCurrencyDto { get; set; }
        
        public string Id { get; set; }
        public double UsdPrice { get; set; }
        public double BtcPrice { get; set; }
    }
}