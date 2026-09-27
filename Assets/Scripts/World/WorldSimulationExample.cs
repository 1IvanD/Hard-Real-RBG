using System.Collections.Generic;
using System.Linq;

namespace HardRealRBG.World
{
    public class CommodityPrice
    {
        public string Name;
        public float BaseCost;
        public float CurrentCost;

        public CommodityPrice(string name, float baseCost)
        {
            Name = name;
            BaseCost = baseCost;
            CurrentCost = baseCost;
        }
    }

    public class EconomySystem
    {
        private readonly Dictionary<string, CommodityPrice> _market = new Dictionary<string, CommodityPrice>();

        public EconomySystem()
        {
            RegisterCommodity("Bread", 5f);
            RegisterCommodity("Meat", 12f);
            RegisterCommodity("Grain", 6f);
            RegisterCommodity("Wood", 8f);
            RegisterCommodity("Iron", 20f);
            RegisterCommodity("Stone", 9f);
            RegisterCommodity("House", 900f);
            RegisterCommodity("Farm", 1800f);
            RegisterCommodity("Manor", 4500f);
            RegisterCommodity("Potion", 35f);
            RegisterCommodity("Sword", 65f);
        }

        public void RegisterCommodity(string name, float baseCost)
        {
            if (!_market.ContainsKey(name))
            {
                _market[name] = new CommodityPrice(name, baseCost);
            }
        }

        public float GetPrice(string name)
        {
            if (_market.ContainsKey(name))
            {
                return _market[name].CurrentCost;
            }

            return 0f;
        }

        public void UpdatePrices(WorldState world)
        {
            foreach (var commodity in _market.Values)
            {
                float modifier = 1f;

                if (commodity.Name == "Bread" || commodity.Name == "Grain" || commodity.Name == "Meat")
                {
                    modifier *= 1f + (1f - world.HarvestQuality) * 0.45f;
                    modifier *= 1f + world.WarIntensity * 0.18f;
                    modifier *= 1f + world.DemonInfluence * 0.12f;
                }

                if (commodity.Name == "House" || commodity.Name == "Farm" || commodity.Name == "Manor")
                {
                    modifier *= 1f + world.WarIntensity * 0.10f;
                    modifier *= 1f + (1f - world.BorderSecurity) * 0.18f;
                    modifier *= 1f + world.Population * 0.00002f;
                }

                if (commodity.Name == "Wood" || commodity.Name == "Iron" || commodity.Name == "Stone")
                {
                    modifier *= 1f + world.WarIntensity * 0.25f;
                    modifier *= 1f + world.DemonInfluence * 0.08f;
                }

                if (commodity.Name == "Potion" || commodity.Name == "Sword")
                {
                    modifier *= 1f + world.WarIntensity * 0.28f;
                    modifier *= 1f + world.DemonInfluence * 0.14f;
                }

                commodity.CurrentCost = commodity.BaseCost * modifier;
            }
        }

        public List<string> GetMarketSummary()
        {
            return _market.Values
                .OrderBy(x => x.Name)
                .Select(x => x.Name + ": " + x.CurrentCost.ToString("0.00"))
                .ToList();
        }
    }
}
