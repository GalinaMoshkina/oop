using System;
using System.Collections.Generic;
using System.Linq;
using Game.Items.Types;
using Game.Player;
// using Game.Actions;

namespace Game.Actions
{
    using Game.Player;
    public static class Combo
    {
        private static readonly Dictionary<(string, string), Func<Item>> Combos = new()
        {
            { ("Банан", "Банан"), () => new PepsiCola() },
            { ("Хлеб", "Масло"), () => new Toast() },
            { ("Масло", "Хлеб"), () => new Toast() }
        };

        public static void Execute(Game.Player.Player player, Item item1, Item item2)
        {
            if (player == null || item1 == null || item2 == null)
            {
                return;
            }
            var comboKey = (item1.Name, item2.Name);
            if (Combos.TryGetValue(comboKey, out var createResultItem))
            {
                bool removed1 = player.Inventory.RemoveItem(item1);
                bool removed2 = player.Inventory.RemoveItem(item2);
                if (!removed1 || !removed2)
                {
                    if (removed1) player.Inventory.AddItem(item1);
                    if (removed2) player.Inventory.AddItem(item2);
                    return;
                }
                var resultItem = createResultItem();
                Add.Execute(player, resultItem);
            }
        }
    }
    public class PepsiCola : Item
    {
        public PepsiCola() : base(
            name: "Пепси Кола",
            description: "Сладкий напиток",
            weight: 2,
            rarity: ItemRarity.Uncommon)
        {
        }
        public override bool CanUse() => true;
        public override void Use(Player player)
        {
            if (player != null && player.IsAlive)
            {
                player.Mood += 15;
                if (player.Mood > 100) player.Mood = 100;
            }
        }
    }
    public class Toast : Item
    {
        public Toast() : base(
            name: "Тост",
            description: "Хлеб с маслом",
            weight: 1,
            rarity: ItemRarity.Common)
        {
        }
        public override bool CanUse() => true;
        public override void Use(Player player)
        {
            if (player != null && player.IsAlive)
            {
                player.Mood += 5;
                if (player.Mood > 100) player.Mood = 100;
            }
        }
    }
}