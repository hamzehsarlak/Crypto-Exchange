using CryptoExchange.Integration.Dtos.CryptoCurrency;

namespace CryptoExchange.Integration.Dtos.Listing
{
    public class ListingDto
    {
        public CryptoCurrencyDto CryptoCurrencyDto { get; set; }
        
        public int Id { get; set; }

        public double UsdPrice { get; set; }
        
        public double BtcPrice { get; set; }
    }
}