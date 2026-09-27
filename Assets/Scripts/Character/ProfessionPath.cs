using System.Collections.Generic;

namespace HardRealRBG.Character
{
    public enum ProfessionPathType
    {
        Aristocrat,
        Worker,
        Villain,
        Hero
    }

    public enum AristocratProfession
    {
        Noble,
        MerchantPrince,
        Courtier,
        Landowner,
        Governor
    }

    public enum WorkerProfession
    {
        Farmer,
        Blacksmith,
        Carpenter,
        Hunter,
        Miner,
        Baker,
        Tailor,
        Mason,
        Shepherd
    }

    public enum VillainProfession
    {
        Bandit,
        Smuggler,
        Assassin,
        Cultist,
        Mercenary,
        Raider,
        Thief
    }

    public enum HeroProfession
    {
        Knight,
        Paladin,
        Ranger,
        Mage,
        Cleric,
        Guardian,
        Warden
    }

    public class ProfessionDefinition
    {
        public ProfessionPathType PathType;
        public string Name;
        public string Description;
        public List<string> Advantages;
        public List<string> Risks;

        public ProfessionDefinition(
            ProfessionPathType pathType,
            string name,
            string description,
            List<string> advantages,
            List<string> risks)
        {
            PathType = pathType;
            Name = name;
            Description = description;
            Advantages = advantages;
            Risks = risks;
        }
    }

    public static class ProfessionCatalog
    {
        public static readonly List<ProfessionDefinition> All = new List<ProfessionDefinition>
        {
            new ProfessionDefinition(
                ProfessionPathType.Aristocrat,
                "Noble",
                "A wealthy family member with land, reputation, and political influence.",
                new List<string> { "High social standing", "Access to property and laws", "Influence on nobles and courts" },
                new List<string> { "Political enemies", "High maintenance costs", "Public expectations" }),

            new ProfessionDefinition(
                ProfessionPathType.Aristocrat,
                "Merchant Prince",
                "Controls trade routes, supply chains, and large markets.",
                new List<string> { "Rich income", "Market control", "Trade influence" },
                new List<string> { "Risk of bankruptcy", "Competition", "Targeted sabotage" }),

            new ProfessionDefinition(
                ProfessionPathType.Worker,
                "Farmer",
                "Works the land and supplies food to towns and cities.",
                new List<string> { "Food production", "Steady survival income", "Connection to villages" },
                new List<string> { "Weather risk", "Crop disease", "Low social prestige" }),

            new ProfessionDefinition(
                ProfessionPathType.Worker,
                "Blacksmith",
                "Crafts weapons, armor, tools, and metal goods.",
                new List<string> { "High demand in war", "Reliable trade", "Can build weapons" },
                new List<string> { "Dangerous working conditions", "Expensive materials", "Fierce competition" }),

            new ProfessionDefinition(
                ProfessionPathType.Worker,
                "Carpenter",
                "Builds homes, furniture, ships, and city structures.",
                new List<string> { "Essential for growth", "Can improve villages", "Portable trade skills" },
                new List<string> { "Slow income during war", "Limited territory" }),

            new ProfessionDefinition(
                ProfessionPathType.Worker,
                "Hunter",
                "Tracks beasts and hunts for food and materials.",
                new List<string> { "Fast resource gathering", "Good wilderness survival", "High mobility" },
                new List<string> { "Dangerous wildlife", "Unstable income" }),

            new ProfessionDefinition(
                ProfessionPathType.Villain,
                "Bandit",
                "Lives outside the law and raids caravans and villages.",
                new List<string> { "Fast resources", "Mobility", "Can ambush enemies" },
                new List<string> { "Bounty hunters", "Hostile factions", "Hunted by guards" }),

            new ProfessionDefinition(
                ProfessionPathType.Villain,
                "Smuggler",
                "Moves contraband and forbidden goods across borders.",
                new List<string> { "High profit", "Risk-heavy income", "Can work with criminals" },
                new List<string> { "Arrest risk", "War smuggling danger", "Trust issues" }),

            new ProfessionDefinition(
                ProfessionPathType.Villain,
                "Assassin",
                "Eliminates targets silently, politically or strategically.",
                new List<string> { "High impact missions", "Stealth advantage", "Political leverage" },
                new List<string> { "Constant pursuit", "Moral consequences", "Enemy retaliation" }),

            new ProfessionDefinition(
                ProfessionPathType.Hero,
                "Knight",
                "Protects people, guards roads, and fights for order.",
                new List<string> { "Honor and respect", "Combat training", "Public protection" },
                new List<string> { "Heavy armor burden", "High risk in battle", "Can lose reputation" }),

            new ProfessionDefinition(
                ProfessionPathType.Hero,
                "Paladin",
                "A holy warrior empowered by faith and justice.",
                new List<string> { "Strong morale boost", "Supportive abilities", "Trust from villages" },
                new List<string> { "Religious conflict", "Hard moral choices", "Limited stealth" }),

            new ProfessionDefinition(
                ProfessionPathType.Hero,
                "Ranger",
                "Protects the frontier and tracks threats in the wild.",
                new List<string> { "Forest and border expertise", "Excellent scouting", "High mobility" },
                new List<string> { "Weak in siege combat", "Isolation", "Rugged life" }),

            new ProfessionDefinition(
                ProfessionPathType.Hero,
                "Mage",
                "Commands arcane power and manipulates magical forces.",
                new List<string> { "Powerful spells", "Rarity and prestige", "Strategic advantage" },
                new List<string> { "Mana exhaustion", "Dangerous magical backlash", "Variable public trust" })
        };
    }
}
