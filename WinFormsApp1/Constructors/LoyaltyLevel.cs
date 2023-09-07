using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors
{
    public class LoyaltyLevel
    {
        public int buyPriceCoef { get; set; }
        public int exchangePriceCoef { get; set; }
        public int healPriceCoef { get; set; }
        public int insurancePriceCoef { get; set; }
        public int repairPriceCoef { get; set; }
        public int minLevel { get; set; }
        public int minSalesSum { get; set; }
        public float minStanding { get; set; }
        public int level;
        
        public LoyaltyLevel(int level, JObject jobject)
        {
            this.level = level;
            buyPriceCoef = jobject["buy_price_coef"]?.Value<int>() ?? 0;
            exchangePriceCoef = jobject["exchange_price_coef"]?.Value<int>() ?? 0;
            healPriceCoef = jobject["heal_price_coef"]?.Value<int>() ?? 0;
            insurancePriceCoef = jobject["insurance_price_coef"]?.Value<int>() ?? 0;
            minLevel = jobject["minLevel"]?.Value<int>() ?? 0;
            minSalesSum = jobject["minSalesSum"]?.Value<int>() ?? 0;
            minStanding = jobject["minStanding"]?.Value<float>() ?? 0.0f;
            repairPriceCoef = jobject["repair_price_coef"]?.Value<int>() ?? 0;
        }
        public LoyaltyLevel(int level)
        {
            this.level = level;
        }

        public override string ToString()
        {
            return level.ToString();
        }
    }
}
