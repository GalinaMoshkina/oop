using System;

namespace Game.Items.Types
{
    public class Banana : Food
    {
        public Banana() : base(
            name: "Банан",
            description: "Сочный большой свежий бананчик",
            healthRestore: 10,
            moodBoost: 30,  
            tasteQuality: 9,
            isShareable: true,
            eatTime: 2,
            rarity: ItemRarity.Uncommon
        ) { }
    }

    public class HawaiianPork : Food
    {
        public HawaiianPork() : base(
            name: "Свинина по-гавайски",
            description: "Свинина с ананасом и перцем",
            healthRestore: 30,
            moodBoost: 15,
            tasteQuality: 8,
            isShareable: true,
            eatTime: 8,
            rarity: ItemRarity.Rare
        ) { }
    }

    public class Soup : Food
    {
        public Soup() : base(
            name: "Суп",
            description: "Обычный куриный суп",
            healthRestore: 20,
            moodBoost: 12,
            tasteQuality: 6,
            isShareable: true,
            eatTime: 5,
            rarity: ItemRarity.Common
        ) { }
    }

    public class Coffee : Food
    {
        public Coffee() : base(
            name: "Кофе",
            description: "Overpriced iced latte on alternative milk",
            healthRestore: 8,
            moodBoost: 29,
            tasteQuality: 9,
            isShareable: false,
            eatTime: 1,
            rarity: ItemRarity.Rare
        ) 
        {
            ManaRestore = 25;
        }
    }

    public class PadThai : Food
    {
        public PadThai() : base(
            name: "Пад-тай",
            description: "Еда богов",
            healthRestore: 40,
            moodBoost: 30,
            tasteQuality: 10,
            isShareable: false,
            eatTime: 15,
            rarity: ItemRarity.Legendary
        ) { }
    }
    public class Bread : Food
    {
        public Bread() : base(
            name: "Хлеб",
            description: "Базовая еда",
            healthRestore: 15,
            moodBoost: 5,
            tasteQuality: 6,
            isShareable: false,
            eatTime: 10,
            rarity: ItemRarity.Common
        ) { }
    }
    public class ExpiredBread : Food
    {
        public ExpiredBread() : base(
            name: "Черствый хлеб",
            description: "Хлеб стал камнем. Есть нельзя.",
            healthRestore: -20,
            moodBoost: -30,
            tasteQuality: 1,
            isShareable: false,
            eatTime: 20,
            rarity: ItemRarity.Common,
            state: FoodState.Expired
        ) { }
    }

    public class RottenBanana : Food
    {
        public RottenBanana() : base(
            name: "Гнилой банан",
            description: "Серый, влажный, воняет.",
            healthRestore: -15,
            moodBoost: -40,
            tasteQuality: 0,
            isShareable: false,
            eatTime: 5,
            rarity: ItemRarity.Uncommon,
            state: FoodState.Expired
        ) { }
    }
}
