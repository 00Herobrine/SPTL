using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors
{
    public struct LoyaltyLevel
    {
        private int buyPriceCoef { get; set; }
        private int exchangePriceCoef { get; set; }
        public int healPriceCoef { get; set; }
        public int insurancePriceCoef { get; set; }
        public int minLevel { get; set; }
        public int minSalesSum { get; set; }
        public float minStanding { get; set; }
        public int repairPriceCoef { get; set; }

        public LoyaltyLevel(JObject jobject)
        {
            buyPriceCoef = jobject["buy_price_coef"]?.Value<int>() ?? 0;
            exchangePriceCoef = jobject["exchange_price_coef"]?.Value<int>() ?? 0;
            healPriceCoef = jobject["heal_price_coef"]?.Value<int>() ?? 0;
            insurancePriceCoef = jobject["insurance_price_coef"]?.Value<int>() ?? 0;
            minLevel = jobject["minLevel"]?.Value<int>() ?? 0;
            minSalesSum = jobject["minSalesSum"]?.Value<int>() ?? 0;
            minStanding = jobject["minStanding"]?.Value<float>() ?? 0.0f;
            repairPriceCoef = jobject["repair_price_coef"]?.Value<int>() ?? 0;
        }
    }
}
