using System;
using Game.Items.Types;

namespace Game.Items.Types.Armor
{
    using Game.Player;
    public class Jacket : Armor
    {
        public Jacket() : base(
            name: "Куртка",
            description: "Очень стильная",
            weight: 3,
            protection: 15,
            styleBonus: 20,
            slot: SlotType.Body,
            rarity: ItemRarity.Epic
        ) { }
    }

    public class AdidasSuit : Armor
    {
        public AdidasSuit() : base(
            name: "Костюм Adidas",
            description: "Спорт, мода и комфорт",
            weight: 4,
            protection: 10,
            styleBonus: 15,
            slot: SlotType.Body,
            rarity: ItemRarity.Rare
        ) { }
    }

    public class FunkyHat : Armor
    {
        public FunkyHat() : base(
            name: "Базарный берет",
            description: "Модная субстанция на голову",
            weight: 1,
            protection: 5,
            styleBonus: 25,
            slot: SlotType.Head,
            rarity: ItemRarity.Uncommon
        ) { }
    }

    public class VintageJeans : Armor
    {
        public VintageJeans() : base(
            name: "Винтажные джинсы",
            description: "Модель 1985 года. Дорогие, но стоят того",
            weight: 2,
            protection: 8,
            styleBonus: 12,
            slot: SlotType.Legs,
            rarity: ItemRarity.Rare
        ) { }
    }

    public class DesignerSneakers : Armor
    {
        public DesignerSneakers() : base(
            name: "Дизайнерские кроссовки",
            description: "Скороходы от известного дизайнера",
            weight: 1,
            protection: 5,
            styleBonus: 18,
            slot: SlotType.Feet,
            rarity: ItemRarity.Epic
        ) { }
    }
}