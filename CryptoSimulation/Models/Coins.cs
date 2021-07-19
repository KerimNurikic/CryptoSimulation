using javax.jws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public enum Coins
    {
        BTC, ETH, USDT, ADA, LTC, XLM, BCH, BNB, XRP, DOGE
    }

    public static class CoinMethods
    {
        public static string getDisplayName(string coin)
        {
            switch (coin)
            {
                case "BTC":
                    return "Bitcoin (BTC)";
                case "ETH":
                    return "Ethereum (ETH)";
                case "USDT":
                    return "Tether (USDT)";

                case "ADA":
                    return "Cardano (ADA)";

                case "LTC":
                    return "Litecoin (LTC)";

                case "XLM":
                    return "Stellar (XLM)";

                case "BCH":
                    return "Bitcoin Cash (BCH)";

                case "BNB":
                    return "Binance Coin (BNB)";

                case "XRP":
                    return "XRP (XRP)";

                case "DOGE":
                    return "Dogecoin (DOGE)";

                default:
                    return "invalid";

            }

        }
        [WebMethod]
        public static string getImg(string coin)
        {
            switch (coin)
            {
                case "BTC":
                    return "~/src/btc_icon.png";

                case "ETH":
                    return "~/src/eth_icon.png";

                case "USDT":
                    return "~/src/usdt_icon.png";

                case "ADA":
                    return "~/src/ada_icon.png";

                case "LTC":
                    return "~/src/tlc_icon.png";

                case "XLM":
                    return "~/src/xlm_icon.png";

                case "BCH":
                    return "~/src/bch_icon.png";

                case "BNB":
                    return "~/src/bnb_icon.png";

                case "XRP":
                    return "~/src/xrp_icon.png";

                case "DOGE":
                    return "~/src/doge_icon.png";

                default:
                    return "invalid";

            }
        }
    }
}
