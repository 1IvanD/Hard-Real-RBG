using System;
using System.Collections.Generic;

namespace HardRealRBG.World
{
    [Serializable]
    public class WorldState
    {
        public float Population;
        public float HumanMorale;
        public float DemonInfluence;
        public float HarvestQuality;
        public float WarIntensity;
        public float BorderSecurity;
        public float TaxRate;
        public bool IsWarActive;
        public string CurrentSeason;

        public WorldState()
        {
            Population = 120000f;
            HumanMorale = 0.68f;
            DemonInfluence = 0.22f;
            HarvestQuality = 0.74f;
            WarIntensity = 0.12f;
            BorderSecurity = 0.65f;
            TaxRate = 0.12f;
            IsWarActive = false;
            CurrentSeason = "Spring";
        }

        public void AdvanceDay()
        {
            if (CurrentSeason == "Spring")
            {
                HarvestQuality += 0.04f;
            }
            else if (CurrentSeason == "Summer")
            {
                HarvestQuality -= 0.02f;
            }
            else if (CurrentSeason == "Autumn")
            {
                HarvestQuality += 0.02f;
            }
            else if (CurrentSeason == "Winter")
            {
                HarvestQuality -= 0.07f;
            }

            if (DemonInfluence > 0.8f)
            {
                WarIntensity += 0.03f;
                HumanMorale -= 0.02f;
                IsWarActive = true;
            }
            else if (DemonInfluence < 0.35f)
            {
                WarIntensity -= 0.01f;
                HumanMorale += 0.01f;
            }

            if (WarIntensity > 0.7f)
            {
                IsWarActive = true;
                Population -= 120f;
                HumanMorale -= 0.04f;
                BorderSecurity -= 0.03f;
            }
            else if (WarIntensity < 0.4f)
            {
                IsWarActive = false;
                HumanMorale += 0.02f;
                BorderSecurity += 0.02f;
            }

            HarvestQuality = Mathf.Clamp(HarvestQuality, 0.05f, 1.0f);
            HumanMorale = Mathf.Clamp(HumanMorale, 0.0f, 1.0f);
            DemonInfluence = Mathf.Clamp(DemonInfluence, 0.0f, 1.0f);
            WarIntensity = Mathf.Clamp(WarIntensity, 0.0f, 1.0f);
            BorderSecurity = Mathf.Clamp(BorderSecurity, 0.0f, 1.0f);
        }

        public string DescribeState()
        {
            if (IsWarActive)
            {
                return "The war between humans and demons has spread across the frontier.";
            }

            if (DemonInfluence > 0.6f)
            {
                return "The demonic influence is rising. The realm is on edge.";
            }

            return "The realm is mostly stable, though trade and food markets remain fragile.";
        }
    }

    public static class Mathf
    {
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
