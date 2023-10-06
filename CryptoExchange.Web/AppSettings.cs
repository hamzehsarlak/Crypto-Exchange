namespace CryptoExchange.Web;

public class AppSettings
{
    public string CoinMarketCapApiKey { get; set; }
    public string ExchangeRatesApiKey { get; set; }
    
    public int CoinMarketCapMonthlyLimit { get; set; }
    
    public int ExchangeRatesApiMonthlyLimit { get; set; }
}