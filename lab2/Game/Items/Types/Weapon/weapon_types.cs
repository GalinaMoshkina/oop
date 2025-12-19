using System;
using Game.Items.Types;

namespace Game.Items.Types.Weapon
{
    using Game.Player;
    public class PickmeStick : Weapon
    {
        public PickmeStick() : base(
            name: "Пикми указка",
            description: "#hellyeah",
            weight: 1,
            absurdityDamage: 10,
            attackSpeed: 1.0,
            isFunny: true,
            rarity: ItemRarity.Epic
        ) { }
    }

    public class ShoppingCart : Weapon
    {
        public ShoppingCart() : base(
            name: "Магазинная тележка",
            description: "Сегодня не в хогвартс, а за дошираком",
            weight: 15,
            absurdityDamage: 25,
            attackSpeed: 3.0,
            isFunny: true,
            rarity: ItemRarity.Uncommon
        ) { }
    }

    public class MeatyOil : Weapon
    {
        public MeatyOil() : base(
            name: "Масло, смазанное мясом",
            description: "Намажьте мясо маслом, масло мясом, сасло саслом, сысло сыслом.",
            weight: 3,
            absurdityDamage: 40,
            attackSpeed: 1.5,
            isFunny: true,
            rarity: ItemRarity.Epic
        ) { }
    }

    public class OldBread : Weapon
    {
        public OldBread() : base(
            name: "Черствая буханка хлеба",
            description: "Bon appetit",
            weight: 5,
            absurdityDamage: 55,
            attackSpeed: 2.0,
            isFunny: false,
            rarity: ItemRarity.Common
        ) { }
    }

    public class LegoDuplo : Weapon
    {
        public LegoDuplo() : base(
            name: "Лего Дупло",
            description: "Выстроим красную дорожку!",
            weight: 2,
            absurdityDamage: 35,
            attackSpeed: 0.5,
            isFunny: true,
            rarity: ItemRarity.Rare
        ) { }
    }

    public class MathAnalysisBook : Weapon
    {
        public MathAnalysisBook() : base(
            name: "Учебник по матану",
            description: "Самое страшное оружие",
            weight: 10,
            absurdityDamage: 60,
            attackSpeed: 4.0,
            isFunny: false,
            rarity: ItemRarity.Epic
        ) { }
    }

    public class PaperSheet : Weapon
    {
        public PaperSheet() : base(
            name: "Лист бумаги",
            description: "С большой силой приходит большая ответственность",
            weight: 0,
            absurdityDamage: 5,
            attackSpeed: 0.1,
            isFunny: false,
            rarity: ItemRarity.Common
        ) { }
    }
}
